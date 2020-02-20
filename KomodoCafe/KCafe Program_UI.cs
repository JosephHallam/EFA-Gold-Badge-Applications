using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class KCafe_Program_UI
    {
        MenuRepository _menurepo = new MenuRepository();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {

            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome! Please select what you'd like to do.");
                Console.WriteLine("1) Show all added items:\n" +
                    "2) Add an Item:\n" +
                    "3) Delete an Existing item by name:\n" +
                    "4) Exit the program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        _menurepo.DisplayAllItems();
                        break;
                    case "2":
                        _menurepo.AddItem();
                        break;
                    case "3":
                        Console.WriteLine("Enter the name of the item you'd like to delete.");
                        string name = Console.ReadLine();
                        _menurepo.DeleteItemByName(name);
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-4.");
                        Console.ReadLine();
                        break;
                }
                    

            }



        }
    }
}
