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

        public void Play_Game()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("|                                        Welcome to Joppes Underground Fightclub                                      |");
            Console.WriteLine("=======================================================================================================================");

            int int_age = 0;

            try
            {
                Console.WriteLine("Enter your age: ");
                int_age = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Error, enter your age");
            }

            if (int_age > 0 && int_age < 18)
            {
                Add_Dog(8, 100, "Bosse", "Boxer", "Hamburger", false, "Woff, woff!!");
                Add_Puppy(0, 50, "Essob", "Boxer", "Meatballs", false, "Beep, beep!!", 6);
            }

            else if (int_age >= 18 && int_age < 150)
            {
                Add_Dog(3, 100, "The Deadly Rabies", "Demon Hound", "Bloody Raw Meat", false, "ROOAAR!!");
                Add_Puppy(0, 50, "Devil Puppy", "Lucifer", "Souls", false, "Sceek, sceek!!", 5);
            }

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
                        Console.WriteLine("Du har valt alternativ 1 : Animal List");
                        List_Animal();
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 2 : Select Animal");
                        //Fetch_Animal();
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 3 : Feed Animal");
                        Console.WriteLine(" ");
                        //Feed();
                        break;

                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 4 : Ball Shop");
                        Console.WriteLine(" ");
                        //Ball_Shop();
                        break;

                    case 5:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 5 : Ball List");
                        Console.WriteLine(" ");
                        //List_Balls();
                        break;

                    case 6:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 6 : Select Ball");
                        Console.WriteLine(" ");
                        //Select_Ball();
                        break;

                    case 7:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 7 : Check Ball");
                        Console.WriteLine(" ");
                        //Check_Ball();
                        break;

                    case 8:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 8 : Visa menyn igen");
                        Menu();
                        break;

                    case 9:
                        Console.WriteLine(" ");
                        Console.WriteLine("Du har valt alternativ 9 : Du har valt att avbryta köpet");
                        Console.WriteLine(" ");
                        Console.WriteLine("Köpet avbryts");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("|     Välkommen åter                                                                                                  |");
                        Console.WriteLine("=======================================================================================================================");
                        avbryt_nr = 9;
                        break;

                    default:
                        //Console.WriteLine("Du skrev in en siffra, men den måste vara 1-7");
                        break;
                }
            } while (avbryt_nr != 9); // case 9 avbryter loopen

        }

        public void List_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
                i.PrintDetails();
            }
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

        public void Add_Dog(int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound)
        {
            pet_list.Add(new Dog(age, hp, name, breed, fav_food, hungry, bark_sound));
        }

        public void Add_Puppy(int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound, int months)
        {
            pet_list.Add(new Puppy(age, hp, name, breed, fav_food, hungry, bark_sound, months));
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS Animal
      =======================================================================================================================================================================================================*/
    public abstract class Animal // ParentClass for Cat and Dog
    {
        protected int age, hp;
        protected string name, breed, fav_food;
        protected bool hungry;

        public Animal(int age, int hp, string name, string breed, string fav_food, bool hungry)  // Instance constructor
        {
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

        public Dog(int age, int hp, string name, string breed, string fav_food, bool hungry) : base(age, hp, name, breed, fav_food, hungry) // Instance constructor
        {
        }
        // Instance constructor with extra parameter
        public Dog(int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound1) : this(age, hp, name, breed, fav_food, hungry)
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
            return string.Format("{0}Dog", base.ToString());
        }
    }

    /*=======================================================================================================================================================================================================
                                                                                                   CLASS PUPPY
      =======================================================================================================================================================================================================*/
    public class Puppy : Dog  // ChildClass to Dog
    {
        protected int months;

        public Puppy(int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound) : base(age, hp, name, breed, fav_food, hungry, bark_sound) // Instance constructor
        {
        }
        // Instance constructor with extra parameter
        public Puppy(int age, int hp, string name, string breed, string fav_food, bool hungry, string bark_sound, int months1) : this(age, hp, name, breed, fav_food, hungry, bark_sound)
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
}