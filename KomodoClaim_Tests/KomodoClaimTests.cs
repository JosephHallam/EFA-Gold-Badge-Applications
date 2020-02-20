using System;
using System.Collections.Generic;
using KomodoClaim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaim_Tests
{
    [TestClass]
    public class KomodoClaimTests
    {
        [TestMethod]
        public void testListAll()
        {
            DateTime testincident = new DateTime(1997, 11, 04);
            DateTime testclaimDate = new DateTime(1997, 11, 27);
            Queue<Claim> testClaimList = new Queue<Claim>();
            Claim newClaim = new Claim(8705, ClaimType.Auto, "My car on fire", 6000, testincident, testclaimDate);
            testClaimList.Enqueue(newClaim);
                Console.WriteLine("ID:    Description:        Amount:    Incident Date:    Claim Date:    Valid?:");
                foreach (Claim claim in testClaimList)
                {
                    Console.Write($"{claim.ID} {claim.Description}   {claim.Amount}        {claim.Date_of_Incident.ToString("MM/dd/yyyy")}   {claim.Date_of_Claim.ToString("MM/dd/yyyy")}    {claim.Is_Valid}");
                }
            
        }
        [TestMethod]
        public void testaddnewclaim()
        {
            Queue<Claim> testClaimList = new Queue<Claim>();
            int userID = 8705;
            ClaimType userClaimType = ClaimType.Auto;
            string userDescription = "help me my car oh my god the humanity.";
            decimal userAmount = 5500m;
            DateTime userIncidentDate = new DateTime(1997, 11, 04);
            DateTime userClaimDate = new DateTime(1997, 11, 27);
            
            Claim newClaim = new Claim(userID, userClaimType, userDescription, userAmount, userIncidentDate, userClaimDate);
            testClaimList.Enqueue(newClaim);
            Assert.AreEqual(testClaimList.Count, 1);
        }
        [TestMethod]
        public void TestDelete()
        {
            Queue<Claim> testClaimList = new Queue<Claim>();
            int userID = 8705;
            ClaimType userClaimType = ClaimType.Auto;
            string userDescription = "help me my car oh my god the humanity.";
            decimal userAmount = 5500m;
            DateTime userIncidentDate = new DateTime(1997, 11, 04);
            DateTime userClaimDate = new DateTime(1997, 11, 27);
            
            Claim newClaim = new Claim(userID, userClaimType, userDescription, userAmount, userIncidentDate, userClaimDate);
            testClaimList.Enqueue(newClaim);
            testClaimList.Dequeue();
            Assert.IsFalse(testClaimList.Count > 1);
        }
        [TestMethod]
        public void TestShowNextClaim()
        {
            Queue<Claim> testClaimList = new Queue<Claim>();
            int userID = 8705;
            ClaimType userClaimType = ClaimType.Auto;
            string userDescription = "help me my car oh my god the humanity.";
            decimal userAmount = 5500m;
            DateTime userIncidentDate = new DateTime(1997, 11, 04);
            DateTime userClaimDate = new DateTime(1997, 11, 27);

            Claim newClaim = new Claim(userID, userClaimType, userDescription, userAmount, userIncidentDate, userClaimDate);
            testClaimList.Enqueue(newClaim);
            int userID2 = 8726;
            ClaimType userclaimtype2 = ClaimType.Home;
            string userdescription2 = "house on fire :'(";
            decimal useramount2 = 5500m;
            DateTime incidentDate = new DateTime(2020, 2, 18);
            DateTime claimdate = new DateTime(2020, 2, 20);
            Claim claim2 = new Claim(userID2, userclaimtype2, userdescription2, useramount2, incidentDate, claimdate);
            testClaimList.Enqueue(claim2);
            while (testClaimList.Count > 0)
            {
            Claim showedClaim = testClaimList.Peek();
            Console.WriteLine($"{showedClaim.ID} {showedClaim.Description} {showedClaim.Amount} {showedClaim.Date_of_Incident} {showedClaim.Date_of_Claim}");
                testClaimList.Dequeue();
            }
        }
    }
}
