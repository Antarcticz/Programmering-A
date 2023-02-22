/*2016-05-12
Detta kodskal kan upplevas väldigt omfattande. Om ni vill använda det så börja med att kopiera över koden till er utvecklingsmiljö som SharpDevelop.
Var noggranna med att "namespace" är samma. Det enklaste är att ni startar ett nytt projekt som heter "sodacrate" som sedan kopierar över rubbet
Därefter kan ni ta bort alla metoder ni inte ska jobba med samt skala bort kommentarer när ni läst dom.

*/


/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 */
using System;

namespace sodacrate
{
    /*public struct Soda 
    {
       Siktar ni mot specifikt betyget C och inte vill göra en egen klass av Soda så kan det fungera bra med en struct istället som ni definierar här
       Den kan då tre olika värden för namn, pris, och dryckestyp. Då blir hela projektet roligare - såsom sortering och uträkning av pris
     * Denna struct del bortser ni ifrån helt om ni inte vill jobba med detta och då alltså specifikt för betyget C 
    }*/

    class Sodacrate
    {
        private string[] flask_vektor = new string[25]; //JObbar ni med struct (ev betyg C) eller klass för soda (betyg A) så är det inte "string" som är datatyp här
        private int flask_pos = 0; //Håller reda på antal flaskor
        

        //(Betyg A): En konstruktor kan ni använda för Sodacrate men det är inget krav.
        //(Betyg A): Däremot ska ni använda en konstruktor för klassen "Soda"

        public void Run()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("     Välkommen till Läskmaskinen");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine(" ");



            //Här ska menyn ligga för att göra saker
            //Jag rekommenderar switch och case här med en loop
            //I del 1 av filmerna för slutprojektet kodar jag en switch case

            int avbryt_nr = 0;
            
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("=======================================================================================================================");
                Console.WriteLine("Alternativ : ");
                Console.WriteLine(" ");
                Console.WriteLine("[1] Ladda backen med läsk");
                Console.WriteLine("[2] Visa vad som finns i backen");
                Console.WriteLine("[3] Visa total kostnad");
                Console.WriteLine("[4] Sök efter en speciell läsk i backen");
                Console.WriteLine("[5] Sortera läskeflaskornas ordning i backen");
                Console.WriteLine("[6] Genomför köpet");
                Console.WriteLine("[7] Avbryta köpet");
                Console.WriteLine("=======================================================================================================================");
                Console.WriteLine(" ");
                Console.Write("Vad vill du göra? Ange nr : ");
                string str_alt = Console.ReadLine();
                int int_alt = Convert.ToInt32(str_alt);
                switch (int_alt)
                {
                    case 1:
                        Console.WriteLine("Du har valt alternativ 1 : Ladda backen med läsk");

                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("Läsk Meny : ");
                        Console.WriteLine(" ");
                        Console.WriteLine("[1] Coca-Cola 5 kr");
                        Console.WriteLine("[2] Coca-Cola Light 5 kr");
                        Console.WriteLine("[3] Fanta 5 kr");
                        Console.WriteLine("[4] Sprite 5 kr");
                        Console.WriteLine("[5] Hallon Soda 5 kr");
                        Console.WriteLine("[6] Socker Dricka 5 kr");
                        Console.WriteLine("[7] Mineral Vatten 5 kr");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine(" ");
                        int platser_kvar = 25 - flask_pos;
                        Console.WriteLine("Hur många flaskor vill du lägga i backen? (Max 25 st) Observera du har " + platser_kvar + " platser kvar i backen");
                        Console.WriteLine(" ");
                        string str_max = Console.ReadLine();
                        int int_max = Convert.ToInt32(str_max);
                        for (int i = 0; i < int_max; i++)
                        {
                            Add_soda();
                            flask_pos = flask_pos + 1;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Du har valt alternativ 2 : Visa vad som finns i backen");
                        Print_crate();
                        break;

                    case 3:
                        Console.WriteLine("Du har valt alternativ 3 : Visa total kostnad");
                        Calc_total();
                        break;

                    case 4:
                        Console.WriteLine("Du har valt alternativ 4 : Sök efter en speciell läsk i backen");
                        Find_soda();
                        break;

                    case 5:
                        Console.WriteLine("Sortera läskeflaskornas ordning i backen");
                        Sort_sodas();
                        break;

                    case 6:
                        Console.WriteLine("Du har valt alternativ 6 : Du har valt att genomföra köpet");
                        Calc_total();
                        Console.WriteLine("Beloppet dras från ditt kort");
                        Console.WriteLine("Välkommen åter");
                        avbryt_nr = 6;
                        break;

                    case 7:
                        Console.WriteLine("Du har valt alternativ 7 : Du har valt att avbryta köpet");
                        Console.WriteLine("Välkommen åter");
                        avbryt_nr = 7;
                        break;
                }
            } while (avbryt_nr != 6 && avbryt_nr != 7);



        }

        public void Add_soda()
        {
            /*Metod för att lägga till en läskflaska
			Om ni har information om både pris, läsktyp och namn
			kan det vara läge att presentera en meny här där man kan
			välja på förutbestämda läskflaskor. Då kan man också rätt enkelt
			göra ett val för att fylla läskbacken med slumpade flaskor
			*/

            

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

        public void Print_crate()
        {
            //kod här
            //Missa inte hjälpkoden som finns i projektbeskrivningen
            //Där beskrivs hur man löser det med tomma positioner i vektorn

            Console.WriteLine(" ");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Backens innehäll är : ");
            Console.WriteLine(" ");
            foreach (var plats in flask_vektor)
            {
                if (plats != null)
                    Console.WriteLine(plats);
                else
                    Console.WriteLine("[_]");
            }
        }

        public void Calc_total()
        {
            //kod här
            //Tänk på att inte räkna med tomma positioner i vektorn

            int totalkostnad = flask_pos * 5; //Den nya variabeln totalkostnad får värdet av flask_pos gånger 5 kr
            Console.WriteLine("Total kostnaden är : " + totalkostnad + " kr");
        }

        public void Find_soda()
        {
            //Betyg C
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)
            //Man ska kunna söka efter ett namn
            //Man kan använda string-metoderna ToLower() eller ToUpper()

            Console.WriteLine("Vilket läsk namn söker du efter? ");
            string str_söktnamn = Console.ReadLine();
            Console.WriteLine(" ");
            int j = 99;

            for (int i = 0; i < flask_vektor.Length; i++)  //Gå igenom hela listan
            {
                if (flask_vektor[i] == str_söktnamn)
                {
                    Console.WriteLine(str_söktnamn + " finns på plats : " + i); //Har tagit bort break; för att jag vill söka igenom hela vektorn om det finns fler av den sökta läsken
                    j = i;
                    //Console.WriteLine("j är : " + j); Användes bara för att se hur j fungerade
                }
            }

            if (j == 99)
            {
                Console.WriteLine(str_söktnamn + " Finns inte i din back");
            }
             

            
        }

        public void Sort_sodas()
        {
            //Betyg A-C
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
            //Man ska kunna sortera vektorn med flaskor och med bubble sort
            //Det är mycket svårt att sortera efter bokstavsordning - är inte flaskorna egna objekt utan bara strängar...
            //... går det bra att sortera efter längden på namnet istället.
            Console.WriteLine("!ERROR OUT OF ORDER ERROR!");
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
