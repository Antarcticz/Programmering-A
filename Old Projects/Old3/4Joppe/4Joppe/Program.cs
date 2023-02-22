// Developed by Maximilian Hedman
// 2018-12-29

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _4Joppe
{
    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PROGRAM
      =======================================================================================================================================================================================================*/
    class Program
    {
        public static void Main(string[] args)
        {
            Petowner my_game = new Petowner();
            my_game.Play_Game();  
        }
    }
    
    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PETOWNER
      =======================================================================================================================================================================================================*/
    class Petowner
    {
        private List<Animal> pet_list = new List<Animal>();

        private List<Ball> ball_list = new List<Ball>();

        private int currency = 100; // Petowner starts with 100 coins

        public void Play_Game()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("|                                        Welcome to Joppes Underground Fightclub                                      |");
            Console.WriteLine("=======================================================================================================================");

            Start_Up();

            Menu();

            int avbryt_nr = 0; // avbryt_nr får ett värde som inte är 9. Vilket gör att do/while loopen kan loopa hur många varv som helst genom case/switch menyn, tills meny val nr 9 väljs
            int int_alt = 99; // int_alt deffineras här och får vilken siffra som helst, för att try/catch och switch/case ska fungera.

            do
            {
                try
                {
                    Console.WriteLine("=======================================================================================================================");
                    Console.Write("Select a number from 1-9 | [8] = Meny | [Enter] = Repeat latest choice : ");
                    int_alt = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error, put in a number from 1-9");
                }
                //Console.Write("Vad vill du göra? Ange nr : ");
                // int int_alt = int.Parse(Console.ReadLine());

                switch (int_alt)
                {
                    case 1:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 1 : Animal List");
                        List_Animal();
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 2 : Select Animal");
                        Fetch_Animal();
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 3 : Feed Animal");
                        Console.WriteLine(" ");
                        //Feed();
                        break;

                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 4 : Ball Shop");
                        Console.WriteLine(" ");
                        Ball_Shop();
                        break;

                    case 5:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 5 : Ball List");
                        Console.WriteLine(" ");
                        List_Ball();
                        break;

                    case 6:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 6 : Select Ball");
                        Console.WriteLine(" ");
                        //Select_Ball();
                        break;

                    case 7:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 7 : Check Ball");
                        Console.WriteLine(" ");
                        //Check_Ball();
                        break;

                    case 8:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 8 : Show Menu again");
                        Menu();
                        break;

                    case 9:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 9 : Exit Game");
                        Console.WriteLine(" ");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("|     Welcome Back                                                                                                    |");
                        Console.WriteLine("=======================================================================================================================");
                        avbryt_nr = 9;
                        break;

                    default:
                        //Console.WriteLine("Du skrev in en siffra, men den måste vara 1-7");
                        break;
                }
            } while (avbryt_nr != 9); // case 9 avbryter loopen

        }

        public void Start_Up()
        {
            int int_age = 0;
            do
            {
                try
                {
                    Console.WriteLine("Enter your age: ");
                    int_age = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error, enter your age");
                }
            } while (int_age == 0);

            if (int_age > 0 && int_age < 18)
            {
                Add_Dog(1,8, 100, "Bosse", "Boxer", "Hamburger", false, "Woff, woff!!");
                Add_Puppy(2,0, 50, "Essob", "Boxer", "Meatballs", false, "Beep, beep!!", 6);
            }

            else if (int_age >= 18 && int_age < 150)
            {
                Add_Dog(101,3, 100, "The Deadly Rabies", "Demon Hound", "Bloody Raw Meat", false, "ROOAAR!!");
                Add_Puppy(102,0, 50, "Devil Puppy", "Lucifer", "Souls", false, "Sceek, sceek!!", 5);
            }
        }

        public void List_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
                i.PrintDetails();
            }
        }

        public void Fetch_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from classi.PrintDetails();
            }

            int int_nr = 0;
            do
            {
                try
                {
                    Console.WriteLine("Select animal ID nr: ");
                    int_nr = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error, enter ID nr");
                }
            } while (int_nr == 0);
            Console.WriteLine("Animal ID nr {0} is selected", pet_list[1]);
        }

        public void List_Ball()
        {
            foreach (var i in ball_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
            }
        }

        public void Ball_Shop()
        {
            int avbryt_nr = 99; // avbryt_nr får ett värde som inte är 4. Vilket gör att do/while loopen kan loopa hur många varv som helst genom case/switch menyn, tills meny val nr 4 väljs
            int int_alt = 99; // int_alt deffineras här och får vilken siffra som helst, för att try/catch och switch/case ska fungera.

            do
            {
                if (currency < 25)
                {
                    Console.WriteLine("Your need at least 25(c) to shop");
                    int_alt = 4;
                }

                else
                {
                    try
                    {
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("What ball do you want to buy? [1]Small 5(c) | [2]Medium 15(c) | [3]Large 25(c) | [4]Exit Ball Shop");
                        int_alt = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException e)
                    {
                        Console.WriteLine("Error, put in a number from 1-4");
                    }
                }

                switch (int_alt)
                {
                    case 1:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 1 : Small Ball");
                        Add_Ball(50, "White", "Small Ball");
                        currency = currency - 5;
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 2 : Medium Ball");
                        Add_Ball(100, "Silver", "Medium Ball");
                        currency = currency - 15;
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 3 : Large Ball");
                        Add_Ball(150, "Gold", "Large Ball");
                        currency = currency - 25;
                        Console.WriteLine(" ");
                        break;

                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 4 : Exit Ball Shop");
                        Console.WriteLine(" ");
                        avbryt_nr = 4;
                        break;

                    default:
                        //Console.WriteLine("");
                        break;
                }

            } while (avbryt_nr != 4); // case 4 avbryter loopen 
            Console.WriteLine("Total Currency left: " + currency);
        }

        public void Menu()
        {
            Console.WriteLine("| Menu :                                                                                                              |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("| [1] Animal List                                                                                                     |");
            Console.WriteLine("| [2] Select Animal                                                                                                   |");
            Console.WriteLine("| [3] Feed Animal                                                                                                     |");
            Console.WriteLine("| [4] Ball Shop                                                                                                       |");
            Console.WriteLine("| [5] Ball List                                                                                                       |");
            Console.WriteLine("| [6] Select Ball                                                                                                     |");
            Console.WriteLine("| [7] Check Ball                                                                                                      |");
            Console.WriteLine("| [8] Show Menu Again                                                                                                 |");
            Console.WriteLine("| [9] Exit Game                                                                                                       |");
        }

        public void Add_Dog(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound)
        {
            pet_list.Add(new Dog(id_nr, age, hp, name, breed, fav_food, hungry, bark_sound));
        }

        public void Add_Puppy(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound, int months)
        {
            pet_list.Add(new Puppy(id_nr, age, hp, name, breed, fav_food, hungry, bark_sound, months));
        }

        public void Add_Ball(int durability, string color, string name)
        {
            ball_list.Add(new Ball(durability, color, name));
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS ANIMAL
      =======================================================================================================================================================================================================*/
    public abstract class Animal // ParentClass for Cat and Dog
    {
        protected int id_nr, age, hp;
        protected string name, breed, fav_food;
        protected bool hungry;

        public Animal(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry)  // Instance constructor
        {
            this.id_nr = id_nr;
            this.age = age;
            this.hp = hp;
            this.name = name;
            this.breed = breed;
            this.fav_food = fav_food;
            this.hungry = hungry;
            //Console.Write("The animal is {0}", name);
        }

        public abstract void PrintDetails();

        public virtual void Interact()  // Can override (virtual) but dont have to (abstract), ADD BALL
        {

        }

        public void Eat() // ADD FOOD, compare to favorite food
        {

        }

        public virtual void Hungry_Animal()
        {

        }

        public override string ToString()
        {
            return string.Format("|Animal is: ");
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS DOG
      =======================================================================================================================================================================================================*/
    public class Dog : Animal  // ChildClass to Animal
    {
        protected string bark_sound;

        public Dog(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry) : base(id_nr, age, hp, name, breed, fav_food, hungry) // Instance constructor
        {
        }
        // Instance constructor with extra parameter
        public Dog(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound1) : this(id_nr, age, hp, name, breed, fav_food, hungry)
        {
            //Console.WriteLine("Bark sound: {0}", bark_sound1);
            bark_sound = bark_sound1;
        }

        public override void PrintDetails()
        {
            Console.WriteLine("|");
            Console.WriteLine("|Breed: {3} | Name: {2} | Age: {0} years | HP: {1}                               |", age, hp, name, breed);
            Console.WriteLine("|                                                                                |");
            Console.WriteLine("|Hungry: {1} | Favorite Food: {0} | Bark Sound: {2}                              |", fav_food, hungry, bark_sound);
            Console.WriteLine("==================================================================================");
        }

        public override string ToString()
        {
            return string.Format("ID nr: {1} | {0}Dog", base.ToString(), id_nr);
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PUPPY
      =======================================================================================================================================================================================================*/
    public class Puppy : Dog  // ChildClass to Dog
    {
        protected int months;

        public Puppy(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound) : base(id_nr, age, hp, name, breed, fav_food, hungry, bark_sound) // Instance constructor
        {
        }
        // Instance constructor with extra parameter
        public Puppy(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound, int months1) : this(id_nr, age, hp, name, breed, fav_food, hungry, bark_sound)
        {
            //Console.WriteLine("Dog name: {0}", name);
            //Console.WriteLine("The Puppy is: {0} months old", months1);
            //Console.WriteLine("");
            months = months1;
        }

        public override string ToString()
        {
            return string.Format("{0}-Puppy", base.ToString());
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS BALL
      =======================================================================================================================================================================================================*/
    public class Ball
    {
        protected int durability;
        protected string color, name;

        public Ball(int durability, string color, string name)  // Instance constructor
        {
            this.durability = durability;
            this.color = color;
            this.name = name;
            //Console.Write("The ball is {0}", name);
        }

        public override string ToString()
        {
            return string.Format(" {0} | {1} | {2} ", name, color, durability);
        }
    }
}