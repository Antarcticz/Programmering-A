using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Fordon
{
    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PROGRAM
      =======================================================================================================================================================================================================*/
    class Program
    {
        static void Main(string[] args)
        {
            Lastbil _lastbil1 = new Lastbil(1, 600, 3.5, 2.5, 2, "Carbon Black", 0);
            Console.WriteLine(_lastbil1);                              // Prints the ToString() from class Lastbil
            _lastbil1.PrintDetails();
            Fordon _fordon1 = (Fordon)_lastbil1;

            Lastbil _lastbil2 = new Lastbil(2, 600, 3.5, 2.5, 2, "Metalic Blue", 2);
            Console.WriteLine(_lastbil2);                              // Prints the ToString() from class Lastbil
            _lastbil2.PrintDetails();
            Fordon _fordon2 = (Fordon)_lastbil2;

            Bil _bil3 = new Bil(3, 1160, 1.12, 2.05, 1.395, "White/Carbon Black/Blue", 2, "Koenigsegg Agera RS1");
            Console.WriteLine(_bil3);                                  // Prints the ToString() from class Bil
            _bil3.PrintDetails();
            Fordon _fordon3 = (Fordon)_bil3;
            //_fordon3.PrintDetails();

            
            //private List<Lastbil> lastbil_list = new List<Lastbil>();

            /*public void AddLastbil(string name)
            {
                lastbil_list.Add(new Lastbil(name));
            }*/
            

            /*double horsepower = 1200;
            double hight = 2.378;
            double width = 1;
            double front_area = hight*width;
            double watt = horsepower*754.7;
            double hastighet_ms = Math.Pow((2*watt)/(front_area*0.36*1.225), 0.3333333333);
            double hastighet_kmh = hastighet_ms*3.6;
            Console.WriteLine("hastighet m/s : " + hastighet_ms);
            Console.WriteLine("hastighet km/h : " + hastighet_kmh);*/

            /*SuperClass super = new SuperClass();
            super.Print();*/
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS FORDON
      =======================================================================================================================================================================================================*/
    public abstract class Fordon // SuperClass
    {
        protected int id;
        protected double horsepowers, hight, width, weight;
        protected string color;

        public Fordon(int id, double horsepowers, double hight, double width, double weight, string color)  // Instance constructor
        {
            this.id = id;
            this.horsepowers = horsepowers;
            this.hight = hight;
            this.width = width;
            this.weight = weight;
            this.color = color;
        }

        public virtual double Calc_Topspeed()  // Can override (virtual) but dont have to (abstract)
        {
            double front_area = hight*width;
            double watt = horsepowers*754.7;
            double hastighet_ms = Math.Pow((2*watt)/(weight*front_area*0.36*1.225), 0.3333333333);  // 0.36 is a constant, 1.225 is in kg/m*m*m standard air
            double hastighet_kmh = hastighet_ms*3.6;
            double kmh = Math.Round((Double)hastighet_kmh, 0);
            return kmh;
        }

        public abstract void PrintDetails();

        public override string ToString()
        {
            return string.Format("Vehicle Specifications");
        }


        

        /*public void Add()
        {

        }

        public virtual void Action()
        {

        }

        public void Print()
        {
            Console.WriteLine("Specifications: ");
            Console.WriteLine("ID: {0} | Horsepowers: {1} | Hight: {2} m | Width: {3} m | Weight: {4} ton | Color: {5}", id, horsepowers, hight, width, weight, color);
            Console.WriteLine("Topspeed is: {0} km/h", Calc_Topspeed());
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine("");
        }*/
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS LASTBIL
      =======================================================================================================================================================================================================*/
    public class Lastbil : Fordon  // SubClass
    {
        protected double cargo_weight;

        public Lastbil(int id, double horsepowers, double hight, double width, double weight, string color) : base (id, horsepowers, hight, width, weight, color)  // Instance constructor
        {
        }

        public Lastbil(int id, double horsepowers, double hight, double width, double weight, string color, double cargo_weight) : this (id, horsepowers, hight, width, weight, color)  // Instance constructor with extra parameter cargo_weight
        {
            Console.WriteLine("Truck");
            Console.WriteLine("Cargo Weight: {0} ton", cargo_weight);
            Console.WriteLine("");
        }

        public override double Calc_Topspeed()
        {
            double front_area = hight * width;
            double watt = horsepowers * 754.7;
            double hastighet_ms = Math.Pow((2*watt)/((weight+cargo_weight)*front_area*0.36*1.225), 0.3333333333);  // 0.36 is a constant, 1.225 is in kg/m*m*m standard air
            double hastighet_kmh = hastighet_ms * 3.6;
            double kmh = Math.Round((Double)hastighet_kmh, 0);
            return kmh;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Specifications: ");
            Console.WriteLine("ID: {0} | Horsepowers: {1} | Hight: {2} m | Width: {3} m | Weight: {4} ton | Color: {5}", id, horsepowers, hight, width, weight, color);
            Console.WriteLine("Topspeed is: {0} km/h", Calc_Topspeed());
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return string.Format("Truck Specifications Cargo Weight: {0} ton", cargo_weight);
        }

        /*public void Multiply()
        {

        }

        /*public override void Action()
        {

        }

        public new void Print()
        {
            //Console.WriteLine("Truck");
        }*/
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS BIL
      =======================================================================================================================================================================================================*/
    public class Bil : Fordon  // SubClass
    {
        protected int seats;
        protected string model;

        public Bil(int id, double horsepowers, double hight, double width, double weight, string color) : base(id, horsepowers, hight, width, weight, color)  // Instance constructor
        {
        }

        public Bil(int id, double horsepowers, double hight, double width, double weight, string color, int seats, string model) : this(id, horsepowers, hight, width, weight, color)  // Instance constructor with extra parameter seats
        {
            Console.WriteLine("Car Model: {0}", model);
            Console.WriteLine("Nr of Seats: {0}", seats);
            Console.WriteLine("");
        }

        public override void PrintDetails()
        {
            Console.WriteLine("Specifications: ");
            Console.WriteLine("ID: {0} | Horsepowers: {1} | Hight: {2} m | Width: {3} m | Weight: {4} ton | Color: {5}", id, horsepowers, hight, width, weight, color);
            Console.WriteLine("Topspeed is: {0} km/h", Calc_Topspeed());
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return string.Format("Car Model: {0} with {1} Seats", model, seats);
        }
    }
}
