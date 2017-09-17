using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab33
{

    public class Airline
    {
        public static readonly long _sessionId;

        static int _flightQty;

        public const string CompanyName = "Airbus";

        string Destination;  
        string PlaneType;
        string DepatureTime;
        string DayOfTheWeek;


        private Airline()
        { }

        public Airline(string destination, string planeType, string depatureTime, string dayOfTheWeek)
        {
            Destination = destination;
            PlaneType = planeType;
            DepatureTime = depatureTime;
            DayOfTheWeek = dayOfTheWeek;
            Airline._flightQty += 1;
        }

        public Airline(string destination = "MSQ", string depatureTime = "00:00", string dayOfTheWeek = "Mon")
        {
            Destination = destination;
            PlaneType = "PASS 747";
            DepatureTime = depatureTime;
            DayOfTheWeek = dayOfTheWeek;
            Airline._flightQty += 1;
        }

        public string DestinationProp
        {
            get
            {
                return this.Destination;
            }

            set
            {
                Console.WriteLine("Changed destination: ");
                this.Destination = value;
            }
        }

        public string DayOfTheWeekProp
        {
            get
            {
                return this.DayOfTheWeek;
            }
        }

        static Airline()
        {
            _sessionId = DateTime.Now.Ticks;
        }

        public void ReturnQty()
        {
            Console.WriteLine("Flight qty: {0}", _flightQty);
        }

        public void ReturnId()
        {
            Console.WriteLine("Flight ID: {0}", _sessionId);
            Console.WriteLine("\n");
        }

        public void FlightInfo()
        {
            Console.WriteLine("Depature Time: {0}", DepatureTime);
            Console.WriteLine("Day of the week: {0}", DayOfTheWeek);
            Console.WriteLine("Destination: {0}", Destination);
            Console.WriteLine("Plane type: {0}", PlaneType);
            Console.WriteLine("\n");
        }

        public void ClassInfo()
        {
            FlightInfo();
            ReturnId();
            ReturnQty();
        }

        public bool Equals(Airline flight2)
        {
            if(
                (this.Destination == flight2.Destination) &&
                (this.PlaneType == flight2.PlaneType) &&
                (this.DepatureTime == flight2.DepatureTime) &&
                (this.DayOfTheWeek == flight2.DayOfTheWeek)
              )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Airline flight1 = new Airline("NYC", "Airbus 300", "19:00", "Sat");
            flight1.FlightInfo();
            Airline flight2 = new Airline("OSK", "Boeing 777", "12:00", "Sun");
            flight2.FlightInfo();
            Airline flight3 = new Airline("DMD", "Boeing 737", "22:00", "Mon");
            flight3.FlightInfo();

            flight1.DestinationProp = "KMP";
            flight1.FlightInfo();
           
            flight1.ReturnId();
            flight1.ReturnQty();

            Console.WriteLine(flight2.Equals(flight1));

            Console.ReadLine();
        }
    }
}
