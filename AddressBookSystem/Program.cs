// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Program class contains main function
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// Calls StartProgram function
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            StartProgram();
        }

        /// <summary>
        /// StartProgram function asks user about which activity to be done
        /// </summary>
        private static void StartProgram()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nEnter 1 to add New Address Book \nEnter 2 to Add Contacts \nEnter 3 to Edit Contacts " +
                    "\nEnter 4 to Delete Contacts\nEnter 5 to search contact using city or state name" +
                    "\nEnter 6 to view contact details by city or state name \nEnter 7 to get number of contacts by city or state name" +
                    "\nEnter 8 to view AddressBooks in sorted order \nEnter 9 to Append or Read Contact Details  \nEnter any other key to exit\n");
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        AddressBookDirectory.AddAddressBook();
                        break;
                    case "2":
                        AddressBookDirectory.AddContactsInAddressBook();
                        break;
                    case "3":
                        AddressBookDirectory.EditDetailsOfAddressBook();
                        break;
                    case "4":
                        AddressBookDirectory.DeleteContactsOfAddressBook();
                        break;
                    case "5":
                        Console.WriteLine("Enter c for city\nEnter s for state\nPress any other key to exit");
                        string cityOrState1 = Console.ReadLine().ToLower();
                        switch (cityOrState1)
                        {
                            case "c":
                                AddressBookDirectory.SearchContactWithCityName();
                                break;
                            case "s":
                                AddressBookDirectory.SearchContactWithStateName();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter c for city\nEnter s for state\nPress any other key to exit");
                        string cityOrState2 = Console.ReadLine().ToLower();
                        switch (cityOrState2)
                        {
                            case "c":
                                AddressBookDirectory.ViewContactByCityName();
                                break;
                            case "s":
                                AddressBookDirectory.ViewContactByStateName();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "7":
                        Console.WriteLine("Enter c for city\nEnter s for state\nPress any other key to exit");
                        string cityOrState3 = Console.ReadLine().ToLower();
                        switch (cityOrState3)
                        {
                            case "c":
                                AddressBookDirectory.NumberOfContactsByCityName();
                                break;
                            case "s":
                                AddressBookDirectory.NumberOfContactsByStateName();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "8":
                        AddressBookDirectory.ViewInSortedOrder();
                        break;
                    case "9":
                        Console.WriteLine("Enter ta to Append Contact Details in text file \nEnter tr to Read Data from text File" +
                            "\nEnter ca to Append Contact Details in csv file \nEnter cr to Read Data from csv Files" +
                            "\nEnter ja to Append Contact Details in json file \nEnter jr to Read Data from json Files\nPress any other key to exit");
                        string appendOrRead = Console.ReadLine().ToLower();
                        switch (appendOrRead)
                        {
                            case "ta":
                                FileIOOperations.AppendContactDetailsToTextFile();
                                break;
                            case "tr":
                                FileIOOperations.ReadContactDetailsFromTextFile();
                                break;
                            case "ca":
                                FileIOOperations.AppendContactDetailsToCsvFile();
                                break;
                            case "cr":
                                FileIOOperations.ReadContactDetailsFromCsvFile();
                                break;
                            case "ja":
                                FileIOOperations.AppendContactDetailsToJsonFile();
                                break;
                            case "jr":
                                FileIOOperations.ReadContactDetailsFromJsonFile();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
