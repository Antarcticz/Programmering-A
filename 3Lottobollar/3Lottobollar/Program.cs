using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Lottobollar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] int_vektor; // Skapar en heltals vektor
            int_vektor = new int[10]; // Ger vektorn 10 platser

            Console.WriteLine("==============================");
            Console.WriteLine(" Välkommen till Lotto Spelet!");
            Console.WriteLine("==============================");
            Console.WriteLine(" ");
            Console.WriteLine("Du kommer att få föreslå 10 st siffror från 1 till 25");
            Console.WriteLine(" ");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Skriv in ett tal : ");
                string tal_str = Console.ReadLine(); // Läser in talet som text
                int tal_int = Convert.ToInt32(tal_str); // Omvandlar text talet till ett heltal

                int_vektor[i] = tal_int; // [i] styr platsen och lägger in heltalet på den platsen som den pekar på
            }

            Console.WriteLine(" ");
            Console.WriteLine("Du har skrivit in 10 tal, om du får en * så har du vunnit. Resultatet är: ");
            Console.WriteLine(" ");
            foreach (int plats in int_vektor)
            {
                Console.Write($"{plats} ");
            }
            Console.WriteLine();

            Random randomerare = new Random();
            int random_tal = randomerare.Next(1, 26); // Skapar random tal mellan 1 till 25
                                                      // Console.WriteLine("Random talet är : " + random_tal); // Kollar att randomeraren funkade

            string[] str_vektor;
            str_vektor = new string[10];

            for (int i = 0; i < 10; i++)
            {
                if (int_vektor[i] == random_tal)
                {
                    str_vektor[i] = "*";
                }
                else str_vektor[i] = "-";
            }

            foreach (string plats in str_vektor)
            {
                Console.Write($"{plats} ");
            }
            Console.WriteLine();

            Console.WriteLine(" ");
            Console.WriteLine("Det rätta talet var : " + random_tal);
            Console.WriteLine(" ");
        }
    }
}
