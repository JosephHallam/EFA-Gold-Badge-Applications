using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaim_Repository
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
        public bool Is_Valid
        {
            get
            {
                TimeSpan timespan = Date_of_Claim - Date_of_Incident;
                double totalDays = timespan.TotalDays;
                if (totalDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Claim() { }
        public Claim(int id, ClaimType claimType, string description, decimal amount, DateTime incidentDate, DateTime claimDate)
        {
            ID = id;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            Date_of_Incident = incidentDate;
            Date_of_Claim = claimDate;
        }
    }
    public class Claim_Repository
    {
        Queue<Claim> claimList = new Queue<Claim>();

        public void SeedContent()
        {
            int userID = 8705;
            ClaimType userClaimType = ClaimType.Auto;
            string userDescription = "car broke down.";
            decimal userAmount = 5500m;
            DateTime userIncidentDate = new DateTime(1997, 11, 04);
            DateTime userClaimDate = new DateTime(1997, 11, 27);
            Claim claim1 = new Claim(userID, userClaimType, userDescription, userAmount, userIncidentDate, userClaimDate);
            claimList.Enqueue(claim1);
            int userID2 = 8726;
            ClaimType userclaimtype2 = ClaimType.Home;
            string userdescription2 = "house on fire :'(";
            decimal useramount2 = 5500m;
            DateTime incidentDate = new DateTime(2020, 2, 18);
            DateTime claimdate = new DateTime(2020, 2, 20);
            Claim claim2 = new Claim(userID2, userclaimtype2, userdescription2, useramount2, incidentDate, claimdate);
            claimList.Enqueue(claim2);
        }
        public void DisplayAllClaims()
        {
            if (claimList.Count > 0)
            {

            foreach (Claim claim in claimList)
            {
                Console.WriteLine($"ID: {claim.ID} Claim Type: {claim.ClaimType} Description: \"{claim.Description}\" Amount: ${claim.Amount} Incident Date: {claim.Date_of_Incident.ToString("MM/dd/yyyy")} Claim Date: {claim.Date_of_Claim.ToString("MM/dd/yyyy")} Claim is Valid?: {claim.Is_Valid}");
            }
            }
            else
            {
                Console.WriteLine("There are no unaddressed claims.");
            }
        }
        public void AddNewClaim(Claim newestClaim)
        {
            
            claimList.Enqueue(newestClaim);
        }
        public void RemoveClaim()
        {
            claimList.Dequeue();
        }
        public void ShowNextClaim()
        {
            Claim showedClaim = claimList.Peek();
            Console.WriteLine($"{showedClaim.ID} \"{showedClaim.Description}\" ${showedClaim.Amount} DOI: {showedClaim.Date_of_Incident.ToString("MM/dd/yyyy")} DOC: {showedClaim.Date_of_Claim.ToString("MM/dd/yyyy")}");
        }
        public int CountNumberOfClaimsInQueue()
        {
            return claimList.Count();
        }
    }
}
