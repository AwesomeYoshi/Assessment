using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStoreAssessment
{
    class Combat
    {
        static Random rnd = new Random();
        public static string n = "";
        public static int a = 0;
        public static int h = 0;

        //The 1st battle combat
        public static void FirstBattle()
        {
            Console.WriteLine("\nYou decided to help the family in need and start to engage with battle with the bandits.");
            Console.ReadKey();
            Enemy q = new Bandit();
            Enemy z = new Enemy();
            
            q.attackerName = "Peter the Bandit";
            int hlt = ((Bandit)q).health = 57;
            int attk = ((Bandit)q).attack = 12;
 
            q.BattleDialouge();
            Console.ReadKey();

            while (hlt > 0 && Program.player.health > 0)
            {
                Console.Clear();
                Console.WriteLine($"{q.attackerName}\nHP: {hlt}\nAttack Power: {attk}\n");
                Console.WriteLine($"{Program.player.name}\nHP: {Program.player.health} Gold: {Program.player.gold}\n");
                Console.WriteLine("////(A)ttack////");
                Console.WriteLine("////(S)hield////");
                Console.WriteLine("////(E)scape////\n");

                string input = Console.ReadLine();

                //The statement if the player wants to attack
                if (input == "A" || input == "Attack")
                {
                    z.BattleDialouge();

                    int damage = attk - (rnd.Next(0, Inventory.SumDefense()));

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attacks = Inventory.SumAttack();

                    if (attacks == 0)
                    {
                        Console.WriteLine("\nYour attack missed!");
                    }

                    Console.WriteLine($"\n{Program.player.name} lose {damage} health and deal {attacks} damage");

                    Program.player.health -= damage;
                    hlt -= attacks;

                    if (Program.player.health <= 0)
                    {
                        Program.gameOver();
                    }


                }
                else if (input == "S" || input == "Shield")
                {
                    z.ShieldDialougue();

                    int damage = (attk / 3) - (rnd.Next(0, Inventory.SumDefense()));

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attacks = rnd.Next(Inventory.SumAttack() / 2);

                    Console.WriteLine("\nYou decided to shielded yourself for this attack." +
                        $" \n{Program.player.name} lose {damage} health and dealt {attacks} attack damage.");

                    Program.player.health -= damage;

                    hlt -= attacks;

                    if (Program.player.health <= 0)
                    {
                        Program.gameOver();
                    }

                }
                //The statement if the player want to run away from the battle
                else if (input == "E" || input == "Escape")
                {
                    Console.WriteLine("You decided to esacape this battle");
                    h = 0;
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
            Console.Clear();

            //Randomized drop gold when the enemy is defeated
            int g = rnd.Next(0, 75);
            Console.WriteLine($"You have defeated the enemy!\nIt dropped {g} gold coins!");
            Program.player.gold += g;
        }

        //The 2nd battle combat
        public static void SecondBattle()
        {
            Enemy bst = new Beast();
            bst.attackerName = "Sol the Beast";
            int hlt = ((Beast)bst).health = 57;
            int attk = ((Beast)bst).attack = 25;

            Console.WriteLine("\nYou made the decision to attack to beast for thier valuable resourses.");
            Console.ReadKey();
            Console.Clear();

            bst.BattleDialouge();
            Console.ReadKey();

            Battle(false, $"{bst.attackerName}", 25, 57);
        }

        //The Last battle combat 
        public static void ThirdBattle()
        {
            Console.WriteLine("You decided to enter the cave and worth the risk of being outside in the rain. You enter the cave and set up camp for the night. Before you could able " +
                "to get some sleep, you heard a noise deep inside the cave. Unable to feel safe because of the noise, you decided to check it out. After couple minutes of searching the source" +
                "you heard the source of the noise, but it was in a dark part of the cave, but you decided to attack whatever is inside, so you can able to go to sleep again.");
            Console.ReadKey();
            Battle(true, "", 0, 0);

        }

        //The method to create the battle combat
        public static void Battle(bool cave, string name, int attack, int health)
        {
            
            Enemy z = new Enemy(); 

            if (cave)
            {
                //The 3rd combat randomized enemies
                if (enemyName() == "Dragon")
                {
                    n = "Dragon";
                    a = rnd.Next(75, 100);
                    h = rnd.Next(76, 100);
                }
                else if (enemyName() == "Bandit")
                {
                    n = "Bandit";
                    a = rnd.Next(10, 36);
                    h = rnd.Next(5, 25);
                }
                else if (enemyName() == "Beast")
                {
                    n = "Beast";
                    a = rnd.Next(37, 74);
                    h = rnd.Next(38, 75);
                }
                else
                {
                    n = "Human";
                    a = rnd.Next(1, 10);
                    h = rnd.Next(1, 10);
                }

            }
            else
            {
                n = name;
                a = attack;
                h = health;
            }


            //The loop of combat until either the player or the enemy health reaches zero
            while (h > 0 && Program.player.health > 0)
            {
                Console.Clear();
                Console.WriteLine($"{n}\nHP: {h}\nAttack Power: {a}\n");
                Console.WriteLine($"{Program.player.name}\nHP: {Program.player.health} Gold: {Program.player.gold}\n");
                Console.WriteLine("////(A)ttack////");
                Console.WriteLine("////(S)hield////");
                Console.WriteLine("////(E)scape////\n");

                string input = Console.ReadLine();

                //The statement if the player wants to attack
                if (input == "A" || input == "Attack")
                {
                    z.BattleDialouge();

                    int damage = a - (rnd.Next(0, Inventory.SumDefense()));

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attacks = rnd.Next(0, Inventory.SumAttack());

                    if (attacks == 0)
                    {
                        Console.WriteLine("\nYour attack missed!");
                    }

                    Console.WriteLine($"\n{Program.player.name} lose {damage} health and deal {attacks} damage");

                    Program.player.health -= damage;
                    h -= attacks;

                    if (Program.player.health <= 0)
                    {
                        Program.gameOver();
                    }

                }
                //The statement if the enemy wants to shield itself
                else if (input == "S" || input == "Shield")
                {
                    z.ShieldDialougue();

                    int damage = (a / 3) - (rnd.Next(0, Inventory.SumDefense()));

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attacks = rnd.Next(Inventory.SumAttack() / 2);

                    Console.WriteLine("\nYou decided to shieled yourself for this attack." +
                        $" \n{Program.player.name} lose {damage} health and dealt {attacks} attack damage.");

                    Program.player.health -= damage;

                    h -= attacks;

                    if (Program.player.health <= 0)
                    {
                        Program.gameOver();
                    }

                }
                //The statement if the player want to run away from the battle
                else if (input == "E" || input == "Escape")
                {
                    Console.WriteLine("You decided to esacape this battle");
                    h = 0;
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
            Console.Clear();

            //Randomized drop gold when the enemy is defeated
            int g = rnd.Next(0, 75);
            Console.WriteLine($"You have defeated the enemy!\nIt dropped {g} gold coins!");
            Program.player.gold += g;

            
        }

        //Reference to randomized the enemy
        public static string enemyName()
        {
            switch (rnd.Next(0, 2))
            {
                case 0:
                    return "Bandit";

                case 1:
                    return "Beast";

                case 2:
                    return "Dragon";
            }
            return "Human";
        }
    } 
}
