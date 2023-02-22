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
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("                                        Welcome to Joppes Underground Fightclub                                         ");
            Console.WriteLine("========================================================================================================================");

            Add_Dog(3, 100, "The Deadly Rabies", "Demon Hound", "Bloody Raw Meat", false, "ROOAAR!!");
            Add_Dog(8, 100, "Bosse", "Boxer", "Hamburger", false, "Woff, woff!!");
            Add_Puppy(0, 50, "Essob", "Boxer", "Meatballs", false, "Beep, beep!!", 6);
            List_Animal();
            
        }

        public void List_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
                i.PrintDetails();
            }
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