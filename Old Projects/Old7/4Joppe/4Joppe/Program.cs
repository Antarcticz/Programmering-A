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

        public int currency = 9999999; // Petowner starts with these coins

        public int max_pet_nr = -1;  // Antal djur -1 för att Fech_Animal ska fungera
        public int pet_nr = -1;  // Håller reda på vilket djur som är valt. -1 gör att fetch animal loopen loopar tills man skriver in ett djur som finns.
        public int ball_nr = -1; // Håller reda på vilken boll som är vald. -"-

        public int int_age = 0;


        public void Play_Game()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("|                                        Welcome to Joppes Underground Fightclub                                      |");
            Console.WriteLine("=======================================================================================================================");

            Start_Up();
            Console.WriteLine("=======================================================================================================================");
            Menu();

            int avbryt_nr = 0; // avbryt_nr får ett värde som inte är 9. Vilket gör att do/while loopen kan loopa hur många varv som helst genom case/switch menyn, tills meny val nr 9 väljs
            int int_alt = 99; // int_alt deffineras här och får vilken siffra som helst, för att try/catch och switch/case ska fungera.

            do
            {
                try
                {
                    Console.Write("Select a number from 1-8 | [7] = Meny | [Enter] or [Any Other Key] = Repeat latest choice : ");
                    int_alt = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                }

                switch (int_alt)
                {
                    case 1:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 1 : Animal List");
                        Console.WriteLine(" ");
                        List_Animal();
                        break;
                        
                    case 2:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 2 : Feed Animal     It cost 10(c) to feed your animals");
                        Console.WriteLine(" ");
                        Feed_Animal();
                        break;

                    case 3:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 3 : Ball Shop");
                        Ball_Shop();
                        break;

                    case 4:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 4 : Ball List");
                        Console.WriteLine(" ");
                        List_Ball();
                        break;
                        
                    case 5:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 5 : Check Currency");
                        Console.WriteLine(" ");
                        Console.WriteLine("You're currency is: {0}(c)", currency);
                        Console.WriteLine("");
                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine("");
                        break;

                    case 6:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 6 : Fight");
                        Console.WriteLine(" ");

                        Fetch_Ball(); 

                        if (ball_nr != -1)  // Om du har en boll så kan du hemta ett djur och böja fighten
                        {
                            Fetch_Animal();
                            Console.WriteLine("|                                                    Let's Fight!                                                     |");
                            Console.WriteLine("=======================================================================================================================");
                            Console.WriteLine("");

                            pet_list[pet_nr].Interact(ball_list[ball_nr]);  // Här sker fighten nere i Animal classen eller dess underclasser

                            if (ball_list[ball_nr].Check_Durability() <= 0)  // Om bollen går sönder så får Petowner (c) och den trasiga bollen tas bort från listan
                            {
                                
                                if (ball_list[ball_nr].Check_Ball_Name() == "Small Ball ")
                                {
                                    currency = currency + 50;
                                    Console.WriteLine("Congratulations! You have earned 50(c)");
                                }
                                else if (ball_list[ball_nr].Check_Ball_Name() == "Medium Ball")
                                {
                                    currency = currency + 200;
                                    Console.WriteLine("Congratulations! You have earned 200(c)");
                                }
                                else   
                                {
                                    currency = currency + 600;  // if Large Ball
                                    Console.WriteLine("Congratulations! You have earned 600(c)");
                                }
                                Console.WriteLine("");
                                Console.WriteLine("=======================================================================================================================");
                                Console.WriteLine("");
                                ball_list.Remove(ball_list[ball_nr]);
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("\n=======================================================================================================================");
                        Menu();
                        break;

                    case 8:
                        Console.WriteLine("\n=======================================================================================================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 8 : Exit Game");
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
            {                                  // Lägger man till ny matsort så måste man bygga ut i Feed_Animal
                Add_Dog(  0, 8, 200, "Dog", "Bosse  ", "Boxer          ", "Hamburger  ", true, "Woff, woff!!   ");
                Add_Dog(  1, 6, 200, "Dog", "Daicy  ", "Golden Retriver", "Sausage    ", true, "Woffeli, woff!!");
                Add_Puppy(2, 0, 150, "Dog", "Essob  ", "Boxer          ", "Meatballs  ", true, "Beep, beep!!   ", 6);
                Add_Puppy(3, 0, 150, "Dog", "Gunilla", "Tax            ", "Dog Biscuit", true, "Yelp, yelp!!   ", 9);
                Add_Cat(  4, 9, 100, "Cat", "Maja   ", "Tortoiseshell  ", "Tuna       ", true,  0);
                Add_Cat(  5, 2, 100, "Cat", "Oskar  ", "Moggie         ", "Meatballs  ", true,  0);

                max_pet_nr = 5;  // Antal djur -1 för att Fech_Animal ska fungera
            }

            else if (int_age >= 18 && int_age < 150)
            { 
                Add_Dog(  0, 3, 200, "Dog", "Deadly Rabies", "Zombie Dog   ", "Brains  ", false, "Aahhgg!!        ");
                Add_Dog(  1, 9, 200, "Dog", "Black Wolf   ", "Canis Lupus  ", "Raw Meat", false, "Hoowwl!!        ");
                Add_Puppy(2, 0, 150, "Dog", "Lucifer      ", "Demon Hound  ", "Souls   ", false, "Sceek, sceek!!  ", 5);
                Add_Puppy(3, 0, 150, "Dog", "Skellie      ", "Skeleton Dog ", "Bones   ", false, "Rattel, rattel", 8);
                Add_Cat(  4, 5, 100, "Cat", "Fluffy Kitty ", "Killer Cat   ", "Shark   ", false,  0);
                Add_Cat(  5, 4, 100, "Cat", "Lokie        ", "Trickster God", "Souls   ", false,  0);

                max_pet_nr = 5;  // Antal djur -1 för att Fech_Animal ska fungera
            }
        }
                   
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  LIST_ANIMAL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void List_Animal()
        {
            Console.WriteLine("Main Details:");
            Console.WriteLine("");
            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from class
            }
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Extra Details:");
            Console.WriteLine("");
            foreach (var i in pet_list)
            {
                i.PrintDetails();
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  FEED_ANIMAL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Feed_Animal()
        {
            string food_given = "";

            if (currency < 10)
            {
                Console.WriteLine("Your need at least 10(c) to feed the animals");
                Console.WriteLine("");
            }

            else
            {
                currency = currency - 10;  // Det kostar 10(c) för att mata djuren
                Console.WriteLine("Your total currency is reduced to: {0}(c)", currency);
                Console.WriteLine("");
                
                Random random_nr = new Random();
                int check = random_nr.Next(1, 6);  // Check får ett random nr mellan 1 och 5

                if (int_age < 18)
                {
                    if (check == 1)
                    {
                        food_given = "Hamburger  ";
                    }
                    else if (check == 2)
                    {
                        food_given = "Sausage    ";
                    }
                    else if (check == 3)
                    {
                        food_given = "Meatballs  ";
                    }
                    else if (check == 4)
                    {
                        food_given = "Dog Biscuit";
                    }
                    else if (check == 5)
                    {
                        food_given = "Tuna       ";
                    }
                }

                else
                {
                    if (check == 1)
                    {
                        food_given = "Brains  ";
                    }
                    else if (check == 2)
                    {
                        food_given = "Raw Meat";
                    }
                    else if (check == 3)
                    {
                        food_given = "Souls   ";
                    }
                    else if (check == 4)
                    {
                        food_given = "Bones   ";
                    }
                    else if (check == 5)
                    {
                        food_given = "Shark   ";
                    }
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Food Given: {0}", food_given);
                Console.WriteLine("");

                foreach (var i in pet_list)
                {
                    i.Eat(food_given);
                    i.Hungry_Animal();
                }
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  FETCH_ANIMAL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Fetch_Animal()
        {
            pet_nr = -1;  // Varje gång man går in i Fetch_Animal så blir pet_nr = -1, så ingen pet_nr som är vald förut kan kommas ihåg

            foreach (var i in pet_list)
            {
                Console.WriteLine(i);  // Prints the ToString() from classi.PrintDetails();
            }
            
            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Select animal ID nr [0 - {0}]: ", max_pet_nr); // max_pet_nr får sitt värde i Start_Up
                    pet_nr = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error, enter ID nr [0 - {0}]", max_pet_nr);
                }
            } while (pet_nr < 0 || pet_nr > max_pet_nr);  // Om man lägger till fler djur i listan så måste man ändra här också  // Fetch_Animal kan bara brytas om man väljer ett djur som finns
            Console.WriteLine("");
            Console.WriteLine("Animal ID nr {0} is selected", pet_list[pet_nr]);  // ID nr är indentiskt med ordningen i listan
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  LIST_BALL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void List_Ball()
        {
            int max_ball_nr = -1; // Håller reda på hur många bollar man har köpt, om man inte har köpt några bollar så kommer max_ball_nr vara = -1 efter foreach loopen, så man kan söka på bollarna i boll listan

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
                Console.WriteLine("");
            }
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
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
                        Console.WriteLine("");
                        Console.WriteLine("Your total currency is: {0}(c)", currency);
                        Console.WriteLine("");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("What ball do you want to buy? [1]Small 25(c) | [2]Medium 100(c) | [3]Large 300(c) | [4]Exit Ball Shop");
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
                        currency = currency - 25;
                        break;

                    case 2:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 2 : Medium Ball");
                        if (currency < 100)
                        {
                            Console.WriteLine("Your need at least 100(c) to buy a Medium Ball");
                            int_alt = 4;
                        }
                        else
                        {
                            Add_Ball(300, "Silver", "Medium Ball");
                            currency = currency - 100;
                        }
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 3 : Large Ball");
                        if (currency < 300)
                        {
                            Console.WriteLine("Your need at least 300(c) to buy a Large Ball");
                            int_alt = 4;
                        }
                        else
                        {
                            Add_Ball(600, "Gold  ", "Large Ball ");
                            currency = currency - 300;
                        }
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
            Console.WriteLine("");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  FETCH_BALL
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Fetch_Ball()
        {
            ball_nr = -1;  // Varje gång man går in i Fetch_Ball så blir boll_nr = -1, så ingen boll_nr som är vald förut kan kommas ihåg
            int max_ball_nr = -1; // Håller reda på hur många bollar man har köpt, om man inte har köpt några bollar så kommer max_ball_nr vara = -1 efter foreach loopen, så man kan söka på bollarna i boll listan

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
                Console.WriteLine("");
                Console.WriteLine("=======================================================================================================================");
                Console.WriteLine("");
            }

            else
            {
                do
                {
                    try
                    {
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
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
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
            }
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  MENU
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void Menu()
        {
            Console.WriteLine("| Menu :                                                                                                              |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("| [1]  Animal List                                                                                                    |");
            Console.WriteLine("| [2]  Feed Animal                                                                                                    |");
            Console.WriteLine("| [3]  Ball Shop                                                                                                      |");
            Console.WriteLine("| [4]  Ball List                                                                                                      |");
            Console.WriteLine("| [5]  Check Currency                                                                                                 |");
            Console.WriteLine("| [6]  Fight                                                                                                          |");
            Console.WriteLine("| [7]  Menu                                                                                                           |");
            Console.WriteLine("| [8]  Exit Game                                                                                                      |");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                  METHOD  ADD
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public void Add_Cat(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, int hunt_skill)
        {
            pet_list.Add(new Cat(id_nr, age, hp, type, name, breed, fav_food, hungry, hunt_skill));
        }

        public void Add_Dog(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, string bark_sound)
        {
            pet_list.Add(new Dog(id_nr, age, hp, type, name, breed, fav_food, hungry, bark_sound));
        }

        public void Add_Puppy(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, string bark_sound, int months)
        {
            pet_list.Add(new Puppy(id_nr, age, hp, type, name, breed, fav_food, hungry, bark_sound, months));
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
        protected string name, breed, fav_food, type;
        protected bool hungry;

        public Animal(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry)  // Instance constructor
        {
            this.id_nr = id_nr;
            this.age = age;
            this.hp = hp;
            this.type = type;
            this.name = name;
            this.breed = breed;
            this.fav_food = fav_food;
            this.hungry = hungry;
            //Console.Write("The animal is {0}", name);
        }
        
        public override string ToString()
        {
            return string.Format("Animal is a");
        }

        public abstract void PrintDetails();

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                              METHODS  FOR EATING 
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //public string Get_Pet_Name()
        //{
        //    string _name = name;
        //    return _name;
        //}

        //public string Get_Pet_Type()
        //{
        //    string _type = type;
        //    return _type;
        //}
        
        public virtual void Eat(string _food_given)
        {
            if (fav_food == _food_given)
            {
                hungry = false;  // Djuret fick sin favorit mat och är inte hungrig längre
                hp = hp + 5;    // Hp stiger varje gång djuret äter
                Console.WriteLine("Animal Fed: {0}", name);
                //Console.WriteLine("");
                //Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                //Console.WriteLine("");
            }
        }

        public abstract void Hungry_Animal();
        
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                               METHOD  INTERACT
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public virtual void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp <= 0)
                {
                    Console.WriteLine("Your animal {0} has unfortunately fainted :(", name);
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() <= 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 66)  // Bollen har 65% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }
                    
                    else if (check < 91)
                    {
                        hungry = true;  // 25% chans att djuret blir hungrig
                    }

                    else  // 10% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS CAT
      ===========================================================================================================================================================================*/

    public class Cat : Animal  // ChildClass to Animal
    {
        protected int hunt_skill;

        public Cat(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry) : base(id_nr, age, hp, type, name, breed, fav_food, hungry) // Instance constructor
        {
        }

        // Instance constructor with extra parameter
        public Cat(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, int hunt_skill1) : this(id_nr, age, hp, type, name, breed, fav_food, hungry)
        {
            hunt_skill = hunt_skill1;
        }

        public override string ToString()
        {
            return string.Format("ID nr: {0} | {1} {2} Name: {3} | Breed: {4} | Hunger: {5} | Hp: {6} | Hunt Skill: {7}", id_nr, base.ToString(), type, name, breed, hungry, hp, hunt_skill);
        }

        public override void PrintDetails()
        {
            Console.WriteLine("ID nr: {0} | {1} Name: {2} | Age: {3} Years Old | Favorite Food: {4} |", id_nr, type, name, age, fav_food);
        }

        public override void Eat(string _food_given)
        {
            if (fav_food == _food_given)
            {
                hungry = false;  // Djuret fick sin favorit mat och är inte hungrig längre
                hp = hp + 5;    // Hp stiger varje gång djuret äter
                Console.WriteLine("Animal Fed:    " + name);
                //Console.WriteLine("");
                //Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                //Console.WriteLine("");
            }
            else
            {
            }
        }

        public override void Hungry_Animal()
        {
            Random random_nr2 = new Random();
            int check2 = random_nr2.Next(1, 101);  // Check2 får ett random nr mellan 1 och 100

            if (hungry == true)  // Om Cat och är hungrig, så går den på mus jakt
            {
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Animal Hungry: {0}", name);
                Console.WriteLine("");
                Console.WriteLine("Your Cat {0}is Hunting: ", name);
                Console.WriteLine("");
                Console.WriteLine("Will it catch a mouse? Press [Enter] to find out");
                Console.ReadLine();

                if (hunt_skill == 0)
                {
                    if (check2 < 51)  // Cat har fångar en mus med 50% chans, den blir mätt och hunt_skill blir lvl 1
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        hunt_skill = hunt_skill + 1;
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                else if (hunt_skill == 1)
                {
                    if (check2 < 61)  // Cat har fångar en mus med 60% chans, den blir mätt och hunt_skill blir lvl 2
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        hunt_skill = hunt_skill + 1;
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                else if (hunt_skill == 2)
                {
                    if (check2 < 71)  // Cat har fångar en mus med 70% chans, den blir mätt och hunt_skill blir lvl 3
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        hunt_skill = hunt_skill + 1;
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                else if (hunt_skill == 3)
                {
                    if (check2 < 81)  // Cat har fångar en mus med 80% chans, den blir mätt och hunt_skill blir lvl 4
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        hunt_skill = hunt_skill + 1;
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                else if (hunt_skill == 4)
                {
                    if (check2 < 91)  // Cat har fångar en mus med 90% chans, den blir mätt och hunt_skill blir lvl 5
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        hunt_skill = hunt_skill + 1;
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                else if (hunt_skill == 5)
                {
                    if (check2 < 101)  // Cat har fångar en mus med 100% chans, den blir mätt
                    {
                        hungry = false;
                        hp = hp + 5;    // Hp stiger varje gång djuret äter
                        Console.WriteLine("It cought a mouse and is now fed :)");
                    }
                }

                if (hungry == true)
                {
                    Console.WriteLine("No, it did not it is still hungry :(");
                }
                //Console.WriteLine("");
                //Console.WriteLine("=======================================================================================================================");
                //Console.WriteLine("");
            }
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS DOG
      ===========================================================================================================================================================================*/
    public class Dog : Animal  // ChildClass to Animal
    {
        protected string bark_sound;
                                                                                                                                                        // Instance constructor
        public Dog(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry) : base(id_nr, age, hp, type, name, breed, fav_food, hungry) 
        {
        }
                                                                                                                                                       // Instance constructor with extra parameter
        public Dog(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, string bark_sound1) : this(id_nr, age, hp, type, name, breed, fav_food, hungry)
        {
            //Console.WriteLine("Bark sound: {0}", bark_sound1);
            bark_sound = bark_sound1;
        }

        public override string ToString()
        {
            return string.Format("ID nr: {0} | {1} {2} Name: {3} | Breed: {4} | Hunger: {5} | Hp: {6}", id_nr, base.ToString(), type, name, breed, hungry, hp);
        }

        public override void PrintDetails()
        {
            Console.WriteLine("ID nr: {0} | {1} Name: {2} | Age: {3} Years Old | Favorite Food: {4} | Bark Sound: {5}", id_nr, type, name, age, fav_food, bark_sound);
        }

        public override void Hungry_Animal()
        {
            if (hungry == true)
            {
                Console.WriteLine("Animal Hungry: {0} | Barking: {1}", name, bark_sound);
            }
        }
    

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                               METHOD  INTERACT
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public override void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp <= 0)
                {
                    Console.WriteLine("Your animal {0} has unfortunately fainted :(", name);
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    Console.WriteLine(bark_sound);  // Bara för Dog och Puppy
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() <= 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 71)  // Bollen har 70% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        _ball.Lower_Durability();  // Durability 3x för Dog
                        _ball.Lower_Durability();
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }

                    else if (check < 96)
                    {
                        hungry = true;  // 25% chans att djuret blir hungrig
                    }

                    else  // 5% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
        }
    }

    /*===========================================================================================================================================================================
                                                                                                   CLASS PUPPY
      ===========================================================================================================================================================================*/
    public class Puppy : Dog  // ChildClass to Dog
    {
        protected int months;
                                                                                                                                                          // Instance constructor
        public Puppy(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, string bark_sound) : base(id_nr, age, hp, type, name, breed, fav_food, hungry, bark_sound) 
        {
        }
                                                                                                                                     // Instance constructor with extra parameter
        public Puppy(int id_nr, int age, int hp, string type, string name, string breed, string fav_food, bool hungry, string bark_sound, int months1) : this(id_nr, age, hp, type, name, breed, fav_food, hungry, bark_sound)
        {
            months = months1;
        }

        public override string ToString()
        {
            return string.Format("{0} | Puppy | {1} Months Old", base.ToString(), months);
        }

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                               METHOD  INTERACT
          -------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public override void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp <= 0)
                {
                    Console.WriteLine("Your animal {0} has unfortunately fainted :(", name);
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    Console.WriteLine(bark_sound);  // Bara för Dog och Puppy
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() <= 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 71)  // Bollen har 70% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        _ball.Lower_Durability();  // Durability 3x för Dog
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }

                    else if (check < 96)
                    {
                        hungry = true;  // 25% chans att djuret blir hungrig
                    }

                    else  // 5% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
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

        public override string ToString()
        {
            return string.Format("{0} | {1} | Durabilty: {2}", name, color, durability);
        }

        public void Lower_Durability()
        {
            durability = durability -10;
        }
        
        public int Check_Durability()
        {
            int _durability = durability;
            return _durability;
        }

        public string Check_Ball_Name()
        {
            string _name = name;
            return _name;
        }
    }
}