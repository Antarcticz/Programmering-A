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
            Lastbil _lastbil1 = new Lastbil(1, 1800, 3, 2.5, "Carbon Black", 3);
            _lastbil1.Print();
            Fordon _fordon = (Fordon)_lastbil1;
            _fordon.Print();

            Lastbil _lastbil2 = new Lastbil(2, 2500, 3, 2.5, "Blå", 5);
            _lastbil2.Print();
            Fordon _fordon2 = (Fordon)_lastbil2;
            _fordon2.Print();



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
    public class Fordon // SuperClass
    {
        protected int id;
        protected double horsepowers, hight, width;
        protected string color;

        public Fordon(int id, double horsepowers, double hight, double width, string color)  // Instance constructor
        {
            this.id = id;
            this.horsepowers = horsepowers;
            this.hight = hight;
            this.width = width;
            this.color = color;
        }

        public virtual double Calc_Topspeed(double _horsepowers, double _hight, double _width)
        {
            //double horsepowers = 1200;
            //double hight = 2.378;
            //double width = 1;
            double front_area = hight*width;
            double watt = horsepowers*754.7;
            double hastighet_ms = Math.Pow((2*watt)/(front_area*0.36*1.225), 0.3333333333);  // 0.36 is a constant, 1.225 is in kg/m*m*m standard air
            double hastighet_kmh = hastighet_ms*3.6;
            return hastighet_kmh;
            //Console.WriteLine("hastighet m/s : " + hastighet_ms);
            
        }

        public override string ToString()
        {
            return string.Format("");
        }

        /*public void Add()
        {

        }

        public virtual void Action()
        {

        }*/

        public void Print()
        {
            Console.WriteLine("Specifications: ");
            Console.WriteLine("ID: {0} | Horsepowers: {1} | Hight: {2} | Width: {3} | Color: {4}", id, horsepowers, hight, width, color);
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS LASTBIL
      =======================================================================================================================================================================================================*/
    public class Lastbil : Fordon  // SubClass
    {
        protected double weight;

        public Lastbil(int id, double horsepowers, double hight, double width, string color) : base(id, horsepowers, hight, width, color)  // Instance constructor
        {
        }

        public Lastbil(int id, double horsepowers, double hight, double width, string color, int weight) :this (id, horsepowers, hight, width, color)  // Instance constructor with extra parameter
        {
            Console.WriteLine("Weight (ton): {0}", weight);
        }

        public override string ToString()
        {
            return string.Format("Truck weight (ton): {0}", weight);
        }

        public void Multiply()
        {

        }

        /*public override void Action()
        {

        }*/

        public new void Print()
        {
            //Console.WriteLine("Truck");
        }
    }
}
