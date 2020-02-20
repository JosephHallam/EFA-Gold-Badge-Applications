using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBadge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        Dictionary<int, List<string>> _testDict = new Dictionary<int, List<string>>();
        [TestMethod]
        public void testListAll()
        {
            List<string> testList1 = new List<string>() { "alkjsd", "asdjffl", "aklsdjflk" };
            List<string> testList2 = new List<string>() { "qwerasd", "ajdjfkl", "aklsdjflk" };
            List<string> testList3 = new List<string>() { "asdf", "mcvzmcx,v", "ueqwrop" };

            _testDict.Add(53, testList1);
            _testDict.Add(44, testList2);
            _testDict.Add(45, testList3);
            //Console.WriteLine(_testDict["53"]);
            foreach (KeyValuePair<int, List<string>> keyAndValue in _testDict)
            {
                Console.WriteLine(keyAndValue.Key);
                foreach (var value in keyAndValue.Value)
                {
                    Console.WriteLine(value);
                }
                // Console.WriteLine(string.Join(", ", _testDict.Values.ToString()));
            }
        }
        [TestMethod]
        public void TestSearchByNumber()
        {
            List<string> testList1 = new List<string>() { "alkjsd", "asdjffl", "aklsdjflk" };
            List<string> testList2 = new List<string>() { "qwerasd", "ajdjfkl", "aklsdjflk" };
            List<string> testList3 = new List<string>() { "asdf", "mcvzmcx,v", "ueqwrop" };

            _testDict.Add(53, testList1);
            _testDict.Add(44, testList2);
            _testDict.Add(45, testList3);

            int numberInput = 53;
            if (_testDict.ContainsKey(numberInput))
            {
                List<string> value = _testDict[numberInput];
                string fixedList = string.Join(", ", value);
                Console.WriteLine(numberInput);
                Console.WriteLine(fixedList);
            }
            else
            {
                Console.WriteLine("This key does not exist in this dictionary.");
            }
        }
        [TestMethod]
        public void TestEditDoors()
        {
            List<string> testList1 = new List<string>() { "alkjsd", "asdjffl", "aklsdjflk" };
            _testDict.Add(53, testList1);
            _testDict[53] = new List<string>();
            string newDoor = "A1";
            _testDict[53].Add(newDoor);
            string newDoor2 = "A2";
            _testDict[53].Add(newDoor2);
            string listasstring = string.Join(", ", _testDict[53]);
            Console.WriteLine(listasstring);
        }
        [TestMethod]
        public void TestDeleteDoors()
        {
            List<string> testList1 = new List<string>() { "alkjsd", "asdjffl", "aklsdjflk" };
            _testDict.Add(53, testList1);
            _testDict[53] = new List<string>();
            string list = string.Join(", ", _testDict[53]);
            if (list == "")
            {
                Console.WriteLine("This list is empty.");
            }

            else
            {
                Console.WriteLine(list);

            }

        }
    }
}
