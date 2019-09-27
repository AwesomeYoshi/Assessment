using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPGStoreAssessment
{
    class Inventory
    {
        public List<Item> ItemList = new List<Item>();
        public string fn;

        //The method of the shop
        public void Shop(Inventory customer)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the shop!");
            Console.WriteLine("\nThe swords are avaliable on the shop\n");
            WeaponList();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("What would you like to do?!\n");
            Console.ReadKey();

            string inputShop = "";


            //Loops the method until the player want to leave the shop
            while (inputShop != "3" && inputShop != "Leave")
            {
                inputShop = "";
                while (inputShop != "1" && inputShop != "Buy" && inputShop != "2" && inputShop != "Sell" && inputShop != "3" && inputShop != "Leave")
                {
                    inputShop = Console.ReadLine();
                    Console.WriteLine("Please input the following choices!\n1.Buy\n2.Sell\n3.Leave");
                    
                }

                //Statement if the player wants to go to the shop
                if (inputShop == "1" || inputShop == "Buy")
                {
                    ShowStoreList();
                    Console.WriteLine("Enter the #ID you want to buy.");
                    Console.WriteLine($"{Program.player.gold} gold");

                    int boughtItem;

                    while (!int.TryParse(Console.ReadLine(), out boughtItem)) ;

                    while (Program.player.gold < ItemList[boughtItem].buy)
                    {
                        Console.WriteLine("Purchase something you can afford!");
                        while (!int.TryParse(Console.ReadLine(), out boughtItem)) ;

                    }

                    Console.WriteLine($"\nYou bought the: \n");
                    ShowObject(ItemList[boughtItem]);

                    if (Program.player.gold > ItemList[boughtItem].buy)
                    {
                        Program.player.gold -= ItemList[boughtItem].buy;
                        customer.ItemList.Add(ItemList[boughtItem]);
                        Console.WriteLine($"Currency:{Program.player.gold} gold");
                    }

                }
                //Statement if the player want to sell an item from your inventory
                else if (inputShop == "2" || inputShop == "Sell")
                {
                    Console.Clear();

                    for(int idx = 0; idx < customer.ItemList.Count; ++idx)
                    {
                        Console.WriteLine($"#ID: {customer.ItemList[idx].itemId -1}, Name: {customer.ItemList[idx].itemName}, Buy: {customer.ItemList[idx].buy}, Sell: {customer.ItemList[idx].sell}, Attack: {customer.ItemList[idx].attack}" +
                        $", Defense: {customer.ItemList[idx].defense}, Heal: {customer.ItemList[idx].heal}\n");
                    }

                  
                    int sellItem;
                    Console.WriteLine("Enter the ID of the item you want to sell.");
                    while (!int.TryParse(Console.ReadLine(), out sellItem)) ;
                    ShowObject(ItemList[sellItem]);

                    Console.WriteLine($"\nYou sold the:\n");
                    customer.ItemList.Remove(ItemList[sellItem]);

                    Program.player.gold += ItemList[sellItem].sell;
                    Console.WriteLine($"\nCurrency:{Program.player.gold} gold");


                }
                //Statement if the player want to leave the shop
                else if (inputShop == "3" || inputShop == "Leave")
                {
                    Console.Clear();
                    Console.WriteLine("You finished your business here and started to head out of the shop.");
                    Console.ReadLine();
                }
            }
           
        }
        //
        public void LoadCSV(string StoreItems)
        {
            List<string> ShopItems = new List<string>();
            fn = StoreItems;
            using (StreamReader sr = new StreamReader(StoreItems))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    ShopItems.Add(sr.ReadLine());
                }
            }

            string[] Values;

            List<Item> items = new List<Item>();

            foreach (string line in ShopItems)
            {
                Values = line.Split(',');
                Item tmpitem = new Item();
                tmpitem.itemId = int.Parse(Values[0]);
                tmpitem.itemName = Values[1];
                tmpitem.buy = int.Parse(Values[2]);
                tmpitem.sell = int.Parse(Values[3]);
                tmpitem.attack = int.Parse(Values[4]);
                tmpitem.defense = int.Parse(Values[5]);
                tmpitem.heal = int.Parse(Values[6]);
                ItemList.Add(tmpitem);
            }
            Console.ReadKey();
        }

        public void SaveCSV()
        {
            using (StreamWriter sw = new StreamWriter(fn))
            {
                sw.WriteLine("ItemID,ItemName,Buy,Sell,Attack,Defense,Heal");

                foreach(Item tem in ItemList)
                {
                    sw.WriteLine($"{tem.itemName},{tem.buy},{tem.sell}," +
                    $"{tem.attack},{tem.defense},{tem.heal}");
                }
                sw.Close();
            }
        }

        //To display want is in the store
        public void ShowStoreList()
        {
            Console.Clear();
            for (int idx = 0; idx < ItemList.Count; idx++)
            {
                Console.WriteLine($"#ID: {idx}, Name: {ItemList[idx].itemName}, Buy: {ItemList[idx].buy}, Sell: {ItemList[idx].sell}, Attack: {ItemList[idx].attack}" +
                    $", Defense: {ItemList[idx].defense}, Heal: {ItemList[idx].heal}\n");
                
            }
        }
        //To display the item you bought from the store or to display the item your sold to the store
        public void ShowObject(Item itm)
        {
            Console.WriteLine($"Name: {itm.itemName}\nBuy: {itm.buy}\nSell: {itm.sell}\n" +
                $"Attack: {itm.attack}\nDefense: {itm.defense}\nHeal: {itm.heal}");
        }

        public void WeaponList()
        {
            foreach(Item it in ItemList)
            {
                if(it.attack > 0)
                {
                    Console.WriteLine($"Name: {it.itemName}\nBuy: {it.buy}\nSell: {it.sell}\n" +
                                    $"Attack: {it.attack}\nDefense: {it.defense}\nHeal: {it.heal}\n");
                }
            }

        }
        public static int SumDefense()
        {
            int sum = 0;
            foreach (Item it in Program.Invent.ItemList)
            {
                sum += it.defense;
            }
            return Program.player.armorValue + sum;
        }


        public static int SumAttack()
        {
            int sum = 0;
            foreach(Item it in Program.Invent.ItemList)
            {
                sum += it.attack;
            }
            return Program.player.attack + sum;
        }
    }
}
