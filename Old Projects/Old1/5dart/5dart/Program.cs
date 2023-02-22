using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _5dart
{

    /*===============================================================================================================================
                                                                   CLASS PROGRAM
      ===============================================================================================================================*/
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Game My_Game = new Game();
            My_Game.Play_Game();
        }
    }

    /*===============================================================================================================================
                                                                   CLASS GAME
      ===============================================================================================================================*/
    class Game
    {
        public List<Player> player_list = new List<Player>();

        public void Play_Game()
        {
            //int players = 1;
            int round = 1;
            //int max_players = 0;
            //bool int_player = false;
            Random random_nr = new Random();
            int arrow1;
            int arrow2;
            int arrow3;
            /*Console.WriteLine("========================================================================================================================");
            Console.WriteLine("                                          =--> =--> =--> =--> =--> =--> =-->");
            Console.WriteLine("                                         | Welcome to the Awesome Dart Game |");
            Console.WriteLine("                                          <--= <--= <--= <--= <--= <--= <--=");
            Console.WriteLine("");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("How many players do you want to register?");*/

            //while (!int_player)
            //{
            //    try
            //    {
            //        max_players = int.Parse(Console.ReadLine());
            //        int_player = true;
            //    }     // Convert string from Console to int
            //    catch (System.FormatException e)
            //    {
            //        Console.WriteLine("Error, write a number between 1-8.");
            //        int_player = false;
            //        Console.WriteLine("How many players do you want to register?");
            //    }
            //}
            //Console.WriteLine("");

            //do
            //{
            //    string str_name = "";
            //    players++;

            //    Console.WriteLine("Choose player name or press [Enter] for Guest: ");
            //    str_name = Console.ReadLine();

            //    if (str_name == "")                                // If no player name is Enterd on the console, the player will be added with the name "Guest"
            //        AddPlayer("Guest");

            //    else AddPlayer(str_name);

            //} while (players <= max_players);

            //Console.WriteLine("\n========================================================================================================================");
            //foreach (var i in player_list)
            //{
            //    Console.WriteLine(i);                              // Prints the ToString() from class Player
            //}
            //Console.WriteLine("\n========================================================================================================================");

            do
            {
                bool aim_good = Aim_Result();
                round++;
                foreach (var i in player_list)
                {
                    if (aim_good == true)
                    {
                        arrow1 = random_nr.Next(10, 21);
                        arrow2 = random_nr.Next(10, 21);               // Darts get random point from 10 - 20
                        arrow3 = random_nr.Next(10, 21);
                    }
                    else                                               // (aim_good == false)
                    {
                        arrow1 = random_nr.Next(0, 11);
                        arrow2 = random_nr.Next(0, 11);                // Darts get random point from 0 - 10
                        arrow3 = random_nr.Next(0, 11);
                    }
                    i.Add_Turn(arrow1, arrow2, arrow3);                // The three dart points are added to a new turn for player i in player_list
                    //i.Print_Turns();
                    //Console.WriteLine("Press [Enter] for next turn");
                    //Console.ReadLine();
                }
            } while (Player_Best() < 301);

            //Console.WriteLine("!!CONGRATULATIONS!!                                                           !!CONGRATULATIONS!!");
            //Console.WriteLine("!!CONGRATULATIONS!!                  Someone has won the game                 !!CONGRATULATIONS!!");
            //Console.WriteLine("!!CONGRATULATIONS!!                If your want to see the result             !!CONGRATULATIONS!!");
            //Console.WriteLine("!!CONGRATULATIONS!!                 of the winner press [Enter]               !!CONGRATULATIONS!!");
            //Console.WriteLine("!!CONGRATULATIONS!!                                                           !!CONGRATULATIONS!!");
            //Console.WriteLine("\n========================================================================================================================");
            //Console.ReadLine();

            //foreach (var i in player_list)                         // If Calculate_Total() is identical to Player_Best() then the player is a winner and the statistics for the player will be printed
            //{                                                      // If more then one player has Player_Best() then they will all be winners
            //    if (i.Calculate_Total() == Player_Best())
            //        i.Print_Turns();
            //}

            int Player_Best()                                      // Player_Best is the total score overall turns for the best player
            {
                int highest = player_list[0].Calculate_Total();
                foreach (var i in player_list)
                {
                    if (highest < i.Calculate_Total())
                        highest = i.Calculate_Total();
                }
                return highest;
            }
        }

        public void AddPlayer(string name)
        {
            player_list.Add(new Player(name));
        }

        public bool Aim_Result()                                   // Jag ska skapa en sikta knapp
        {
            bool _aim_good;
            Random random_tal = new Random();
            int _tal = random_tal.Next(0, 2);                      // Slumpar fram talet 0 med 50% chans och talet 1 med 50% chans

            //Console.WriteLine("Press [Enter] to see how well you aimed");
            //Console.ReadLine();

            if (_tal == 0)
            {
                _aim_good = false;
                //Console.WriteLine("You aimed badly");
            }
            else                                                   //(_tal == 1)
            {
                _aim_good = true;
                //Console.WriteLine("You aimed good");
            }
            return _aim_good;
        }
    }

    /*===============================================================================================================================
                                                                   CLASS PLAYER
      ===============================================================================================================================*/
    class Player
    {
        private string name;
        private List<Turn> turn_list = new List<Turn>();           // Creates a List where the player stores his turns

        public Player(string _name = "guest")                        // This is a instance constructor that is executed when a new instance of a class is created, it has to have the same name as class
        {                                                          // Vet inte hur default namnet på constructorn "guest" ska aktiveras när inget namn skrivs in på kontrollpanelen, har fixat en annan lösning
            name = _name;
        }

        public void Add_Turn(int tal1, int tal2, int tal3)         // This is a method that adds the points for the three darts in a turn for the player
        {
            turn_list.Add(new Turn(tal1, tal2, tal3));
        }

        public int Calculate_Total()                                // This method get the sum of point overall turns for the player
        {
            int total = 0;
            foreach (var i in turn_list)
            {
                total = total + i.Get_Turn_Points();
            }
            return total;
        }

        //public void Print_Turns()
        //{
        //    int turn_nr = 1;

        //    Console.WriteLine("Statistics for {0}: ", name);
        //    foreach (var i in turn_list)
        //    {
        //        Console.WriteLine("\nTurn: " + turn_nr++);
        //        Console.WriteLine(i);                              // Prints the ToString() from class Turn
        //        Console.WriteLine("");
        //    }
        //    Console.WriteLine("Highest dart point over all turns for {0}: {1}", name, Personal_Best());
        //    Console.WriteLine("\nTotal score over all turns for {0}: {1}", name, Calculate_Total());
        //    Console.WriteLine("\n========================================================================================================================");
        //}

        private int Personal_Best()                                // Method that gets the highest dart point overall turns for the player
        {
            int highest = turn_list[0].Get_Highest_Score();
            foreach (var i in turn_list)
            {
                if (highest < i.Get_Highest_Score())
                    highest = i.Get_Highest_Score();
            }
            return highest;
        }

        //public override string ToString()
        //{
        //    return string.Format("Player name is {0}", name);
        //}
    }

    /*===============================================================================================================================
                                                                   CLASS TURN
      ===============================================================================================================================*/
    class Turn
    {
        private int dart1;
        private int dart2;
        private int dart3;

        public Turn(int _dart1, int _dart2, int _dart3)            // This is a instance constructor that is executed when a new instance of a class is created, it has to have the same name as class
        {
            dart1 = _dart1;
            dart2 = _dart2;
            dart3 = _dart3;
        }

        public int Get_Turn_Points()
        {
            int total;
            total = dart1 + dart2 + dart3;
            return total;
        }

        public int Get_Highest_Score()                             // Get_Highest_Score over the three darts
        {
            int highest = dart1;
            if (dart2 > highest)
                highest = dart2;
            if (dart3 > highest)
                highest = dart3;
            return highest;
        }

        //public override string ToString()
        //{
        //    return string.Format("Dart1: {0} | Dart2: {1} | Dart3: {2} | Total: {3}", dart1, dart2, dart3, Get_Turn_Points());
        //}
    }

    /*
     using System;
     using System.IO;

     namespace ConsoleApplication6
     {
         class Program
         {
             static void Main(string[] args)
             {
                 StreamWriter streamWriter = new StreamWriter("textfil.txt", true);
                 streamWriter.WriteLine("Text som skrivs till filen.");
                 streamWriter.WriteLine("Här skrivs text på en ny rad.");
                 streamWriter.Close();
             }
             static void Main(string[] args)
             {
                 using (StreamWriter streamWriter = new StreamWriter("textfil.txt", true))
                 {
                     streamWriter.WriteLine("Text som skrivs till filen.");
                     streamWriter.Close();
                 }
             }
         }
     }
     */
}
