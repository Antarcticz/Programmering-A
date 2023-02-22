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

        public int currency = 200; // Petowner starts with 200 coins

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
                    Console.Write("Select a number from 1-8 | [7] = Meny | [Enter] = Repeat latest choice : ");
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
                        Console.WriteLine("You choose option 2 : Feed Animal");
                        Console.WriteLine(" ");
                        //Feed();
                        break;

                    case 3:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 3 : Ball Shop");
                        Console.WriteLine(" ");
                        Ball_Shop();
                        break;

                    case 4:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 4 : Ball List");
                        Console.WriteLine(" ");
                        List_Ball();
                        break;
                        
                    case 5:
                        Console.WriteLine(" ");

                        Console.WriteLine("You choose option 5 : Check Currency");
                        Console.WriteLine(" ");
                        Console.WriteLine("You're currency is: {0}(c)", currency);
                        break;

                    case 6:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 6 : Fight");
                        Console.WriteLine(" ");

                        Fetch_Ball(); 

                        if (ball_nr != -1)  // Om du har en boll så kan du hemta ett djur och böja fighten
                        {
                            Fetch_Animal();
                            Console.WriteLine("=======================================================================================================================");
                            Console.WriteLine("|                                                    Let's Fight!                                                     |");
                            Console.WriteLine("=======================================================================================================================");
                            Console.WriteLine("");

                            pet_list[pet_nr].Interact(ball_list[ball_nr]);  // Här sker fighten nere i Animal classen eller dess underclasser

                            if (ball_list[ball_nr].Check_Durability() == 0)  // Om bollen går sönder så får Petowner (c) och den trasiga bollen tas bort från listan
                            {
                                
                                if (ball_list[ball_nr].Check_Ball_Name() == "Small Ball ")
                                {
                                    currency = currency + 50;
                                    Console.WriteLine("Congratulations you have earned 50(c)");
                                }
                                else if (ball_list[ball_nr].Check_Ball_Name() == "Medium Ball")
                                {
                                    currency = currency + 200;
                                    Console.WriteLine("Congratulations you have earned 200(c)");
                                }
                                else   
                                {
                                    currency = currency + 600;  // if Large Ball
                                    Console.WriteLine("Congratulations you have earned 600(c)");
                                }
                                Console.WriteLine("");
                                Console.WriteLine("=======================================================================================================================");
                                ball_list.Remove(ball_list[ball_nr]);
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine(" ");
                        Console.WriteLine("You choose option 7 : Show Menu again");
                        Menu();
                        break;

                    case 8:
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
                Add_Puppy(2, 0, 150, "Essob  ", "Boxer          ", "Meatballs   ", false, "Beep, beep!!   ", 6);
                Add_Puppy(3, 0, 150, "Gunilla", "Tax            ", "Dog Biscuit ", false, "Yelp, yelp!!   ", 9);
                Add_Cat(  4, 9, 100, "Maja   ", "Tortoiseshell  ", "Tuna        ", false, "Level 0        ");
            }

            else if (int_age >= 18 && int_age < 150)
            { 
                Add_Dog(  0, 3, 200, "Deadly Rabies", "Zombie Dog  ", "Brains  ", false, "Aahhgg!!        ");
                Add_Dog(  1, 9, 200, "Black Wolf   ", "Canis Lupus ", "Raw Meat", false, "Hoowwl!!        ");
                Add_Puppy(2, 0, 150, "Lucifer      ", "Demon Hound ", "Souls   ", false, "Sceek, sceek!!  ", 5);
                Add_Puppy(3, 0, 150, "Skellie      ", "Skeleton Dog", "Bones   ", false, "Rattel, rattel", 8);
                Add_Cat(  4, 5, 100, "Fluffy Kitty ", "Killer Cat  ", "Shark   ", false, "Level 0         ");
            }                            //id_nr, age, hp, name, breed, fav_food, hungry, hunt_skill
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
            }
            
            else
            {
                foreach (var i in ball_list)
                {
                    Console.WriteLine(i);  // Prints the ToString() from class
                }
                Console.WriteLine("");
                Console.WriteLine("=======================================================================================================================");
            }
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
                        Console.WriteLine("Your total currency is: {0}(c)", currency);
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
                            Add_Ball(100, "Silver", "Medium Ball");
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
                            Add_Ball(150, "Gold  ", "Large Ball ");
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

        public void Add_Cat(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string hunt_skill)
        {
            pet_list.Add(new Cat(id_nr, age, hp, name, breed, fav_food, hungry, hunt_skill));
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

        
        public virtual void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp == 0)
                {
                    Console.WriteLine("Your animal {0} is unfortunately dead", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() == 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 81)  // Bollen har 80% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }
                    else if (check < 96)  // 15% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }
                    else hungry = true;  // 5% chans att djuret blir hungrig
                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
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
                                                                                                   CLASS CAT
      ===========================================================================================================================================================================*/

    public class Cat : Animal  // ChildClass to Animal
    {
        protected string hunt_skill;

        public Cat(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry) : base(id_nr, age, hp, name, breed, fav_food, hungry) // Instance constructor
        {
        }

        // Instance constructor with extra parameter
        public Cat(int id_nr, int age, int hp, string name, string breed, string fav_food, bool hungry, string hunt_skill1) : this(id_nr, age, hp, name, breed, fav_food, hungry)
        {
            hunt_skill = hunt_skill1;
        }

        public override void PrintDetails()
        {

            Console.WriteLine("Age: {0} Years Old | HP: {1} | Hungry: {2} | Favorite Food: {3} | Hunt Skill: {4}", age, hp, hungry, fav_food, hunt_skill);
            Console.WriteLine("");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return string.Format("ID nr: {0} | {1}Cat named: {2} | Breed: {3} | Hunger: {4} | Hp: {5} | Hunt Skill: {6}", id_nr, base.ToString(), name, breed, hungry, hp, hunt_skill);
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

        public override void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp == 0)
                {
                    Console.WriteLine("Your animal {0} is unfortunately dead", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() == 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Console.WriteLine(bark_sound + bark_sound);
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 81)  // Bollen har 80% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        _ball.Lower_Durability();  // Dog deals 30 dmg
                        _ball.Lower_Durability();
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }
                    else if (check < 96)  // 15% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }
                    else hungry = true;  // 5% chans att djuret blir hungrig
                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
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
            return string.Format("ID nr: {0} | {1}Dog named: {2} | Breed: {3} | Hunger: {4} | Hp: {5}", id_nr, base.ToString(), name, breed, hungry, hp);
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

        public override void Interact(Ball _ball)  // Metod anrop från Play() pet_list[pet_nr].Interact(ball_list[ball_nr]);
        {

            string str_stop = "";  // Spel loopen stoppas ändast om spelaren skriver in att str_stop = x
            do
            {
                if (hp == 0)
                {
                    Console.WriteLine("Your animal {0} is unfortunately dead", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (hungry == true)
                {
                    Console.WriteLine("Your animal {0} is hungry, it has to get fed before it can play again", name);
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else if (_ball.Check_Durability() == 0)
                {
                    Console.WriteLine("The ball got destroyed, durability is {0}", _ball.Check_Durability());
                    Console.WriteLine("");
                    str_stop = "x";
                }

                else
                {
                    Console.WriteLine(bark_sound + bark_sound);
                    Random random_nr = new Random();
                    int check = random_nr.Next(1, 101);  // Check får ett random nr mellan 0 och 100
                    if (check < 81)  // Bollen har 80% chans att ta skada
                    {
                        //Console.WriteLine("Interact" + _ball);
                        _ball.Lower_Durability();
                        _ball.Lower_Durability();  // Puppy deals 20 dmg
                        Console.WriteLine("Ball Damage Taken!");
                        Console.WriteLine("");
                    }
                    else if (check < 96)  // 15% chans att djuret tar skada
                    {
                        hp = hp - 10;
                        Console.WriteLine("Animal Damage Taken!");
                        Console.WriteLine("");
                    }
                    else hungry = true;  // 5% chans att djuret blir hungrig
                    Console.WriteLine("Animal: {0} | Hp: {1} | Hunger: {2}", name, hp, hungry);
                    Console.WriteLine("");
                    Console.WriteLine("Ball: " + _ball);

                    Console.WriteLine("");
                    Console.WriteLine("Press [x] if you want to stop the fight, press any key to continue");
                    Console.WriteLine("=======================================================================================================================");
                    str_stop = Console.ReadLine();
                }
            } while (str_stop != "x");
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

        public override string ToString()
        {
            return string.Format("{0} | {1} | Durabilty: {2}", name, color, durability);
        }
    }
}