using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Usellesator
    {
        static void Initializator()
        {
            Console.OutputEncoding = Encoding.UTF8;
            byte tbyte = 255;
            sbyte tsbyte = 127;
            short tshort = 32767;
            ushort tushor = 65535;
            int tint = 2147483647;
            uint tuint = 4294967295;
            long tlong = 9223372036854775807;
            ulong tulong = 18446744073709551615;
            float tfloat = 3402823f;
            double tdouble = 179769313486232308d;
            decimal tdecimal = 79228162514264337593543950335m;
            char tchar = 'c';
            string tstring = "string";
            bool tbool = false;
            object tobject = "object"; // any type
        }
        static void Types()
        {
            // НЕЯВНОЕ ПРЕОБРАЗОВАНИЕ
            int num = 2147483647;
            long bigNum = num;

            byte bite = 2;
            short notbite = bite;

            float floattodouble = 24.4f;
            double floatfromdouble = floattodouble;

            char chartoint = '2';
            int intfromchar = chartoint;

            sbyte sbytetodecimal = 64;
            decimal decimalfromsbyte = sbytetodecimal;

            // ЯВНОЕ ПРЕОБРАЗОВАНИЕ
            int сnum = 2147483647;
            long сbigNum = (long)сnum;

            byte сbite = 2;
            short сnotbite = (short)сbite;

            float сfloattodouble = 24.4f;
            double сfloatfromdouble = (double)сfloattodouble;

            char сchartoint = '2';
            int сintfromchar = (int)сchartoint;

            sbyte сsbytetodecimal = 64;
            decimal сdecimalfromsbyte = (decimal)сsbytetodecimal;
            
            // НЕЯВНО ТИПИЗИРОВАННАЯ ПЕРЕМЕННАЯ       
            var notclearvar = "notclearvar";
            string clearvar = notclearvar;

            // NULLABLE
            int? nullable = null;
        }
        static void Strings() 
        {
            String str1 = "string";
            String str2 = "notastring"; 
            String str3;
            String[] srt4 = { "Hello", "Darkness", "My", "Old", "Friend" };
            Console.WriteLine("Вывод строки на экран.");
            if (String.Compare(str1, str2) > 0)
            {
                Console.WriteLine(str1);
            }
            else if (String.Compare(str1, str2) < 0)
            {
                Console.WriteLine(str2);
            }
            else
            {
                Console.WriteLine("OOPS");
            }
            Console.WriteLine('\n');
            str3 = String.Concat(str1, str2); // конкатенация(сцепление) через String
            Console.WriteLine("Конкатенация через Concat: {0}", str3);
            String str5 = String.Join(" ", srt4);
            Console.WriteLine("Конкатенация через Join: {0}", str5); // конкатенация через Join
            Console.WriteLine("Копирование через Copy");
            Console.WriteLine("Before: {0}", str1);
            String temp = str1;
            str1 = String.Copy(str2); // копирование str2 в str1 через Copy
            Console.WriteLine("After: {0}", str1);
            Console.WriteLine('\n');
            str1 = temp;
            

            // Выделение строки через Substring
            int startIndex = 6;
            int length = 3;
            String substring = str3.Substring(startIndex, length);
            Console.WriteLine("Выделение подстроки через Substring: {0}", substring);
            Console.WriteLine('\n');

            // Разделение строки на слова через Split
            Char separator = ' ';
            String[] words = str5.Split(separator);
            Console.WriteLine("Разделение строки на слова через Split");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine('\n');

            // Вставка строки в заданную позицию через Insert
            Console.WriteLine("Вставка строки в заданную позицию через Insert");
            Console.WriteLine(str3);
            String modStr3 = str3.Insert(6, "IS");
            Console.WriteLine(modStr3);
            Console.WriteLine('\n');

            // Удаление заданной подстроки через Remove
            Console.WriteLine("Удаление заданной подстроки через Remove");
            Console.WriteLine(modStr3);
            Console.WriteLine(modStr3.Remove(6, 6));
            Console.WriteLine('\n');

            //Работа с пустой и null строками
            Console.WriteLine("Работа с пустой и null строками");
            String nullstring = null;
            String emptyString = "";
            Console.WriteLine(str1 + nullstring);
            Console.WriteLine(str1 + emptyString);
            str1 = String.Copy(emptyString);
            // str2 = String.Copy(nullstring); Ошибка
            Console.WriteLine(str1);
            Console.WriteLine('\n');

            // Работа со строкой с помощью String.Builder
            StringBuilder str6 = new StringBuilder("Builder's String");
            Console.WriteLine(str6);
            Console.WriteLine(str6.Remove(9, 7));
            Console.WriteLine(str6.Append(" new String"));
            Console.WriteLine(str6.Insert(0, "My "));
            Console.WriteLine();
        }
        static void Arrays()
        {
            Console.WriteLine("Вывод матрицы\n");
            int[][] nums = new int[2][];
            nums[0] = new int[3] { 1, 2, 3 };
            nums[1] = new int[3] { 4, 5, 6 };
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    Console.Write($"{nums[i][j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Вывод массива строк\n");
            string[] strings = new string[] { "It's", "a", "good", "day", "to", "do", "some", "labs."};
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(String.Join(" ", strings));
            Console.WriteLine();
            Console.WriteLine("Размер строки: {0}\n", strings.Length);
            int position = 5;
            string newstring = "die with";
            for (int i = 0; i < strings.Length; i++)
            {
                if (i == position)
                {
                    strings[i] = newstring;
                }
            }
            Console.WriteLine(String.Join(" ", strings));
            Console.WriteLine();

            Console.WriteLine("Вывод ступенчатого массива\n");
            int[][] stairs = new int[3][];
            stairs[0] = new int[2];
            stairs[1] = new int[3];
            stairs[2] = new int[4];
            int g, k = 0;
            for (g = 0; g < stairs.Length; g++)
            {
                for (k = 0; k < stairs[g].Length; k++)
                {
                    stairs[g][k] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int n = 0; n < stairs.Length; n++)
            {
                for (int m = 0; m < stairs[n].Length; m++)
                {
                    Console.Write($"{stairs[n][m]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Неявно типизированные переменные с массивом и строкой");
            var notclearlyarray = new[] { 0, 1, 2 };
            var notclearlystring = "Неявно типизированная строка";
            foreach (var i in notclearlyarray)
            {
                Console.Write("{0} ",i);
            }
            Console.Write("{0} ", notclearlystring);
            Console.WriteLine();           
        }
        static void Tuples()
        {
            Console.WriteLine("\nРабота с кортежами");
            (int, string, char, string, ulong) tuple = (int1: 27, string1: "String", 
                char1: 'C', string2: "Second string", ulong1: 72);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item2);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            Console.WriteLine(tuple.Item5);
            int element1 = tuple.Item1;
            string element2 = tuple.Item2;
            char element3 = tuple.Item3;
            string element4 = tuple.Item4;
            ulong element5 = tuple.Item5;
            (int, string, char, string, ulong) tuple2 = (int1: 27, string1: "String",
                char1: 'C', string2: "Second string", ulong1: 72);
            Console.WriteLine(tuple.Equals(tuple2)); 
        }
        static void Main(string[] args)
        {
            (int, int, int, char) GetTuple(int[] array, string sentense)
            {
                int min = array[0];
                int max = array[0];
                int sum = 0;
                char letter = sentense[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > min)
                    {
                        max = array[i];
                    }
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                    sum += array[i];
                }
                var tuple = (max, min, sum, letter);
                return tuple;
            }            
            Initializator();
            Types();
            Strings();
            Arrays();
            Tuples();
            int[] numbers = new int[] { 7, 9, 27, 23, 42, 2 };   
            var mainTuple = GetTuple(numbers, "VA-11 HALL-A");
            Console.WriteLine("\nПолучение кортежа значений\n");
            Console.WriteLine("Max: {0}", mainTuple.Item1);
            Console.WriteLine("Min: {0}", mainTuple.Item2);
            Console.WriteLine("Sum: {0}", mainTuple.Item3);
            Console.WriteLine("Letter: {0}", mainTuple.Item4);
            Console.ReadLine();
        }
    }
}
