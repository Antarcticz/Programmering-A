using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 8;
            if (a == 6)
                a = 8;
            else if (a == 8)
                a = 2;
            else if (a == 2)
                a = 1000000;
            Console.WriteLine("a is " + a);
        }
    }
}
