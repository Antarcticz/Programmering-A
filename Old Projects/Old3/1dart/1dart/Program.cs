using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dart
{
    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PROGRAM
      =======================================================================================================================================================================================================*/
    class Program
    {
        static void Main(string[] args)
        {
            //Här skapas ett objekt av klassen Game enbart i syfte att köra igång spelet
            //Denna klass hade också kunnat vara statisk men det är mer förvirrande
            Game My_game = new Game();
            My_game.Play_Game();
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS GAME
      =======================================================================================================================================================================================================*/
    class Game
    {
        private List<Player> player_list = new List<Player>(); //Dograce

        //Inkapslade variabler och lista
        public void Play_Game()
        {
            int players = 1;
            int round = 1;
            Random random_nr = new Random();
            int arrow1;
            int arrow2;
            int arrow3;
            //Här körs själva spelet
            Console.WriteLine("Welcome to the awesome Dart game");
            Console.WriteLine("\nHow many players do you want to register?");
            int max_players = int.Parse(Console.ReadLine());

            do
            {
                string str_name = "";
                players++;

                Console.WriteLine("\nChoose player name or press [Enter] as Guest: ");
                str_name = Console.ReadLine();

                if (str_name == "")             // If no player name is Enterd on the console, the player will be added with the name "Guest"
                    AddPlayer("Guest");

                else AddPlayer(str_name);
                
            } while (players <= max_players);

            Console.WriteLine("==============================================================");

            foreach (var i in player_list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==============================================================");
            Console.WriteLine("");

            do
            {
                round++;
                foreach (var i in player_list)
                {
                    arrow1 = random_nr.Next(0, 21);
                    arrow2 = random_nr.Next(0, 21);
                    arrow3 = random_nr.Next(0, 21);
                    i.Add_Turn(arrow1, arrow2, arrow3);
                    i.Print_Turns();
                    Console.WriteLine("Press [Enter] for next turn");
                    Console.ReadLine();
                }
            } while (Player_Best() < 301);
            
            Console.WriteLine("!!CONGRATULATIONS!!                                                           !!CONGRATULATIONS!!");
            Console.WriteLine("!!CONGRATULATIONS!!                  Someone has won the game                 !!CONGRATULATIONS!!");
            Console.WriteLine("!!CONGRATULATIONS!!                If your want to se the result              !!CONGRATULATIONS!!");
            Console.WriteLine("!!CONGRATULATIONS!!                 of the winner press [Enter]               !!CONGRATULATIONS!!");
            Console.WriteLine("!!CONGRATULATIONS!!                                                           !!CONGRATULATIONS!!");
            Console.ReadLine();
            
            foreach (var i in player_list)   // If Calculate_Total() is identical to Player_Best() then the player is a winner and the statistics for the player will be printed
            {                                // If more then one player has Player_Best() then they will all be winners
                if (i.Calculate_Total() == Player_Best())
                    i.Print_Turns();
            }
            
            int Player_Best()    // Player_Best is the total score overall turns for the best player
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
            //code
            /*player_list.Add(new Player("Adam"));
            player_list.Add(new Player("Eva"));*/
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PLAYER
      =======================================================================================================================================================================================================*/
    class Player
    {
        private string name;
        private List<Turn> turn_list = new List<Turn>();

        public Player(string _name="guest")  // This is a instance constructor that is executed when a new instance of a class is created, it has to have the same name as class
        {                                    // Vet inte hur default namnet på constructorn "guest" ska aktiveras när inget namn skrivs in på kontrollpanelen, har fixat en annan lösning
            name = _name;
        }
        
        public void Add_Turn(int tal1, int tal2, int tal3)
        {
            turn_list.Add(new Turn(tal1, tal2, tal3));
        }
        
       public int Calculate_Total()
        {
            int total = 0;
            foreach (var i in turn_list)
            {
                total = total + i.Get_Turn_Points();
            }
            return total;
        }

        public void Print_Turns()
        {
            int turn_nr = 1;

            Console.WriteLine("\nStatistics for {0}: ", name);
            Console.WriteLine("==============================================================");
            foreach (var i in turn_list)
            {
                Console.WriteLine("Turn: " + turn_nr++);
                Console.WriteLine(i);
                Console.WriteLine("");
            }
            Console.WriteLine("\nHighest dart point over all turns for {0} was {1}", name, Personal_Best());
            Console.WriteLine("\nTotal score over all turns for {0} was {1} points", name, Calculate_Total());
            Console.WriteLine("==============================================================");
        }

        private int Personal_Best()
        {
            int highest = turn_list[0].Get_Highest_Score();
            foreach (var i in turn_list)
            {
                if (highest < i.Get_Highest_Score())
                    highest = i.Get_Highest_Score();
            }
            return highest;
        }

        public override string ToString()
        {
            return string.Format("Player name is {0}", name);
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS TURN
      =======================================================================================================================================================================================================*/
    class Turn  
    {
        private int dart1;
        private int dart2;
        private int dart3;

        public Turn(int _dart1, int _dart2, int _dart3)  // This is a instance constructor that is executed when a new instance of a class is created, it has to have the same name as class
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

        public int Get_Highest_Score()   // Get_Highest_Score over the three darts
        {
            int highest = dart1;
            if (dart2 > highest)
                highest = dart2;
            if (dart3 > highest)
                highest = dart3;
            return highest;
        }

        public override string ToString()
        {
            return string.Format("Dart1: {0} | Dart2: {1} | Dart3: {2} | Total: {3}", dart1, dart2, dart3, Get_Turn_Points());
        }
    }
}
