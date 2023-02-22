using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using System.IO;

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
        //static void Main(string[] args)
        //{
        //    StreamWriter streamWriter = new StreamWriter("textfil.txt", true);
        //    streamWriter.WriteLine("Text som skrivs till filen.");
        //    streamWriter.WriteLine("Här skrivs text på en ny rad.");
        //    streamWriter.Close();
        //}
    }

    /*===============================================================================================================================
                                                                   CLASS GAME
      ===============================================================================================================================*/
    class Game
    {
        public List<Player> player_list = new List<Player>();

        public bool aim_good;

        public void Play_Game()
        {
            int round = 1;
            //bool aim_good;
            Random random_nr = new Random();
            int arrow1;
            int arrow2;
            int arrow3;
            int turn_id;

            do
            {
                round++;
                turn_id = round++;
                foreach (var i in player_list)
                {
                    aim_good = Aim_Result();
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
                    i.Add_Turn(arrow1, arrow2, arrow3, aim_good, turn_id);                // The three dart points are added to a new turn 
                }
            } while (Player_Best() < 301);

            int Player_Best()                    // Player_Best is the total score overall turns for the best player
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

        private bool Aim_Result()     
        {
            bool _aim_good;
            Random random_tal = new Random();
            int _tal = random_tal.Next(0, 2);         // Slumpar fram talet 0 med 50% chans och talet 1 med 50% chans

            if (_tal == 0)
            {
                _aim_good = false;      //AimTextBox("You aimed badly")

            }
            else                       //(_tal == 1)
            {
                _aim_good = true;      //AimTextBox("You aimed good")

            }
            return _aim_good;
        }

        public void AddPlayer(string name)
        {

            player_list.Add(new Player(name));
        }

        public string printPlayerList(List<Player> playerList)
        {
            string lista = "";
            foreach (var x in playerList)
            {
                lista += x.name + " scored: " + x.Calculate_Total() + "  ||  ";
            }
            return lista;
        }
        public override string ToString()
        {

            return printPlayerList(player_list);
        }
        //foreach (var i in player_list)
        //{
        //    Console.WriteLine(i);                              // Prints the ToString() from class Player
        //    i.Print_Turns();
        //    i.ToString();
        //}

        //foreach (var i in player_list)                         // If Calculate_Total() is identical to Player_Best() then the player is a winner and the statistics for the player will be printed
        //{                                                      // If more then one player has Player_Best() then they will all be winners
        //    if (i.Calculate_Total() == Player_Best())
        //        i.Print_Turns();
        //}
    }

    /*===============================================================================================================================
                                                                   CLASS PLAYER
      ===============================================================================================================================*/
    class Player
    {
        public string name;
        public List<Turn> turn_list = new List<Turn>();           // Creates a List where the player stores his turns
        public Player(string _name)                      // This is a instance constructor 
        {                                                         
            name = _name;
            
        }
                                           // This is a method that adds the points for the three darts in a turn for the player
        public void Add_Turn(int tal1, int tal2, int tal3, bool _aim_good, int _turn_id)  
        {
            turn_list.Add(new Turn(tal1, tal2, tal3, _aim_good, _turn_id));
        }

        public int Calculate_Total()       // This method get the sum of point overall turns for the player
        {
            int total = 0;
            foreach (var i in turn_list)
            {
                total = total + i.Get_Turn_Points();
            }
            return total;
        }
        public string printTurnList(List<Turn> turnlist)
        {
            string lista = "";
            foreach(var x in turnlist)
            {
                lista += ", " + x.ToString();
            }
            return lista;
        }
        public override string ToString()
        {
            return string.Format("{0} Total score {1} by Turn: {2} ", name, Calculate_Total(), printTurnList(turn_list));

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

        //private int Personal_Best()                   // Method that gets the highest dart point overall turns for the player
        //{
        //    int highest = turn_list[0].Get_Highest_Score();
        //    foreach (var i in turn_list)
        //    {
        //        if (highest < i.Get_Highest_Score())
        //            highest = i.Get_Highest_Score();
        //    }
        //    return highest;
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
        private bool aim_good;
        private int turn_id;

        public Turn(int _dart1, int _dart2, int _dart3, bool _aim_good, int _turn_id)  // This is a instance constructor 
        {
            dart1 = _dart1;
            dart2 = _dart2;
            dart3 = _dart3;
            aim_good = _aim_good;
            turn_id = _turn_id;
        }

        public bool Get_Aim_Result()
        { 
            return aim_good;
        }

        public int Get_Turn_Points()
        {
            int total;
            total = dart1 + dart2 + dart3;
            return total;
        }

        //public int Get_Turn_ID()
        //{
        //    return turn_id;
        //}

        //public int Get_Highest_Score()                             // Get_Highest_Score over the three darts
        //{
        //    int highest = dart1;
        //    if (dart2 > highest) highest = dart2;
        //    if (dart3 > highest) highest = dart3;
        //    return highest;
        //}

        public override string ToString()
        {
            return string.Format("{3} | Dart1: {0} | Dart2: {1} | Dart3: {2} | ", dart1, dart2, dart3, turn_id);
            //return string.Format("Dart1: {0} | Dart2: {1} | Dart3: {2} | Total: {3}", dart1, dart2, dart3, Get_Turn_Points());
        }
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
