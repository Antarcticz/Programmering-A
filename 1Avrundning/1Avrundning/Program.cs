using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Avrundning
{
    class Program
    {
        static void Main(string[] args)
        {
            int dec_int;
            string dec_string;
            string tal_string;
            double tal_double;
            double tal_dec3;
            double tal_dec_;

            Console.WriteLine("Skriv in ett decimaltal : ");
            tal_string = Console.ReadLine();
            tal_double = double.Parse(tal_string); // Decimaltalet som är en textsträng omvandlas till ett decimaltal av double

            Console.WriteLine("Skriv in antal decimaler du vill ha : ");
            dec_string = Console.ReadLine();
            dec_int = int.Parse(dec_string); // Har läst in antal decimaler i en textsträng och sen omvandlar textsträngen till en variabel av heltals typ

            tal_dec3 = Math.Round((Double)tal_double, 3);
            tal_dec_ = Math.Round((Double)tal_double, dec_int);

            Console.WriteLine("Ditt resultat är : " + tal_dec_);
            Console.WriteLine("Resultat med 3 decimaler : " + tal_dec3);

        }
    }
}