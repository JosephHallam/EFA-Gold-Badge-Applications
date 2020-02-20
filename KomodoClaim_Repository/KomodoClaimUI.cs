using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim_Repository
{
    public class KomodoClaimUI
    {
        Claim_Repository _repo = new Claim_Repository();
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

                Console.WriteLine("Welcome to the Komodo Insurance Claims Service! Please select what you'd like to do.\n" +
                    "1. See All Unaddressed Claims\n" +
                    "2. Address A Claim\n" +
                    "3. Enter New Claim\n" +
                    "4. Exit Program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplayAllClaims();
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        AddressNextClaim();
                        Console.Clear();
                        break;
                    case "3":
                        AddNewClaim();
                        Console.Clear();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void AddressNextClaim()
        {
            if (_repo.CountNumberOfClaimsInQueue() > 0)
            {
                bool addressNewClaimRunning = true;
                while (addressNewClaimRunning)
                {

                    Console.Clear();

                    _repo.ShowNextClaim();
                    Console.WriteLine("Would you like to address this claim? (Y/N)");
                    string response = Console.ReadLine();
                    string loweredResponse = response.ToLower();
                    switch (loweredResponse)
                    {
                        case "y":
                            bool approveDenyRunning = true;
                            while (approveDenyRunning)
                            {

                                Console.WriteLine("What would you like to do?\n" +
                                    "1. Approve Claim\n" +
                                    "2. Deny Claim");
                                string userResponse = Console.ReadLine();
                                switch (userResponse)
                                {
                                    case "1":
                                        _repo.RemoveClaim();
                                        Console.WriteLine("Okay, this claim has been approved. Press any key to continue...");
                                        Console.ReadLine();
                                        approveDenyRunning = false;
                                        break;
                                    case "2":
                                        _repo.RemoveClaim();
                                        Console.WriteLine("Okay, this claim has been denied. Press any key to continue...");
                                        Console.ReadLine();
                                        approveDenyRunning = false;
                                        break;
                                    default:
                                        Console.WriteLine("Something went wrong with your input. Please enter 1 or 2");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadLine();
                                        approveDenyRunning = true;
                                        break;
                                }
                            }
                            addressNewClaimRunning = false;
                            break;
                        case "n":
                            Console.WriteLine("Returning to the main menu. Press any key to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            addressNewClaimRunning = false;
                            break;
                        default:
                            Console.WriteLine("Something went wrong with your input. Please enter \"Y\" or \"N\"");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                            addressNewClaimRunning = true;
                            break;

                    }

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no more claims to address. Press any key to return to the Main Menu.");
                Console.ReadLine();
            }
        }
        public void AddNewClaim()
        {
            Claim newestClaim = new Claim();

            bool idRunning = true;
            while (idRunning)
            {

                Console.Clear();
                Console.WriteLine("What is the claim's ID #?");
                string idInput = Console.ReadLine();
                bool success = Int32.TryParse(idInput, out int id);
                if (success)
                {
                    Console.WriteLine("Your ID # has been stored.");
                    newestClaim.ID = id;
                    idRunning = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter just a number");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    idRunning = true;
                }
            }
            bool claimTypeRunning = true;
            while (claimTypeRunning)
            {

                Console.WriteLine("What is the type of the claim?\n" +
                    "1. Home\n" +
                    "2. Auto\n" +
                    "3. Theft\n" +
                    "4. Health");
                string typeInput = Console.ReadLine();
                switch (typeInput)
                {
                    case "1":
                        newestClaim.ClaimType = ClaimType.Home;
                        Console.WriteLine("The type of claim is Home. Press any key to continue...");
                        Console.ReadLine();
                        claimTypeRunning = false;
                        break;
                    case "2":
                        newestClaim.ClaimType = ClaimType.Auto;
                        Console.WriteLine("The type of claim is Auto. Press any key to continue...");
                        Console.ReadLine();
                        claimTypeRunning = false;
                        break;
                    case "3":
                        newestClaim.ClaimType = ClaimType.Theft;
                        Console.WriteLine("The type of claim is Theft. Press any key to continue...");
                        Console.ReadLine();
                        claimTypeRunning = false;

                        break;
                    case "4":
                        newestClaim.ClaimType = ClaimType.Health;
                        Console.WriteLine("The type of claim is Health. Press any key to continue...");
                        Console.ReadLine();
                        claimTypeRunning = false;

                        break;
                    default:
                        Console.WriteLine("Something went wrong with your input. Please enter just a number.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        claimTypeRunning = true;

                        break;
                }
            }
            Console.WriteLine("Please enter a description of the incident.");
            newestClaim.Description = Console.ReadLine();
            bool amountRunning = true;
            while (amountRunning)
            {

                Console.WriteLine("Please enter the amount. (No $ Sign)");
                string amountAsString = Console.ReadLine();
                bool works = decimal.TryParse(amountAsString, out decimal amount);
                if (works)
                {
                    newestClaim.Amount = amount;
                    Console.WriteLine("Your amount has been stored. Press any key to continue...");
                    Console.ReadLine();
                    amountRunning = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter just a number with no symbols or letters.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    amountRunning = true;
                }
            }
            bool incidentDateRunning = true;
            while (incidentDateRunning)
            {
                Console.WriteLine("Please enter the date the incident occurred. (e.g 11/04/1997)");
                string incidentAsString = Console.ReadLine();
                bool good = DateTime.TryParse(incidentAsString, out DateTime date);
                if (good)
                {
                    newestClaim.Date_of_Incident = date;
                    Console.WriteLine("The Incident Date has been stored. Press any key to continue...");
                    Console.ReadLine();
                    incidentDateRunning = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter in the format \"11/04/1997\"");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    incidentDateRunning = true;
                }
            }
            bool claimDateRunning = true;
            while (claimDateRunning)
            {
                Console.WriteLine("Please enter the date the claim was filed. (e.g 11/04/1997)");
                string claimAsString = Console.ReadLine();
                bool yes = DateTime.TryParse(claimAsString, out DateTime date2);
                if (yes)
                {
                    newestClaim.Date_of_Claim = date2;
                    Console.WriteLine("The Claim Date has been stored. Press any key to continue...");
                    Console.ReadLine();
                    claimDateRunning = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter in the format \"11/04/1997\"");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    claimDateRunning = true;
                }
            }
            _repo.AddNewClaim(newestClaim);
            Console.WriteLine("Your Claim has been added. Press any key to return to the Main Menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
