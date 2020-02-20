using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBadges_Repository
{
    public class KBadges_UI
    {
        KBadges_Methods _repo = new KBadges_Methods();
        public void Run()
        {
            _repo.SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Badge Security System. Please select what you'd like to do.\n" +
                    "1. See All Badges\n" +
                    "2. Add New Badge\n" +
                    "3. Edit Existing Badge\n" +
                    "4. Exit Program");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();

                        _repo.ListAllBadges();
                        break;
                    case "2":
                        Console.Clear();
                        List<string> doorList = new List<string>();
                        Console.WriteLine("What is the new badge ID?");
                        string key = Console.ReadLine();
                        bool stillAddingDoors = true;
                        while (stillAddingDoors)
                        {
                            Console.WriteLine("What door do you want to give this badge access to?");
                            string newDoor = Console.ReadLine();
                            doorList.Add(newDoor);
                            Console.WriteLine("Would you like to add another door? (Y/N)");
                            string ynInput = Console.ReadLine();
                            string loweredYNInput = ynInput.ToLower();
                            switch (loweredYNInput)
                            {
                                case "y":
                                    stillAddingDoors = true;
                                    break;
                                case "n":
                                    stillAddingDoors = false;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Something went wrong with your input. Returning to main menu...");
                                    Console.Clear();
                                    stillAddingDoors = false;
                                    break;
                            }
                        }
                        _repo.AddNewBadge(key, doorList);
                        break;
                    case "3":
                        Console.WriteLine("Which badge would you like to update?");
                        string keyInputForSearch = Console.ReadLine();
                        
                        if (_repo.SearchByID(keyInputForSearch))
                        {
                            Console.ReadLine();
                            Console.Clear();
                            bool isStillRunning = true;
                            while (isStillRunning)
                            {
                                Console.WriteLine("What would you like to do?\n" +
                                    "1. Update Door Access\n" +
                                    "2. Delete All Door Access\n" +
                                    "3. Back to Main Menu");
                                string userResponse = Console.ReadLine();
                                switch (userResponse)
                                {
                                    case "1":
                                            _repo.DeleteAllDoors(keyInputForSearch);
                                        bool keepRunning = true;
                                        while (keepRunning)
                                        {
                                            Console.WriteLine("What doors would you like to give this badge access to?");
                                            string newDoorValue = Console.ReadLine();
                                            _repo.UpdateDoors(keyInputForSearch, newDoorValue);
                                            Console.WriteLine("Would you like to add another door? (Y/N)");
                                            string response = Console.ReadLine();
                                            string loweredResponse = response.ToLower();
                                            switch (loweredResponse)
                                            {
                                                case "y": keepRunning = true;
                                                    Console.Clear();
                                                    break;
                                                case "n": keepRunning = false;
                                                    Console.Clear();
                                                    break;
                                                default: Console.WriteLine("Something went wrong with your input. Please enter \"Y\" or \"N\". Press any button to continue...");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                            }
                                        }
                                        break;
                                    case "2": _repo.DeleteAllDoors(keyInputForSearch);

                                        Console.WriteLine("All door access has been revoked. Press any button to continue.");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "3":
                                        isStillRunning = false;
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.WriteLine("Something went wrong with your input. Please try again.");
                                        Console.ReadLine();
                                        Console.Clear();
                                        isStillRunning = true;
                                        break;
                                }
                            }
                        }
                        else
                        {
                        Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please select one of the given numbers. Press any button to return to the main menu...");
                        Console.ReadLine();
                        Console.Clear();
                        isRunning = true;
                        break;
                }
            }
           
        }
    }
}
