using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_4
{
    public class Pass
    {
        string pass;
        bool isEqual;

        public Pass()
        {
            GetPass();
        }

        public void GetPass()
        {
            Console.WriteLine("Enter your password: ");
            pass = Console.ReadLine();
        }

        public void ShowPass()
        { 
            Console.WriteLine("\nYour password is {0} ", pass);
        }

        public string AddPass()
        {
            return pass;
        }

        class Owner
        {
            public static readonly long Id;
            public string Name;
            public string Organization;

            static Owner()
            {
                Id = DateTime.Now.Ticks;
            }

            public Owner()
            {
                Name = "George";
                Organization = "BelSTU";
            }

            public void GetData()
            {
                Console.WriteLine("ID: {0}\nName: {1}\nOrganization: {2}\n", Id, Name, Organization);
            }
        }

        class Date
        {
            public string createDate;
            public Date()
            {
                createDate = DateTime.Now.ToShortDateString();
            }
        }

        public static Pass operator -(Pass obj, char letter)
        {
            obj.pass = obj.pass.Substring(0, obj.pass.Length - 1) + letter;
            return obj;
        }

        public static Pass operator ++(Pass obj)
        {
            obj.pass = "DEFAULT";
            return obj;
        }

        public static Pass operator !=(Pass obj1, Pass obj2)
        {
            if(obj1.pass == obj2.pass)
            {
                obj1.isEqual = obj2.isEqual = true;
                return obj1;
            }
            else
            {
                obj1.isEqual = obj2.isEqual = false;
                return obj1;
            }
        }

        public static Pass operator ==(Pass obj1, Pass obj2)
        {
            if (obj1.pass == obj2.pass)
            {
                obj1.isEqual = obj2.isEqual = true;
                return obj1;
            }
            else
            {
                obj1.isEqual = obj2.isEqual = false;
                return obj1;
            }
        }

        public static Pass operator >(Pass obj1, Pass obj2)
        {
            if(obj1.pass.Length > obj2.pass.Length)
            {
                return obj1;
            }
            else
            {
                return obj2;
            }
        }

        public static Pass operator <(Pass obj1, Pass obj2)
        {
            if (obj1.pass.Length < obj2.pass.Length)
            {
                return obj2;
            }
            else
            {
                return obj1;
            }
        }
    }

    public static class Util
    {
        public static void MiddleHighlight(this Pass str)
        {
            var o = str.AddPass().Length;
            o /= 2;
            Console.Write(str.AddPass().Substring(0, o));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str.AddPass()[o]);
            Console.ResetColor();
            Console.WriteLine(str.AddPass().Substring(o + 1));
        }

        public static void LengthCheck(this Pass obj)
        {
            if (obj.AddPass().Length > 12 || obj.AddPass().Length < 6)
            {
                Console.WriteLine("Password must contain minimum 6, maximum 12 characters in it.");
            }
            else
            {
                Console.WriteLine("Password is matching all requirements");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pass password = new Pass();
            
            password.ShowPass();

            password -= 'k';

            password.ShowPass();

            password.LengthCheck();

            ++password;

            password.ShowPass();

            Console.ReadLine();
        }
    }
}
