using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaim_Repository
{
    public class KClaim_UI
    {
        ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            _claimRepo.SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Insurance Claims Service. Please select what you would like to do.\n" +
                    "1) View all pending claims\n" +
                    "2) Address next pending claim\n" +
                    "3) Enter a new claim\n" +
                    "4) Exit Program");
                string userInput = Console.ReadLine();
                bool success = Int32.TryParse(userInput, out int number);
                if (success)
                {
                    switch (number)
                    {
                        case 1: _claimRepo.SeeAllClaims();
                            break;
                        case 2: _claimRepo.AddressClaim();
                            break;
                        case 3: _claimRepo.AddNewClaim();
                            break;
                        case 4: keepRunning = false;
                            break;
                    }
                }
            }
        }
    }
}
