// Developed by Maximilian Hedman
// 2018-12-29

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _4Joppe
{
    /*===========================================================================================================================================================================
                                                                                                   CLASS PROGRAM
      ===========================================================================================================================================================================*/
    class Program
    {
        public static void Main(string[] args)
        {
            Petowner my_game = new Petowner();
            my_game.Play_Game();  
        }
    }
    
    /*===========================================================================================================================================================================
                                                                                                   CLASS PETOWNER
      ===========================================================================================================================================================================*/
    class Petowner
    {
        public List<Animal> pet_list = new List<Animal>();

        public List<Ball> ball_list = new List<Ball>();

        public int currency = 100; // Petowner starts with 100 coins

        public int pet_nr = -1;  // Håller reda på vilket djur som är valt. -1 gör att fetch animal loopen loopar tills man skriver in ett djur som finns.
        public int ball_nr = -1; // Håller reda på vilken boll som är vald. -"-


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
                    Console.Write("Select a number from 1-10 | [9] = Meny | [Enter] = Repeat latest choice : ");
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
                        Console.WriteLine(" ");
                        List_Animal();
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 2 : Select Animal");
                        Console.WriteLine(" ");
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
                        Fetch_Ball();
                        break;

                    case 7:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 7 : Check Ball");
                        Console.WriteLine(" ");
                        //Check_Ball();
                        break;

                    case 8:
                        Console.WriteLine(" ");  //**************************************************************************
                        Console.WriteLine("You choose option 8 : Play with Animal/Ball");
                        Console.WriteLine(" ");
                        Play();
                        break;

                    case 9:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 9 : Show Menu again");
                        Menu();
                        break;

                    case 10:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 10 : Exit Game");
                        Console.WriteLine(" ");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("|                                                    Welcome Back                                                     |");
                        Console.WriteLine("=======================================================================================================================");
                        avbryt_nr = 9;
                        break;

                    default:
                        //Console.WriteLine("Du skrev in en siffra, men den måste vara 1-7");
                        break;
                }
            } while (avbryt_nr != 9); // case 9 avbryter loopen

        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  START_UP
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
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
                Add_Dog(  0, 8, 200, "Bosse  ", "Boxer          ", "Hamburger   ", false, "Woff, woff!!   ");
                Add_Dog(  1, 6, 200, "Daicy  ", "Golden Retriver", "Sausage     ", false, "Woffeli, woff!!");
                Add_Puppy(2, 0, 100, "Essob  ", "Boxer          ", "Meatballs   ", false, "Beep, beep!!   ", 6);
                Add_Puppy(3, 0, 100, "Gunilla", "Tax            ", "Dog Biscuit ", false, "Yelp, yelp!!   ", 9);
                Add_Dog(  4, 5, 150, "Kitty  ", "Cat            ", "Fish        ", false, "Meow!!         ");
            }

            else if (int_age >= 18 && int_age < 150)
            { 
                Add_Dog(  0, 3, 200, "The Deadly Rabies", "Zombie Dog    ", "Brains         ", false, "Aahhgg!!        ");
                Add_Dog(  1, 9, 200, "Black Wolf       ", "Canis Lupus   ", "Bloody Raw Meat", false, "Hoowwl!!        ");
                Add_Puppy(2, 0, 100, "Lucifer          ", "Demon Hound   ", "Souls          ", false, "Sceek, sceek!!  ", 5);
                Add_Puppy(3, 0, 100, "Skellie          ", "Skeleton Hound", "Bones          ", false, "Rattel, rattel!!", 8);
                Add_Dog(  4, 5, 150, "Kitty            ", "Cat           ", "Fish           ", false, "Meow!!          ");  // Ska ändra det här till classen cat
            }
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  PLAY
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Play()
        {
            //Ball selected_ball;
            Fetch_Ball();

            if (ball_nr != -1)
            {
                Fetch_Animal();
                Console.WriteLine("Playing with {0} and {1}", pet_list[pet_nr], ball_list[ball_nr]);
                //Console.WriteLine("after Play Ball nr is: " + ball_nr);  // Bara för kontroll av ball_nr
                //selected_ball = ball_list[ball_nr];
                pet_list[pet_nr].Interact(ball_list[ball_nr]);
            }
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  LIST_ANIMAL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void List_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
                i.PrintDetails();
            }
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  FETCH_ANIMAL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Fetch_Animal()
        {
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from classi.PrintDetails();
            }
            
            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Select animal ID nr [0 - 4]: ");
                    pet_nr = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error, enter ID nr [0 - 4]");
                }
            } while (pet_nr < 0 || pet_nr > 4);  // Om man lägger till fler djur i listan så måste man ändra här också  // Fetch_Animal kan bara brytas om man väljer ett djur som finns
            Console.WriteLine("Animal ID nr {0} is selected", pet_list[pet_nr]);  // ID nr är indentiskt med ordningen i listan
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  LIST_BALL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void List_Ball()
        {
            foreach (var i in ball_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  BALL_SHOP
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
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
                        Console.WriteLine("");
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
                        Add_Ball(50, "White ", "Small Ball ");
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
                        Add_Ball(150, "Gold  ", "Large Ball ");
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
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  FETCH_BALL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Fetch_Ball()
        {
            int max_ball_nr = -1; // Håller reda på hur många bollar man har köpt och då är max antal bollar -1, så man kan söka på bollarna i boll listan

            foreach (var i in ball_list)
            {
                max_ball_nr++;         // Första bollen i listan har max_ball_nr = 0
                Console.WriteLine("Ball ID nr is: " + max_ball_nr);
                Console.WriteLine(i);  // Prints the ToString() from classi.PrintDetails();
                Console.WriteLine("");
            }

            if (max_ball_nr == -1)
            {
                Console.WriteLine("No balls exist, you need to buy balls first");
            }

            else
            {
                do
                {
                    try
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Select Ball ID nr [0 - {0}]", max_ball_nr);
                        ball_nr = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                    }
                    catch (System.FormatException e)
                    {
                        Console.WriteLine("ERROR Select ball nr [0 - {0}], first ball has nr 0, second ball 1 etc ERROR", max_ball_nr);
                    }
                } while (ball_nr < 0 || ball_nr > max_ball_nr);  // Man kan inte bryta detta om man inte väljer en boll som finns
                Console.WriteLine("{0} is selected", ball_list[ball_nr]);  // ID nr är indentiskt med ordningen i listan
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  MENU
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Menu()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("| Menu :                                                                                                              |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("| [1]  Animal List                                                                                                    |");
            Console.WriteLine("| [2]  Select Animal                                                                                                  |");
            Console.WriteLine("| [3]  Feed Animal                                                                                                    |");
            Console.WriteLine("| [4]  Ball Shop                                                                                                      |");
            Console.WriteLine("| [5]  Ball List                                                                                                      |");
            Console.WriteLine("| [6]  Select Ball                                                                                                    |");
            Console.WriteLine("| [7]  Check Ball                                                                                                     |");
            Console.WriteLine("| [8]  Play with Animal/Ball                                                                                          |");
            Console.WriteLine("| [9]  Show Menu Again                                                                                                |");
            Console.WriteLine("| [10] Exit Game                                                                                                      |");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  ADD
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
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

    /*===========================================================================================================================================================================
                                                                                                   CLASS ANIMAL
      ===========================================================================================================================================================================*/
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

        public abstract void PrintDetails(); // Can override (virtual) but dont have to (abstract)

        //pet_list[pet_nr].Interact(ball_list[ball_nr]);
        public virtual void Interact(Ball _ball)
        {
            Random random_nr = new Random();
            int check = random_nr.Next(0, 101);  // Check får ett random nr mellan 0 och 100
            if (check < 50)
            {
                Console.WriteLine("Interact" + _ball);
                _ball.Lower_Durability();
                Console.WriteLine("Interact and Lower_Durability" + _ball);
            }
            else hp = -10;
        }

        public void Eat() // ADD FOOD, compare to favorite food
        {

        }

        public virtual void Hungry_Animal()
        {

        }

        public override string ToString()
        {
            return string.Format("Animal is a ");
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS DOG
      ===========================================================================================================================================================================*/
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

        public override void Interact(Ball _ball)
        {
            //Console.WriteLine("Interact" + _ball);  // Kontroll utskrift
            _ball.Lower_Durability();
            _ball.Lower_Durability();
            _ball.Lower_Durability();
            //Console.WriteLine("Interact and Lower_Durability for Dog" + _ball);  // Kontroll utskrift
        }



        public override void PrintDetails()
        {
            
            Console.WriteLine("Age: {0} Years Old | HP: {1} | Hungry: {2} | Favorite Food: {3} | Bark Sound: {4}", age, hp, hungry, fav_food, bark_sound);
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return string.Format("ID nr: {0} | {1}Dog named: {2} | Breed: {3}", id_nr, base.ToString(), name, breed);
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS PUPPY
      ===========================================================================================================================================================================*/
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

        public override void Interact(Ball _ball)
        {
            //Console.WriteLine("Interact" + _ball);  // Kontroll utskrift
            _ball.Lower_Durability();
            _ball.Lower_Durability();
            //Console.WriteLine("Interact and Lower_Durability for Puppy" + _ball);  // Kontroll utskrift
        }

        public override string ToString()
        {
            return string.Format("{0} | Puppy | {1} Months Old", base.ToString(), months);
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS BALL
      ===========================================================================================================================================================================*/
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

        public void Lower_Durability()
        {
            durability = durability -10;
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | Durabilty: {2}", name, color, durability);
        }
    }
}