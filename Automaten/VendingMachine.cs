using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automaten
{
    public class VendingMachine
    {
        ItemsMethods itemsMethods = new ItemsMethods();

        //Starts the VendingMachine.
        public void MachineGoGo()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Main menu:");
                Console.WriteLine("1. Show all items.");
                Console.WriteLine("2. Buy Item");
                Console.WriteLine("3. Add new item.");
                Console.WriteLine("4. Quit.");
                string vendingMenu = Console.ReadLine();
                switch (vendingMenu)
                {
                    case "1":
                        ShowAllItemsMachine(itemsMethods);
                        break;
                    case "2":
                        BuyItem(itemsMethods);
                        break;
                    case "3":
                        AddNewItemToMachine(itemsMethods);
                        break;
                    case "4":
                        running = false;
                        Environment.Exit(4);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Outtahear!");
                        Console.ReadLine();
                        return;
                }
            }
            Console.Clear();
            Console.ReadKey();
        }

        private static void AddNewItemToMachine(ItemsMethods itemsMethods)
        {
            Console.Clear();
            int id;
            while (true)
            {
                Console.Write("Enter #:");
                string idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out id))
                {
                    Console.WriteLine("Invalid input. Please enter valid input: #.");
                }
                else if (itemsMethods.ItemExists(id))
                {
                    Console.WriteLine("An item with the same ID already exists. Please enter a different ID.");
                }
                else
                {
                    break;
                }
            }
            string name;
            while (true)
            {
                Console.Write("Enter name of item:");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
                else if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Name cannot contain numbers. Please enter a valid name.");
                }
                else
                {
                    break;
                }
            }
            double price;
            while (true)
            {
                Console.WriteLine("Enter price of item:");
                string priceInput = Console.ReadLine();
                if(!double.TryParse(priceInput, out price) || price < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive and valid price.");
                }
                else
                {
                    break;
                }
            }
            int quantity;
            while (true)
            {
                Console.WriteLine("Enter Quantity of item:");
                string quantityInput = Console.ReadLine();
                if(!int.TryParse(quantityInput, out quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid non-negative number for quantity.");
                }
                else
                {
                    break;
                }
            }
            itemsMethods.NewItem(id, name, price, quantity);
            Console.WriteLine("New Item has been added.");
            Console.ReadKey();
        }
        private static void ShowAllItemsMachine(ItemsMethods itemsMethods)
        {
            Console.Clear();
            itemsMethods.ShowAllItems();
            Console.ReadKey();
        }
        private static void BuyItem(ItemsMethods itemsMethods)
        {
            Console.Clear();
            itemsMethods.ShowAllItems();
            int id;
            while (true)
            {
                Console.WriteLine("Press #:");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number.");
                }
            }
            double moneyInserted;
            while (true)
            {
                Console.Write("Insert money: ");
                if (double.TryParse(Console.ReadLine(), out moneyInserted))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Insert money");
                }
            }
            itemsMethods.BuyItem(id, moneyInserted);
        }
    }
}
