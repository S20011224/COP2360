using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        // Dictionary to store keys and their associated list of values
        private static Dictionary<string, List<string>> myDictionary =
            new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            // Initially populate the dictionary
            PopulateDictionary();

            // Main menu loop
            while (true)
            {
                DisplayMenu();
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()?.ToLower().Trim();

                switch (choice)
                {
                    case "a":
                        PopulateDictionary();
                        break;
                    case "b":
                        DisplayDictionaryContents();
                        break;
                    case "c":
                        RemoveKey();
                        break;
                    case "d":
                        AddNewKeyAndValue();
                        break;
                    case "e":
                        AddValueToExistingKey();
                        break;
                    case "f":
                        SortKeys();
                        break;
                    case "q":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // Display the main menu options
        static void DisplayMenu()
        {
            Console.WriteLine("a. Populate Dictionary");
            Console.WriteLine("b. Show Dictionary Contents");
            Console.WriteLine("c. Remove a Key");
            Console.WriteLine("d. Add a New Key and Value");
            Console.WriteLine("e. Add a Value to an Existing Key");
            Console.WriteLine("f. Sort the Keys");
            Console.WriteLine("q. Quit");
        }

        // Fill the dictionary with dummy values
        static void PopulateDictionary()
        {
            Console.WriteLine("\nPopulating Dictionary...");
            myDictionary.Clear();

            myDictionary.Add("apple", new List<string> { "fruit", "red", "sweet" });
            myDictionary.Add("banana", new List<string> { "fruit", "yellow" });
            myDictionary.Add("carrot", new List<string> { "vegetable", "orange", "crunchy" });
            myDictionary.Add("dog", new List<string> { "animal", "mammal", "loyal" });
            myDictionary.Add("cat", new List<string> { "animal", "mammal", "cute" });

            Console.WriteLine("Dictionary populated.");
        }

        // Show all keys and values
        static void DisplayDictionaryContents()
        {
            Console.WriteLine("\nDisplaying Dictionary Contents");
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            foreach (KeyValuePair<string, List<string>> entry in myDictionary)
            {
                Console.WriteLine($"Key: '{entry.Key}', Values: {string.Join(", ", entry.Value)}");
            }
        }

        // Remove a key
        static void RemoveKey()
        {
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            Console.Write("Enter key to remove: ");
            string keyToRemove = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(keyToRemove))
            {
                Console.WriteLine("Key is empty.");
                return;
            }

            if (myDictionary.ContainsKey(keyToRemove))
            {
                myDictionary.Remove(keyToRemove);
                Console.WriteLine($"Key '{keyToRemove}' removed.");
            }
            else
            {
                Console.WriteLine($"Key '{keyToRemove}' not found.");
            }
        }

        // Add a new key and its values
        static void AddNewKeyAndValue()
        {
            Console.Write("Enter the new key: ");
            string newKey = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(newKey))
            {
                Console.WriteLine("Key is empty.");
                return;
            }

            Console.Write($"Enter the value(s) for '{newKey}' (use commas to seperate): ");
            string newValuesString = Console.ReadLine()?.Trim();

            List<string> newValues = new List<string>();
            if (!string.IsNullOrWhiteSpace(newValuesString))
            {
                newValues = newValuesString
                    .Split(',')
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();
            }

            myDictionary[newKey] = newValues;
            Console.WriteLine(
                $"Key '{newKey}' with value(s) [{string.Join(", ", newValues)}] added/updated."
            );
        }

        // Add a value to a key that already exists
        static void AddValueToExistingKey()
        {
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            Console.Write("Enter key to add a value to: ");
            string keyToUpdate = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(keyToUpdate))
            {
                Console.WriteLine("Key is empty.");
                return;
            }

            if (myDictionary.ContainsKey(keyToUpdate))
            {
                Console.Write($"Enter new value to add to '{keyToUpdate}': ");
                string newValueToAdd = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(newValueToAdd))
                {
                    Console.WriteLine("Nothing entered.");
                    return;
                }

                myDictionary[keyToUpdate].Add(newValueToAdd);
                Console.WriteLine($"Value '{newValueToAdd}' added to key '{keyToUpdate}'.");
                Console.WriteLine(
                    $"Updated values for '{keyToUpdate}': {string.Join(", ", myDictionary[keyToUpdate])}"
                );
            }
            else
            {
                Console.WriteLine($"Key '{keyToUpdate}' not found.");
            }
        }

        // Sort keys
        static void SortKeys()
        {
            Console.WriteLine("\nSorting...");
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            List<string> sortedKeys = myDictionary.Keys.ToList();
            sortedKeys.Sort();

            Console.WriteLine("Sorted:");
            foreach (string key in sortedKeys)
            {
                Console.WriteLine($"- {key}");
            }
        }
    }
}
