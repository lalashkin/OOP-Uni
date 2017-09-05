# -*- coding: utf-8 -*-

import datetime
import time
import re

import vk_api
import gspread
from oauth2client.service_account import ServiceAccountCredentials

from config import config


def captcha_handler(captcha):
    """ 
        При возникновении капчи вызывается эта функция и ей передается объект
        капчи. Через метод get_url можно получить ссылку на изображение.
        Через метод try_again можно попытаться отправить запрос с кодом капчи
    """

    key = input("Enter captcha code {0}: ".format(captcha.get_url())).strip()

    return captcha.try_again(key)


def session_create(user_login, user_pass):
    session = vk_api.VkApi(user_login, user_pass, captcha_handler=captcha_handler)
    try:
        session.auth()
    except vk_api.AuthError as error_msg:
        print(error_msg)
    api = session.get_api()
    return api


def get_wall_comments(api):
    competitors = {}
    post_id = input("Enter your post id: ")
    post = api.wall.getById(posts='-128011960_' + post_id)

    post_time = datetime.datetime.strptime(time.ctime(post[0]['date']), '%a %b  %d %H:%M:%S %Y')
    input_time = datetime.datetime.strptime(input("Enter your time: "), '%H:%M')
    input_time = datetime.datetime.now().replace(day=post_time.day,
                                                 month=post_time.month,
                                                 year=post_time.year,
                                                 hour=input_time.hour,
                                                 minute=input_time.minute)

    comments = api.wall.getComments(owner_id=-128011960, count=100, post_id=post_id)
    for comment in comments['items']:
        if comment['from_id'] not in competitors \
                and re.match(r'!vote\s{0,2}\d\s?-\s?\d\s{0,5}', comment['text'], re.IGNORECASE)\
                and input_time.timestamp() >= comment['date']:
            competitors[comment['from_id']] = comment['text'].split(' ', 1)[-1]
    return competitors


def add_to_sheet(users, api):
    scope = ['https://spreadsheets.google.com/feeds']
    creds = ServiceAccountCredentials.from_json_keyfile_name('client_secret.json', scope)
    client = gspread.authorize(creds)
    sheet = client.open('byGamers').sheet1
    for i, user in enumerate(users, 2):
        print("ID: %s\nBet: %s\n" % (api.users.get(user_ids=user)[0]['first_name']
                                     + ' '
                                     + api.users.get(user_ids=user)[0]['last_name'], users[user]))
    add_points(users, sheet, api)


def table_check(users):
    winners = {}
    game_type = int(input("What type of game it is? | 1 - bo2 | 2 - bo3 | 3- bo5 |"))
    if game_type == 1:
        result = input("Enter correct prediction: ")
        scope = ['https://spreadsheets.google.com/feeds']
        creds = ServiceAccountCredentials.from_json_keyfile_name('client_secret.json', scope)
        client = gspread.authorize(creds)
        sheet = client.open('byGamers').sheet1
        for user in users:
            if users[user] == result:
                winners[user] = users[user]
        return winners
    if game_type == 2:
        results = []
        r_team = ['0-2', '1-2']
        l_team = ['2-0', '2-1']
        score = int(input("Who won? | Left Team - 1 | Right Team - 2 |"))
        if score == 1:
            results.extend(l_team)
        elif score == 2:
            results.extend(r_team)
        for user in users:
            if users[user] in results:
                winners[user] = users[user]
        return winners
    if game_type == 3:
        results = []
        r_team = ['0-3', '1-3', '2-3']
        l_team = ['3-0', '3-1', '3-2']
        score = int(input("Who won? | Left Team - 1 | Right Team - 2 |"))
        if score == 1:
            results.extend(l_team)
        elif score == 2:
            results.extend(r_team)
        for user in users:
            if users[user] in results:
                winners[user] = users[user]
        return winners


def add_points(users, sheet, api):
    cells_list = []
    points = int(input("Amount of points: "))
    for user in users:
        cells_list.append(sheet.findall(api.users.get(user_ids=user)[0]['first_name']
                          + ' '
                          + api.users.get(user_ids=user)[0]['last_name']))
        cells_list = list(filter(None, cells_list))
    for cell in cells_list:
        init_value = sheet.cell(cell[0].row, cell[0].col + 1).value
        if init_value is '':
            init_value = 0
        sheet.update_cell(cell[0].row, cell[0].col+1, int(init_value) + points)
    print(list(filter(None, cells_list)))


api = session_create(user_login=config.VK_LOGIN, user_pass=config.VK_PASSWD)
add_to_sheet(table_check(get_wall_comments(api)), api)



#Added this line for test purps
#this is the same