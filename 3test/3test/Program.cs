using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Lisa", "Sara", "Kalle", "Sven" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            int[] numbers = { 3, 14, 15, 92, 6 };
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            int[,] coords = new int[3, 3];
            coords[0, 0] = 1;
            coords[0, 1] = 7;
            coords[0, 2] = 3;
            coords[1, 0] = 8;
            coords[1, 1] = 5;
            coords[1, 2] = 9;
            coords[2, 0] = 4;
            coords[2, 1] = 6;
            coords[2, 2] = 2;

            foreach (int number in coords)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
