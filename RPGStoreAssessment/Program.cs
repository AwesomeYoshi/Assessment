using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RPGStoreAssessment
{
    class Program
    {
        public static Player player = new Player();
        public static Combat combat = new Combat();
        
        
        static void Main(string[] args)
        {
            gameTitle();

        }
        public static void gameTitle()
        {
            Console.WriteLine("THE GREAT TEXT ADVENTURE!");
            Console.ReadKey(); 
            start();
        
        }
        public static void start()
        {
            Console.WriteLine("Enter your character's name.");
            player.name = Console.ReadLine();
            if (player.name == "")
            {
                player.name = "Bob";
                Console.WriteLine($"Since you did not enter a name, I will just give you the default of {player.name}!");
            }
            else
            {
                Console.WriteLine($"Hello {player.name}! Good luck on your adventure!");
            }
            Console.ReadKey();
            Console.Clear();
            Adventure();
        }
            public static Inventory Shop = new Inventory();
            
            public static Inventory Invent= new Inventory();
            

        public static void Adventure()
        {
              
            Shop.LoadCSV("StoreItems.csv");
            
            Invent.LoadCSV("PlayerInvent.csv");
            Console.WriteLine("You started to leave your hometown to be able to find some fortune, so you can support your family and " +
                "maybe find some nice things on your adventure!");
            Console.WriteLine($"Before you left, you remember that your mother ask you if you wanted anything for the adventure. You said you wanted...\n");
            Console.ReadKey();

            Console.WriteLine("1. Sword! \n2. Shield!\n");
          
            string inputA = Console.ReadLine();
      

            while(inputA != "1" && inputA != "Sword" && inputA != "2" && inputA != "Shield")
            {
                Console.WriteLine("Please input the following choices!");
                inputA = Console.ReadLine();
                Console.ReadKey();
            }
            
            if(inputA == "1" || inputA == "Sword")
            {
                Console.WriteLine("...a sword! To be able to attack the monster better and quicker.");
                Console.WriteLine("*You aquire the Wooden Sword!*");
                Console.ReadKey();
                Console.WriteLine("But it doen't matter, she gave you a  wooden shield anyaway.");

            }
            else if (inputA == "2" || inputA == "Shield")
            {
                Console.WriteLine("...a shield! To be able to survive longer from foes.");
                Console.WriteLine("*You aquire the Wooden Shield!*");
                Console.ReadKey();
                Console.WriteLine("But it doen't matter, she gave you a wooden sword anyaway.");
            }
            
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Before you start your adveture, you stop by the shop.");
            Console.ReadLine();
            Shop.ShowStoreList();
            Shop.Shop(Invent);
            Shop.SaveCSV();
            Console.Clear();

            Console.WriteLine("So begun your adventure looking for loot and riches, but after about 30 minutes into your adveture you encounter a bandit trying to rob" +
                " a family of thier prize cow. The family tried the best to defend themselves but couldn't. You decide to...\n");

            Console.ReadKey();

            Console.WriteLine("1. (Help) the family! \n2. (Ignore) them. \n3. Go back (Home). \n");

            string inputB = Console.ReadLine();

            while (inputB != "1" && inputB != "Help" && inputB != "2" && inputB != "Ignore" && inputB != "3" && inputB != "Home")
            {
                Console.WriteLine("Please input the following choices!");
                inputB = Console.ReadLine();
                Console.ReadKey();
            }

            if (inputB == "1" || inputB == "Help")
            {
                Combat.FirstBattle();
                Console.WriteLine("After your victorious battle agaist the bandit, the family thank you for the help and gave you some gold." +
                    "You thank them for the stuff and started to head back on your journey.");

            }
            else if (inputB == "2" || inputB == "Ignore")
            {
                Console.WriteLine("...to ignore that the situation since it doesn't inlvolve you.");
            }
            else if (inputB == "3" || inputB == "Home")
            {
                Home();
            }


            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Before you start your 2nd adventure, you stop by the shop.");
            Console.ReadLine();
            Shop.ShowStoreList();
            Shop.Shop(Invent);
            Shop.SaveCSV();
            Console.Clear();


            Console.WriteLine("As you continued on your adventure you spotted some beast in the distance just eating in peace. " +
                "But you know that if you hunt down beast and sell their meat to the shop, you will make a lot of money." +
                "You decide to...\n");
            Console.ReadKey();

            Console.WriteLine("1. Engage in battle! \n2. Leave them in peace. \n3. Go back (Home).");

            string inputC = Console.ReadLine();


            while (inputC != "1" && inputC != "Help" && inputC != "2" && inputC != "Ignore" && inputC != "3" && inputC != "Home")
            {
                Console.WriteLine("Please input the following choices!");
                inputC = Console.ReadLine();
                Console.ReadKey();
            }

            if (inputC == "1" || inputC == "Help")
            {
                Combat.SecondBattle();
                Console.WriteLine("After your tough battle agaist the beast, you collected its resources and started to head back on your journey.");
            }
            else if (inputC == "2" || inputC == "Ignore")
            {
                Console.WriteLine("...to leave the beast in peace because your afraid you might lose the battle.");
            }
            else if (inputC == "3" || inputC == "Home")
            {
                Home();
            }

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Before you start your 3rd adventure, you stop by the shop.");
            Console.ReadLine();
            Shop.ShowStoreList();
            Shop.Shop(Invent);
            Shop.SaveCSV();
            Console.Clear();

            Console.WriteLine("After encountering the beast you continue on your adventure. Couple hours later, the sun was about to set and it looks like it is going to rain" +
                "anytime soon. But then you spotted a cave in the distance and thought to yourself if you should use that cave as shelter? But you thought it might contain " +
                "a bandit, a beast, or maybe a big dragon! You decided to...\n");

            Console.ReadKey();

            Console.WriteLine("1. (Enter) the cave! \n2. (Find) shelter elsewhere. \n3. Go back (Home). \n");

            string inputD = Console.ReadLine();

            while (inputD != "1" && inputD != "Enter" && inputD != "2" && inputD != "Find" && inputD != "3" && inputD != "Home")
            {
                Console.WriteLine("Please input the following choices!");
                inputD = Console.ReadLine();
                Console.ReadKey();
            }

            if (inputD == "1" || inputD == "Enter")
            {
                Combat.ThirdBattle();
                Console.WriteLine("You defeated the enemy inside and grab whatever loot it dropped in the dark. As you was going back, you wonder if the person you just fought was either " +
                    "fighting or defending thierselves from me. Oh well, You can able to go to sleep again.");

            }
            else if (inputD == "2" || inputD == "Find")
            {
                Console.WriteLine("You decided that being in a cave with maybe a dangerous enemy isn't worth the risk. " +
                    "So you decided just to be under some trees and camp under it for the night.");
            }
            else if (inputD == "3" || inputD == "Home")
            {
                Home();
            }

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You have reach your destination. You stop by the shop one more time and sell all you items and loot, so you can make a profit.");
            Console.ReadKey();
          
            Shop.ShowStoreList();
            Shop.SaveCSV();
            Shop.Shop(Invent);

            if (Program.player.gold >= 100)
            {
                Console.Clear();
                Console.WriteLine($"You have gather {Program.player.gold} gold. That is enough to help support yourself and your family for a long while.");
                Console.ReadLine();
                Console.WriteLine("You Win!");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have failed you make over 100 coins. You don't have enough money to support your family amd youself. So you gave the remaining gold" +
                    $" of {Program.player.gold} to your family, while you go on another dangerous adventure to make more money.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Bad Ending");
                Console.ReadKey();
            }
        }

        public static void gameOver()
        {
            Console.WriteLine("You suffered to much damage and died on the spot.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        public static void Home()
        {
            Console.Clear();
            Console.WriteLine("You decided that this journey was harder than you thought and start heading home.");
            Console.WriteLine("Game Over!");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
    }
}
