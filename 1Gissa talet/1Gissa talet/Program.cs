using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Gissa_talet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Denna kod skriver ut "Welcome!" i ett konsolfönster och bakgrundfärg blå
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome!");
            Random randomerare = new Random();
            int random_tal = randomerare.Next(1, 101);
            int tal_int;
            do
            {
                Console.Write("Guess the number:");
                string tal_str = Console.ReadLine();
                tal_int = Convert.ToInt32(tal_str);
                if (tal_int < random_tal)
                {
                    Console.WriteLine("It's too low " + tal_int);
                }
                
                else if (tal_int > random_tal)
                {
                    Console.WriteLine("It's too high " + tal_int);
                }
                else Console.WriteLine("Congratulations you guessed the correct number : " + random_tal);

            } while (tal_int < random_tal || tal_int > random_tal); // Den loopar om talet inte är random talet
        }
    }
}
