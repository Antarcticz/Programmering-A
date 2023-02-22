using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Denna kod skriver ut "Vatten Kokarn" i ett konsolfönster och bakgrundfärg blå
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Temperature Game");
            // Console.ReadKey(true); // Så att inte programmet direkt stängs
            
            bool myBool = false;
            while (myBool == false) // while (true)
            {
                Console.Write("Guess the Temperature:");
                string str = Console.ReadLine();
                int temperature = Convert.ToInt32(str);
                if (temperature == 1337)
                {
                    Console.WriteLine("Congratulations you have the right answer! The temperature is " + temperature);
                    myBool = true; // Break;
                }
                else if (temperature > 300 && temperature <= 1000) // If the temperature is 301-1000
                {
                    Console.WriteLine("It is too low");
                }
                else if (temperature > 1000 && temperature <= 1300) // If the Temperature is 1001-1300 
                {
                    Console.WriteLine("You are getting close, the temperature is slightly higher");
                }
                else if (temperature > 1300 && temperature <= 1336) // If the Temperature is 1301-1336
                {
                    Console.WriteLine("You are soo close!");
                }
                else if (temperature > 1337 && temperature < 1500) // If the Temperature is 1338-1499
                {
                    Console.WriteLine("Your are slightly too high");
                }
                else if (temperature >= 1500) // If the Tempature is 1500 or above 1500
                {
                    Console.WriteLine("You are way too high!");
                }
                else
                {
                    Console.WriteLine("Your are useless at this, it is a lot higher"); // If the temperature is 300 or lower
                }
            } // End of while loop
        }
    }
}
