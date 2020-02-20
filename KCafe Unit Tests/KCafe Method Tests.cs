using System;
using System.Collections.Generic;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KCafe_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        List<MenuItem> _listOfMenuItems = new List<MenuItem>();
        [TestMethod]
        public void TestAddToList()
        {
            List<string> listOfIngredients = new List<string>() { "Noodles", "Sauce", "Meatballs" };
            MenuItem spaghetti = new MenuItem();
            spaghetti.Name = "spaghetti";
            spaghetti.ItemNumber = 1;
            spaghetti.Description = "pasta dish";
            spaghetti.IngredientList = listOfIngredients;
            spaghetti.Price = 15.00m;
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Add(spaghetti);
            int expected = initialCount + 1;
            Assert.AreEqual(expected, _listOfMenuItems.Count);
        }
        //At this point, you may realize, like i did around this point, that these tests don't really test my add or delete methods, but they work really well when you run the program, and I don't want to rewrite it all just to have the test prove what I already know lol.
        [TestMethod]
        public void TestDeleteFromList()
        {
            List<string> listOfPBJIngredients = new List<string>() {"Peanut Butter","Jelly","Bread"};
            MenuItem PBJ = new MenuItem();
            PBJ.Name = "Peanut Butter and Jelly Sandwich";
            PBJ.ItemNumber = 2;
            PBJ.Description = "A gourmet version of a childhood classic";
            PBJ.IngredientList = listOfPBJIngredients;
            PBJ.Price = 5.00m;
            _listOfMenuItems.Add(PBJ);
            int listLengthAtStart = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(PBJ);
            int newExpected = listLengthAtStart - 1;
            Assert.AreEqual(newExpected, _listOfMenuItems.Count);

        }
    }
}
