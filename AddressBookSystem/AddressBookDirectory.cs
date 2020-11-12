// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookDirectory.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Text.Json.Serialization;

    public class AddressBookDirectory
    {
        /// <summary>
        /// addressBookMapper is a data structure used to store All AddressBooks created in the project
        /// which can be accessed with the help of their name
        /// </summary>
        public static readonly Dictionary<string, AddressBook> addressBookMapper = new Dictionary<string, AddressBook>();

        /// <summary>
        /// cityToContactMapperGlobal is a variable which store all contacts with their city names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> cityToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// stateToContactMapperGlobal is a variable which store all contacts with their state names
        /// </summary>
        public static readonly Dictionary<string, List<Contact>> stateToContactMapperGlobal = new Dictionary<string, List<Contact>>();

        /// <summary>
        /// View Contacts in sorted order.
        /// </summary>
        public static void ViewInSortedOrder()
        {
            Console.WriteLine("\nEnter a for Sort by person name\nEnter b for sort by city name" +
                "\nEnter c for sort by state name\nEnter d for sort by zip code\nPress any other key to exit");
            string options = Console.ReadLine().ToLower();
            string orderBy = "name";
            switch (options)
            {
                case "a":
                    orderBy = "name";
                    break;
                case "b":
                    orderBy = "city";
                    break;
                case "c":
                    orderBy = "state";
                    break;
                case "d":
                    orderBy = "zip";
                    break;
                default:
                    return;
            }
            foreach (KeyValuePair<string, AddressBook> pair in addressBookMapper)
            {
                Console.WriteLine("\n************************************************");
                Console.WriteLine("Details of AddressBook with Name: " + pair.Key);
                pair.Value.ViewEntriesInSortedOrder(orderBy);
            }
        }

        /// <summary>
        /// AddAddressBook function is called when user want to create new AddressBook
        /// </summary>
        public static void AddAddressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            if (addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("\nAddress Book Already exist with this name");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                addressBookMapper.Add(name, addressBook);
            }
        }

        /// <summary>
        /// AddContactsInAddressBook is called when user ask to enter new contact details in any AddressBook
        /// </summary>
        public static void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("\nNo address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.AddContacts();
            }
        }

        /// <summary>
        /// EditDetailsOfAddressBook is called when a user ask to modify Contact details in a AddressBook
        /// </summary>
        public static void EditDetailsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("\nNo address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.EditDetails();
            }
        }

        /// <summary>
        /// DeleteContactsOfAddressBook is called when user want to delete a particular contact from a AddressBook
        /// </summary>
        public static void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("\nNo address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = addressBookMapper[name];
                addressBook.DeleteContact();
            }
        }

        /// <summary>
        /// Searches the name of the contact with city.
        /// </summary>
        public static void SearchContactWithCityName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("\nNo record found with such city name!");
                return;
            }
            foreach (Contact contact in cityToContactMapperGlobal[cityName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("\nContact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }

        /// <summary>
        /// Searches the name of the contact with state.
        /// </summary>
        public static void SearchContactWithStateName()
        {
            Console.WriteLine("\nEnter full name of the person!");
            string personName = Console.ReadLine();
            Console.WriteLine("\nEnter name of the state!");
            string stateName = Console.ReadLine();
            if (!stateToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("\nNo record found with this state name!");
                return;
            }
            foreach (Contact contact in stateToContactMapperGlobal[stateName])
            {
                if ((contact.firstName + " " + contact.lastName) == personName)
                {
                    Console.WriteLine("\nContact found!");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                    return;
                }
            }
            Console.WriteLine($"No Contact Exist With This Name!");
        }

        /// <summary>
        /// Views the name of the contact by city.
        /// </summary>
        public static void ViewContactByCityName()
        {
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("\nNo record found with such city name!");
                return;
            }
            foreach (Contact contact in cityToContactMapperGlobal[cityName])
            {
                Console.WriteLine("\nFirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Views the name of the contact by state.
        /// </summary>
        public static void ViewContactByStateName()
        {
            Console.WriteLine("\nEnter name of the State!");
            string stateName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("\nNo record found with such state name!");
                return;
            }
            foreach (Contact contact in stateToContactMapperGlobal[stateName])
            {
                Console.WriteLine("\nFirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Numbers the name of the of contacts by city.
        /// </summary>
        public static void NumberOfContactsByCityName()
        {
            Console.WriteLine("\nEnter name of the city!");
            string cityName = Console.ReadLine();
            if (!cityToContactMapperGlobal.ContainsKey(cityName))
            {
                Console.WriteLine("\nNo of Contacts: 0");
                return;
            }
            Console.WriteLine("\nNo of Contacts: " + cityToContactMapperGlobal[cityName].Count);
        }

        /// <summary>
        /// Numbers the name of the of contacts by state.
        /// </summary>
        public static void NumberOfContactsByStateName()
        {
            Console.WriteLine("\nEnter name of the state!");
            string stateName = Console.ReadLine();
            if (!stateToContactMapperGlobal.ContainsKey(stateName))
            {
                Console.WriteLine("\nNo of Contacts: 0");
                return;
            }
            Console.WriteLine("\nNo of Contacts: " + stateToContactMapperGlobal[stateName].Count);
        }
    }
}