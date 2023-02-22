using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bastun
{
    class Program
    {
        public static double FahrToCels(int input_fahr) // Läser in ett fahrenheit heltal i variablen input_fahr
        {
            double output_cel = (input_fahr - 32) * 5 / 9; // Ränkar ut celsius ifrån fahrenheit och lagrar i den nya variabeln output_cel som har decimaler
            return output_cel; // Metoden ger tillbaka graden celsius lagrat i output_cel
                               // Variablerna input_fahr och output_cel existerar bara innuti metoden och ingenstans utanför metoden
        }

        public static void Main(string[] args)
        {
            double celsius;
            do
            {
                
                try // Om inte ett heltal matas in så fångas det i catch
                {
                    Console.WriteLine(" "); // Skapar ett radavstånd innan man börjar om och väljer temperatur
                    Console.WriteLine("Choose the temperature in fahrenheit for the sauna : ");
                    int fahrenheit = int.Parse(Console.ReadLine()); // Läser in från kontrollpanelen och omvandlar direkt från string till integer
                    celsius = FahrToCels(fahrenheit); // Beräknar celsius från fahrenheit via en metod
                    Console.WriteLine("You have choosen the temperature : " + fahrenheit);
                    int celsius_cut;
                    celsius_cut = (int)celsius; // Funktionen (int)celsius klipper bort decimalerna från celsius och lagrar heltals delen i celsius_cut
                    Console.WriteLine("In celsius this is : " + celsius_cut); // Används endast för att snygga till resultatet på kontrollpanelen

                    if (celsius < 10)
                    {
                        Console.WriteLine("This is not a refrigerator it is a sauna, request denied");
                    }
                    else if (celsius < 73)
                    {
                        Console.WriteLine("Denied temperature is too low");
                    }
                    else if (celsius == 75)
                    {
                        Console.WriteLine("Exellent choice this is optimal temperature, request accepted");
                    }
                    else if (celsius >= 73 && celsius <= 77)
                    {
                        Console.WriteLine("Temperature is valid, request accepted");
                    }
                    else if (celsius > 77 && celsius < 200)
                    {
                        Console.WriteLine("Denied temperature is too high");
                    }
                    else Console.WriteLine("This is not a oven it is a sauna, request denied");

                }
                catch
                {
                    Console.WriteLine("Error, please write a temperature");
                    celsius = 1; // Tilldelar ett slask nummber så att while loopen fungerar
                }
            } while (celsius < 73 || celsius > 77); // Den loopar om celsius inte är mellan 73 till 77 grader
        }
    }
}
