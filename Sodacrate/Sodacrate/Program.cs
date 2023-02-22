



using System;

namespace sodacrate
{
    class Sodacrate
    {
        private string[] flask_vektor = new string[25]; // Skapar flask_vektor med maximalt 25 flaskor, från position 0-24
        private int flask_pos = 0; //Håller reda på antal flaskor i backen
        
        public void Run()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("|     Välkommen till Läskmaskinen                                                                                     |");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("| Alternativ :                                                                                                        |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("| [1] Ladda backen med läsk                                                                                           |");
            Console.WriteLine("| [2] Visa vad som finns i backen                                                                                     |");
            Console.WriteLine("| [3] Visa total kostnad                                                                                              |");
            Console.WriteLine("| [4] Sök efter en speciell läsk i backen                                                                             |");
            Console.WriteLine("| [5] Sortera läskeflaskornas ordning i backen                                                                        |");
            Console.WriteLine("| [6] Genomför köpet                                                                                                  |");
            Console.WriteLine("| [7] Avbryta köpet                                                                                                   |");
            Console.WriteLine("| [8] Visa menyn igen                                                                                                 |");

            
            int avbryt_nr = 0; // abryt_nr får ett värde som inte är 6 eller 7. Vilket gör att do/while loopen kan loopa hur många varv som helst genom case/switch menyn, tills meny val nr 6 eller 7 väljs
            int int_alt = 99; // int_alt deffineras här och får vilken siffra som helst, för att try/catch och switch/case ska fungera.

            do
            {
                try
                {
                    Console.WriteLine("=======================================================================================================================");
                    Console.Write("Vad vill du göra? Ange en siffra 1-8 | [8] = Meny | [Enter] = Upprepa senaste val : ");
                    int_alt = int.Parse(Console.ReadLine());
                }
                catch
                {
                    //Console.WriteLine("Error, skriv in ett heltal 1-8");
                }
                //Console.Write("Vad vill du göra? Ange nr : ");
                // int int_alt = int.Parse(Console.ReadLine());

                switch (int_alt)
                {
                    case 1:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 1 : Ladda backen med läsk                                                                       ");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("| Läsk Meny :                                                                                                         |");
                        Console.WriteLine("|                                                                                                                     |");
                        Console.WriteLine("| [1] Coca-Cola 5 kr                                                                                                  |");
                        Console.WriteLine("| [2] Coca-Cola Light 5 kr                                                                                            |");
                        Console.WriteLine("| [3] Fanta 5 kr                                                                                                      |");
                        Console.WriteLine("| [4] Sprite 5 kr                                                                                                     |");
                        Console.WriteLine("| [5] Hallon Soda 5 kr                                                                                                |");
                        Console.WriteLine("| [6] Socker Dricka 5 kr                                                                                              |");
                        Console.WriteLine("| [7] Mineral Vatten 5 kr                                                                                             |");
                        Console.WriteLine("=======================================================================================================================");
                        int platser_kvar = 25 - flask_pos; // Flask position pekar på den första tomma plattsen i vektorn och den är totalt antal flaskor i backen
                        Console.WriteLine("Hur många flaskor vill du lägga i backen? (Max 25 st) Observera du har " + platser_kvar + " platser kvar i backen");
                        string str_max = Console.ReadLine();
                        int int_max = Convert.ToInt32(str_max);
                        for (int i = 0; i < int_max; i++) // Loopar från vektor position 0 till int_max (som inehåller antalet flaskor man angivit att lägga i backen. Om i < flask_vektor.Lenght då hade i som störst blivit 24
                        {
                            Add_Soda();
                            flask_pos = flask_pos + 1; // Flask position startar på 0. Den plussas på med 1 varje gång en flaska lägs i backen. På så sätt kan man bara gångra flask_pos med 5 kr för att få totalkostnad
                        }
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 2 : Visa vad som finns i backen");
                        Print_Crate();
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 3 : Visa total kostnad");
                        Console.WriteLine(" ");
                        Calc_Total();
                        break;

                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 4 : Sök efter en speciell läsk i backen");
                        Console.WriteLine(" ");
                        Find_Soda();
                        break;

                    case 5:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 5 : Sortera läskeflaskornas ordning i backen");
                        Console.WriteLine(" ");
                        Sort_Soda();
                        Console.WriteLine("Backen har nu blivit sorterad efter längden på läskens namn");
                        Console.WriteLine(" ");
                        Console.WriteLine("Välj alternativ [2] om du vill se vad som finns i backen");
                        break;

                    case 6:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 6 : Du har valt att genomföra köpet");
                        Console.WriteLine(" ");
                        Calc_Total();
                        Console.WriteLine("Beloppet dras från ditt kort");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("|     Välkommen åter                                                                                                  |");
                        Console.WriteLine("=======================================================================================================================");
                        avbryt_nr = 6; 
                        break;

                    case 7:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 7 : Du har valt att avbryta köpet");
                        Console.WriteLine(" ");
                        Console.WriteLine("Köpet avbryts");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("|     Välkommen åter                                                                                                  |");
                        Console.WriteLine("=======================================================================================================================");
                        avbryt_nr = 7;
                        break;

                    case 8:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 8 : Visa menyn igen");
                        Menu_Show();
                        break;

                    default:
                        //Console.WriteLine("Du skrev in en siffra, men den måste vara 1-7");
                        break;
                }
            } while (avbryt_nr != 6 && avbryt_nr != 7); // case 6 och 7 avbryter loopen
        }

