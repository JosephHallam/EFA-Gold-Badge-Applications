using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public List<string> IngredientList { get; set; }
        public decimal Price { get; set; }
        public MenuItem() { }
        public MenuItem(string name, int itemNumber, string description, List<string> ingredientList, decimal price)
        {
            Name = name;
            ItemNumber = itemNumber;
            Description = description;
            IngredientList = ingredientList;
            Price = price;
        }
    }
    public class MenuRepository
    {
        List<MenuItem> listOfItems = new List<MenuItem>();
        public void SeedContent()
        {
            List<string> ingredients = new List<string>() { "Noodles", "Tomato", "Basil", "Pork Meatballs" };
            MenuItem spaghetti = new MenuItem("Spaghetti", 1, "A simple, yet delicious pasta dish.", ingredients, 14.95m);
            listOfItems.Add(spaghetti);
        }
        public bool AddItem()
        {
            Console.Clear();
            bool wasAdded;
            MenuItem newItem = new MenuItem();
            Console.WriteLine("Please enter the item's name.");
            newItem.Name = Console.ReadLine();
            bool continueTryParse = true;
            while (continueTryParse)
            {
                Console.WriteLine("Please give this item a number.");
                string numInput = Console.ReadLine();
                bool success = Int32.TryParse(numInput, out int number);
                if (success)
                {
                    newItem.ItemNumber = number;
                    continueTryParse = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter just a number.");
                    continueTryParse = true;
                }
            }
            Console.WriteLine("Add the item's description");
            newItem.Description = Console.ReadLine();
            newItem.IngredientList = new List<string>();
            bool continueToRun = true;
            while (continueToRun == true)
            {
                Console.WriteLine("Would you like to an ingredient to the list of ingredients?\n" +
                    "1) Yes\n" +
                    "2) No");
                string ingredientAnswer = Console.ReadLine();
                switch (ingredientAnswer)
                {
                    case "1":
                        Console.WriteLine("What is the name of the ingredient?");
                        string ingredientName = Console.ReadLine();
                        newItem.IngredientList.Add(ingredientName);
                        break;
                    default:
                        continueToRun = false;
                        break;

                }
            }
            bool weStillTryinToParse = true;
            while (weStillTryinToParse)
            {
                Console.WriteLine("Please enter this item's price (Written like '12.95') Do not inclue the dollar sign");
                string decInput = Console.ReadLine();
                bool success = decimal.TryParse(decInput, out decimal number);
                if (success)
                {
                    newItem.Price = number;
                    weStillTryinToParse = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter just a number.");
                    weStillTryinToParse = true;
                }
            }
            listOfItems.Add(newItem);
            if (listOfItems.Contains(newItem))
            {
                Console.WriteLine("Great! Your item has been added.");
                wasAdded = true;
            }
            else
            {
                Console.WriteLine("Something went wrong and your item was not added. Please try again.");
                wasAdded = false;
            }
            Console.ReadLine();
            return wasAdded;
        }


        public bool DeleteItemByName(string name)
        {
            Console.Clear();
            foreach (MenuItem content in listOfItems)
            {
                if (content.Name.ToLower() == name.ToLower())
                {
                    listOfItems.Remove(content);
                    Console.WriteLine("Congratulations, your item has been deleted from the menu.");
                    Console.ReadLine();
                    return true;
                }
            }
            Console.WriteLine("Something has gone wrong. Please try again.");
            Console.ReadLine();
            return false;

        }
        public void DisplayAllItems()
        {
            Console.Clear();
            foreach (MenuItem item in listOfItems)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.ItemNumber);
                Console.WriteLine(item.Description);
                string ingredientString = string.Join(", ", item.IngredientList);
                Console.WriteLine(ingredientString);
                Console.WriteLine($"${item.Price}");
                Console.WriteLine("\n");
            }
            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
    }
}
