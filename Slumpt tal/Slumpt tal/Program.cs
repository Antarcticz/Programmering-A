using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slumpt_tal
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomerare = new Random();
            int slump_tal = randomerare.Next(1, 101);
            int varv = 0; // Variabel som håller reda på varv
            do
            {
                slump_tal = randomerare.Next(1, 101);
                varv++; // Ökar värdet på varv med ett (1)
                Console.Write("Nu är vi på varv " + varv + " och talet är : ");
                Console.WriteLine(slump_tal);
                if (slump_tal > 90)
                {
                    Console.WriteLine("Talet är över 90");
                }
                else if (slump_tal < 10)
                {
                    Console.WriteLine("Talet är under 10");
                }
                else
                {
                    Console.WriteLine("Talet är mellan 10 och 90");
                }
            } while (slump_tal >= 10 && slump_tal <= 90);

            Console.WriteLine("Nu vet vi att talet är under 10 eller över 90");
           // Console.Write("Press any key to continue...");
           // Console.ReadKey(true);

            
            /*
            ==  Jämförelse. Lika med.
            !=  Skiljt från. Inte lika med.
            !   Invertering (NOT)
            <   Mindre än
            >   Större än
            <=  Mindre eller lika med.
            >=  Större eller lika med.
            &&  OCH (AND) för att kombinera fler villkor.
            ||  ELLER (OR) för att kombinera flera villkor.*/

            // Undvik helt att använda bool variablar och break.
        }
    }
}