        public void Add_Soda()
        {
            Console.WriteLine(" ");
            Console.Write("Ange läskedrycks nr : ");
            string str_nr = Console.ReadLine();
            int int_nr = Convert.ToInt32(str_nr);
            switch (int_nr)
            {
                case 1:
                    //Console.WriteLine("Du har valt läsk nr 1 : Coca-Cola");
                    flask_vektor[flask_pos] = "Coca-Cola";
                    break;
                    
                case 2:
                    //Console.WriteLine("Du har valt läsk nr 2 : Coca-Cola Light");
                    flask_vektor[flask_pos] = "Coca-Cola Light";
                    break;

                case 3:
                    //Console.WriteLine("Du har valt läsk nr 3 : Fanta");
                    flask_vektor[flask_pos] = "Fanta";
                    break;

                case 4:
                    //Console.WriteLine("Du har valt läsk nr 4 : Sprite");
                    flask_vektor[flask_pos] = "Sprite";
                    break;

                case 5:
                    //Console.WriteLine("Du har valt läsk nr 5 : Hallon Soda");
                    flask_vektor[flask_pos] = "Hallon Soda";
                    break;

                case 6:
                    //Console.WriteLine("Du har valt läsk nr 6 : Socker Dricka");
                    flask_vektor[flask_pos] = "Socker Dricka";
                    break;

                case 7:
                    //Console.WriteLine("Du har valt läsk nr 7 : Mineral Vatten");
                    flask_vektor[flask_pos] = "Mineral Vatten";
                    break;       
            }
        }

        public void Print_Crate()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("Backens innehåll är : ");
            Console.WriteLine(" ");
            foreach (var plats in flask_vektor)
            {
                if (plats != null)
                    Console.WriteLine(plats); // Om plats inte är null så skrivs flask namnet ut
                else
                    Console.WriteLine("[_]"); 
            }
        }

        public void Calc_Total()
        {
            int totalkostnad = flask_pos * 5; //Den nya variabeln totalkostnad får värdet av flask_pos gånger 5 kr
            Console.WriteLine("Total kostnaden är : " + totalkostnad + " kr");

            
        }

        public void Find_Soda()
        {
            Console.WriteLine("[Coca-Cola] [Coca-Cola Light] [Fanta] [Sprite] [Hallon Soda] [Socker Dricka] [Mineral Vatten]");
            Console.WriteLine(" ");
            Console.WriteLine("Vilket läsk namn söker du efter? ");
            string str_söktnamn = Console.ReadLine();
            Console.WriteLine(" ");
            int j = 99; // Den nya heltals variabeln j får värdet 99 som inte är en position i backen. Om sökt namn finns i backen, så får j ett nytt värde som är positionen på den sökta läsken. Så efter for loopen, om j fortfarande har värdet 99 så fanns inte sökt läsk i backen och då kan det skrivas ut

            for (int i = 0; i < flask_vektor.Length; i++)  //Gå igenom hela listan
            {
                if (flask_vektor[i] == str_söktnamn)
                {
                    Console.WriteLine(str_söktnamn + " finns på plats : " + i); //Har tagit bort break; för att jag vill söka igenom hela vektorn om det finns fler av den sökta läsken
                    j = i;
                    //Console.WriteLine("j är : " + j); //Användes bara för att se hur j fungerade
                }
            }

            if (j == 99)
            {
                Console.WriteLine(str_söktnamn + " Finns inte i din back");
            }  
        }

        public void Sort_Soda()
        {
            //string[] flask_vektor = new string[] { "aa", "o", "bb", "ddd", "k" }; // Skapar en kort lista, för att se hur koden fungerar

            int max = flask_pos - 1; // Den pekar på den pekar på första tomma plattsen i vektorn, dvs den är antal flaskor i backen

            // Den yttre loopen, går igenom hela listan
            for (int i = 0; i < max; i++)
            {
                // >Den inre, går igenom element för element
                int nrLeft = max - i; // För att se hur många som redan gåtts
                                      // igenom
                for (int j = 0; j < nrLeft; j++)
                {
                    if (flask_vektor[j].Length > flask_vektor[j + 1].Length) // Jämför läsknamnens längd mellan två närliggande positioner
                    {
                        // Byt plats!
                        string temp = flask_vektor[j];
                        flask_vektor[j] = flask_vektor[j + 1];
                        flask_vektor[j + 1] = temp;
                    }
                }
            }
            
            // Skriv ut listan
            //for (int i = 0; i < flask_vektor.Length; i++)
                //Console.WriteLine(flask_vektor[i]);
        }

        public void Menu_Show()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("| Alternativ :                                                                                                        |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("| [1] Ladda backen med läsk                                                                                           |");
            Console.WriteLine("| [2] Visa vad som finns i backen                                                                                     |");
            Console.WriteLine("| [3] Visa total kostnad                                                                                              |");
            Console.WriteLine("| [4] Sök efter en speciell läsk i backen                                                                             |");
            Console.WriteLine("| [5] Sortera läskeflaskornas ordning i backen                                                                        |");
            Console.WriteLine("| [6] Genomför köpet                                                                                                  |");
            Console.WriteLine("| [7] Avbryta köpet                                                                                                   |");
            Console.WriteLine("| [8] Visa menyn igen                                                                                                 |");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Sodacrate som heter sodacrate
            var sodacrate = new Sodacrate();
            sodacrate.Run();
            //Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
        }
    }
}
