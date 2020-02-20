using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBadges_Repository
{
    public class Badge
    {
        public string ID { get; set; }
        public List<string> AccessibleDoors { get; set; }
        public Badge() { }
        public Badge(string id, List<string> accessibleDoors)
        {
            ID = id;
            AccessibleDoors = accessibleDoors;
        }
    }
    public class KBadges_Methods
    {
        Badge newBadge = new Badge();
        Dictionary<string, List<string>> _dictionary = new Dictionary<string, List<string>>();

        public void SeedContent()
        {
            List<string> testAccessible = new List<string>() { "A5", "C3", "P0", "B2" };
            Badge testBadge = new Badge();
            testBadge.ID = "8705";
            testBadge.AccessibleDoors = testAccessible;
            _dictionary.Add(testBadge.ID, testBadge.AccessibleDoors);
            List<string> testAccessible2 = new List<string>() { "B5", "D3", "Q0", "C2" };
            Badge testBadge2 = new Badge();
            testBadge2.ID = "8706";
            testBadge2.AccessibleDoors = testAccessible2;
            _dictionary.Add(testBadge2.ID, testBadge2.AccessibleDoors);
        }
        public void ListAllBadges()
        {

            foreach (KeyValuePair<string, List<string>> keyAndValue in _dictionary)
            {
                Console.WriteLine("Badge #:");
                Console.WriteLine(keyAndValue.Key);
                Console.WriteLine("Accessible Doors:");
                foreach (var value in keyAndValue.Value)
                {
                    Console.Write($"{value}, ");
                }
                Console.WriteLine("\n");
            }
                    Console.WriteLine("\n");
                Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                Console.Clear();
        }
        public bool SearchByID(string keyInputForSearch)
        {
            
            if (_dictionary.ContainsKey(keyInputForSearch))
            {
                var value = _dictionary[keyInputForSearch];
                string goodString = string.Join(", ", value);
                Console.WriteLine("Accessible Doors:");
                Console.WriteLine(goodString);
                return true;
            }
            else
            {
                Console.WriteLine("The dictionary does not contain an entry with that key.");
                return false;
            }
        }
        public void UpdateDoors(string keyInputForSearch, string newDoorValue)
        {
            _dictionary[keyInputForSearch].Add(newDoorValue);
        }
        public void DeleteAllDoors(string keyInputForSearch)
        {
            _dictionary[keyInputForSearch] = new List<string>();
        }
        public void AddNewBadge(string key, List<string> doorList)
        {
          
            Badge newBadge = new Badge();
            newBadge.ID = key;
            newBadge.AccessibleDoors = doorList;
            _dictionary.Add(newBadge.ID, newBadge.AccessibleDoors);
        }
    }
}
