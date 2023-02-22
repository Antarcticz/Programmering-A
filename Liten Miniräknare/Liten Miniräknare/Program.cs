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
            string inmatning;
            int tal1;
            int tal2;
            int summa;
            Console.WriteLine("Liten Miniräknare");
            Console.WriteLine("Skriv in tal 1 : ");
            inmatning = Console.ReadLine();
            tal1 = int.Parse(inmatning);
            Console.WriteLine("Skriv in tal 2 : ");
            inmatning = Console.ReadLine();
            tal2 = int.Parse(inmatning);
            // TODO: Implement Functionality Here
            summa = tal1 + tal2;
            Console.WriteLine("Tal 1 är " + tal1 + " och tal 2 är " + tal2 + ". Summan är " + summa);
        }
    }
}
