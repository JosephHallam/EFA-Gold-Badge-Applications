using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaim_Repository
{
    public enum ClaimType { Auto, Home, Theft, Health }
    public class Claim
    {
        public int ID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date_of_Incident { get; set; }
        public DateTime Date_of_Claim { get; set; }
        public bool Is_Valid { get; set; }
        public Claim() { }
        public Claim(int id, ClaimType claimType, string description, decimal amount, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            id = ID;
            claimType = ClaimType;
            description = Description;
            amount = Amount;
            incidentDate = Date_of_Incident;
            claimDate = Date_of_Claim;
            isValid = Is_Valid;
        }
    }
    public class ClaimRepository
    {
        Queue<Claim> _claimQueue = new Queue<Claim>();
        Claim newClaim = new Claim();
        public bool AddNewClaim()
        {
            bool wasAdded;
            int initialQueueLength = _claimQueue.Count;
            Console.Clear();
            bool continueTryParse = true;
            while (continueTryParse)
            {
                Console.WriteLine("Please enter the claim ID.");
                string claimID = Console.ReadLine();
                bool success = Int32.TryParse(claimID, out int number);
                if (success)
                {
                    newClaim.ID = number;
                    continueTryParse = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter just a number.");
                    continueTryParse = true;
                }
            }
            Console.Clear();
            Console.WriteLine("Please enter the claim type\n" +
                "1)Auto\n" +
                "2)Home\n" +
                "3)Theft\n" +
                "4)Health\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newClaim.ClaimType = ClaimType.Auto;
                    break;
                case "2":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                case "4":
                    newClaim.ClaimType = ClaimType.Health;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Please enter a description of the incident.");
            newClaim.Description = Console.ReadLine();
            bool weParsin = true;
            while (weParsin)
            {
                Console.Clear();
                Console.WriteLine("Please enter the claim amount");
                string userType = Console.ReadLine();
                bool good = decimal.TryParse(userType, out decimal number2);
                if (good)
                {
                    newClaim.Amount = number2;
                    weParsin = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please try again.");
                    weParsin = true;
                }
            }
            bool weRunnin = true;
            while (weRunnin)
            {
                Console.Clear();
                Console.WriteLine("Please enter the date of the incident (e.g. 11/04/1997)");
                string userWords = Console.ReadLine();
                bool yes = DateTime.TryParse(userWords, out DateTime date);
                if (yes)
                {
                    newClaim.Date_of_Incident = date;
                    weRunnin = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter your date like 11/04/1997");
                    weRunnin = true;
                }
            }
            bool weAreRunning = true;
            while (weAreRunning)
            {
                Console.Clear();
                Console.WriteLine("Please enter the date the claim was filed (e.g. 11/04/1997)");
                string userSaysThis = Console.ReadLine();
                bool pog = DateTime.TryParse(userSaysThis, out DateTime date2);
                if (pog)
                {
                    newClaim.Date_of_Claim = date2;
                    weAreRunning = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong with your input. Please enter your date like 11/04/1997");
                    weAreRunning = true;
                }
            }
            TimeSpan timespan = newClaim.Date_of_Claim - newClaim.Date_of_Incident;
            double totalDays = timespan.TotalDays;
            if (totalDays > 30)
            {
                Console.WriteLine("This claim is invalid, as it is over 30 days. Press any button to continue...");
                newClaim.Is_Valid = false;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"This claim is valid. It has been {totalDays} days since the incident occurred. Press any button to continue...");
                newClaim.Is_Valid = true;
                Console.ReadLine();
            }
            _claimQueue.Enqueue(newClaim);
            if (_claimQueue.Count > initialQueueLength)
            {
                wasAdded = true;
                Console.WriteLine("Your claim has been added. Press any button to continue...");
                Console.ReadLine();
            }
            else
            {
                wasAdded = false;
                Console.WriteLine("Some error has occurred and your claim was not added. Press any button to continue to the main menu...");
                Console.ReadLine();
            }
            return wasAdded;
        }
        public void SeeAllClaims()
        {
            Console.Write("Claim ID:      Type:      Description:      Amount:      Incident Date:      Claim Date:      Claim Validity:");
            foreach (Claim claim in _claimQueue)
            {
                Console.WriteLine("\n");
                Console.Write($"{claim.ID}      {claim.ClaimType}      {claim.Description}      {claim.Amount}      {claim.Date_of_Incident}      {claim.Date_of_Claim}      {claim.Is_Valid}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
        public void AddressClaim()
        {
            //checks to see if there is a claim to address
            while (_claimQueue.Count >= 1)
            {
                //for each claim, we are displaying the claim information
                foreach (Claim claim in _claimQueue)
                {
                    bool continueRunning = true;
                    while (continueRunning)
                    {

                        Console.WriteLine($"Claim ID: {claim.ID}\n" +
                            $"Claim Type: {claim.ClaimType}\n" +
                            $"Claim Description: {claim.Description}\n" +
                            $"Claim Amount: {claim.Amount}\n" +
                            $"Incident Date: {claim.Date_of_Incident}\n" +
                            $"Claim Date: {claim.Date_of_Claim}\n" +
                            $"Claim is Valid: {claim.Is_Valid}");
                        Console.WriteLine("Would you like to address this claim now (Y/N)");
                        string userInput = Console.ReadLine();
                        string userInputLowered = userInput.ToLower();
                        //if user presses y, allow to approve or deny claim
                        if (userInputLowered == "y")// at this point they have stated they want to address a claim
                        {
                            bool continueParse = true;
                            //approve or deny
                            while (continueParse)
                            {
                                Console.WriteLine("What would you like to do?\n" +
                                    "1) Approve Claim\n" +
                                    "2) Deny Claim");
                                string userNumber = Console.ReadLine();
                                //tries to parse user input in case of bad input
                                bool worked = Int32.TryParse(userNumber, out int approveDenyNumber);
                                if (worked) //if parse worked, evaluate input with switch case
                                {
                                    switch (approveDenyNumber)
                                    {
                                        case 1:
                                            Console.WriteLine("Okay, this claim has been approved. Press any button to continue...");
                                            //approves claim and dequeues
                                            _claimQueue.Dequeue();
                                            Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Okay, this claim has been denied. Press any button to continue...");
                                            //denies claim and dequeues
                                            _claimQueue.Dequeue();
                                            break;
                                    }
                                    continueParse = false; //breaks out of parse while loop
                                }
                                else //input is bad
                                {
                                    Console.WriteLine("Something went wrong with your input. Please enter 1 or 2. Press any button to continue...");
                                    Console.ReadLine(); //pauses and then returns to top of while loop if the input is bad
                                    Console.Clear();
                                    continueParse = true;
                                }
                            }
                            Console.WriteLine("Would you like to address another claim? (Y/N)");//give option to address next claim,
                            string addressAnotherAnswer = Console.ReadLine();
                            string addressAnotherAnswerLowered = addressAnotherAnswer.ToLower();
                            switch (addressAnotherAnswerLowered)
                            {
                                case "y":
                                    Console.WriteLine("Preparing next claim. Press any button to continue...");

                                    Console.ReadLine();

                                    break;
                                case "n":       
                                    Console.WriteLine("Returning to the main menu. Press any button to continue...");
                                    Console.ReadLine();
                                    

                                    break;
                                default:
                                    Console.WriteLine("Something went wrong with your input. Returning to the main menu...");
                                    Console.ReadLine();

                                    break;
                            }
                        }
                        else if (userInputLowered == "n")
                        {
                            Console.WriteLine("Returning to the main menu. Press any button to continue...");
                            Console.ReadLine();
                            continueRunning = false;

                        }
                        else
                        {
                            Console.WriteLine("Please enter either Y or N");
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            continueRunning = true;
                        }
                    }
                }
            }
        }
        public void SeedContent()

        {
            DateTime incidentDate = new DateTime(2020, 1, 22);
            DateTime claimDate = new DateTime(2020, 1, 25);
            Claim testClaim = new Claim();
            testClaim.ID = 1408;
            testClaim.ClaimType = ClaimType.Home;
            testClaim.Description = "house on fire :(";
            testClaim.Amount = 20000m;
            testClaim.Date_of_Incident = incidentDate;
            testClaim.Date_of_Claim = claimDate;
            testClaim.Is_Valid = true;
            _claimQueue.Enqueue(testClaim);
        }
    }
}

