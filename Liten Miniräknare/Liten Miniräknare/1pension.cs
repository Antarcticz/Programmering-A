using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liten_Miniräknare
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variabel definition
            string förnamn;
            string efternamn;
            string ålder_str;
            int ålder_int;
            int svar;

            // Inläsning från skärm
            Console.WriteLine("Pension");
            Console.WriteLine("Skriv in ditt förnamn : ");
            förnamn = Console.ReadLine();
            Console.WriteLine("Skriv in ditt efternamn : ");
            efternamn = Console.ReadLine();
            Console.WriteLine("Skriv in din ålder : ");
            ålder_str = Console.ReadLine();
            ålder_int = int.Parse(ålder_str);

            // TODO: Uträkning
            svar = 65 - ålder_int;
            Console.WriteLine("Hej " + förnamn + " " + efternamn + "! " + "Det är nu " + svar + " år kvar tills du går i pension.");
        }
    }
}
