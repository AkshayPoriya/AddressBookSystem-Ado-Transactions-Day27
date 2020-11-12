// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// New object of AddressBook is instantiated to create new class
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// contactList stores all contacts of one AddressBook
        /// </summary>
        public readonly List<Contact> contactList = new List<Contact>();

        /// <summary>
        /// nameToContactMapper is used to access contact details using name of person
        /// </summary>
        private readonly Dictionary<string, Contact> nameToContactMapper = new Dictionary<string, Contact>();

        /// <summary>
        /// This function is used to add new Contact in AddressBook
        /// </summary>
        public void AddContacts()
        {
            bool flag = true;
            string _firstName, _lastName, _address, _city, _state, _zip, _phoneNumber, _email;
            while (flag)
            {
                Console.WriteLine("\nEnter First Name of Contact");
                _firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name of Contact");
                _lastName = Console.ReadLine();
                if (this.nameToContactMapper.ContainsKey(_firstName + " " + _lastName))
                {
                    Console.WriteLine("A contact already exist with this name, try again!\n");
                    AddContacts();
                    return;
                }
                Console.WriteLine("Enter Address");
                _address = Console.ReadLine();
                Console.WriteLine("Enter City");
                _city = Console.ReadLine();
                Console.WriteLine("Enter state");
                _state = Console.ReadLine();
                Console.WriteLine("Enter zip");
                _zip = Console.ReadLine();
                Console.WriteLine("Enter Phone Number");
                _phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Email");
                _email = Console.ReadLine();

                Contact contact = new Contact();
                contact.firstName = _firstName;
                contact.lastName = _lastName;
                contact.address = _address;
                contact.city = _city;
                contact.state = _state;
                contact.zip = _zip;
                contact.phoneNumber = _phoneNumber;
                contact.email = _email;

                this.contactList.Add(contact);
                if (AddressBookDirectory.cityToContactMapperGlobal.ContainsKey(contact.city))
                {
                    AddressBookDirectory.cityToContactMapperGlobal[contact.city].Add(contact);
                }
                else
                {
                    List<Contact> list = new List<Contact>();
                    list.Add(contact);
                    AddressBookDirectory.cityToContactMapperGlobal.Add(contact.city, list);
                }

                if (AddressBookDirectory.stateToContactMapperGlobal.ContainsKey(contact.state))
                {
                    AddressBookDirectory.stateToContactMapperGlobal[contact.state].Add(contact);
                }
                else
                {
                    List<Contact> list = new List<Contact>();
                    list.Add(contact);
                    AddressBookDirectory.stateToContactMapperGlobal.Add(contact.state, list);
                }

                this.nameToContactMapper.Add(contact.firstName + " " + contact.lastName, contact);
                Console.WriteLine("\nContact created successfully with following details: ");
                Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                Console.WriteLine("\nTo Add a New Contact Enter YES");
                string option = Console.ReadLine();
                if (option.ToLower() != "yes")
                {
                    flag = false;
                }
            }
        }

        /// <summary>
        /// EditDetails is used to modify contact details of a person using complete name
        /// </summary>
        public void EditDetails()
        {
            bool flag = true;
            string _firstName, _lastName, _address, _city, _state, _zip, _phoneNumber, _email;
            while (flag)
            {
                Console.WriteLine("\nTo modify details, enter firstname followed by a space, followed by lastname of the contact");
                string name = Console.ReadLine();
                if (this.nameToContactMapper.ContainsKey(name))
                {
                    Console.WriteLine("Enter Latest Details of Contact!");
                    Console.WriteLine("Enter First Name of Contact");
                    _firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name of Contact");
                    _lastName = Console.ReadLine();
                    if (this.nameToContactMapper.ContainsKey(_firstName + " " + _lastName) && (_firstName + " " + _lastName) != name)
                    {
                        Console.WriteLine("A contact already exist with this name, try again!\n");
                        EditDetails();
                        return;
                    }
                    Console.WriteLine("Enter Address");
                    _address = Console.ReadLine();
                    Console.WriteLine("Enter City");
                    _city = Console.ReadLine();
                    Console.WriteLine("Enter state");
                    _state = Console.ReadLine();
                    Console.WriteLine("Enter zip");
                    _zip = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number");
                    _phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter Email");
                    _email = Console.ReadLine();

                    Contact contact = this.nameToContactMapper[name];
                    string oldCityName = contact.city;
                    string oldStateName = contact.state;
                    AddressBookDirectory.cityToContactMapperGlobal[oldCityName].Remove(contact);
                    AddressBookDirectory.stateToContactMapperGlobal[oldStateName].Remove(contact);
                    contact.firstName = _firstName;
                    contact.lastName = _lastName;
                    contact.address = _address;
                    contact.city = _city;
                    contact.state = _state;
                    contact.zip = _zip;
                    contact.phoneNumber = _phoneNumber;
                    contact.email = _email;

                    if (AddressBookDirectory.cityToContactMapperGlobal.ContainsKey(contact.city))
                    {
                        AddressBookDirectory.cityToContactMapperGlobal[contact.city].Add(contact);
                    }
                    else
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(contact);
                        AddressBookDirectory.cityToContactMapperGlobal.Add(contact.city, list);
                    }

                    if (AddressBookDirectory.stateToContactMapperGlobal.ContainsKey(contact.state))
                    {
                        AddressBookDirectory.stateToContactMapperGlobal[contact.state].Add(contact);
                    }
                    else
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(contact);
                        AddressBookDirectory.stateToContactMapperGlobal.Add(contact.state, list);
                    }

                    Console.WriteLine("\nDetails modified successfully with following entries: ");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber + "\nEmail: " + contact.email);
                }
                else
                {
                    Console.WriteLine("Entered name did't match with any record!");
                    Console.WriteLine("Valid names: ");
                    foreach (Contact contact in this.contactList)
                    {
                        Console.WriteLine(contact.firstName + " " + contact.lastName);
                    }
                }

                Console.WriteLine("\nTo update more contact details enter YES");
                string option = Console.ReadLine();
                if (option.ToLower() != "yes")
                {
                    flag = false;
                }
            }
        }

        /// <summary>
        /// DeleteContact function is used to delete Contact from AddressBook using full name of the person
        /// </summary>
        public void DeleteContact()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nTo Delete Contact, enter firstname followed by a space, followed by lastname of the contact");
                string name = Console.ReadLine();
                if (this.nameToContactMapper.ContainsKey(name))
                {
                    Contact contact = this.nameToContactMapper[name];
                    string oldCityName = contact.city;
                    string oldStateName = contact.state;
                    AddressBookDirectory.cityToContactMapperGlobal[oldCityName].Remove(contact);
                    AddressBookDirectory.stateToContactMapperGlobal[oldStateName].Remove(contact);
                    var index = this.contactList.FindIndex(i => i == contact); // like Where/Single
                    if (index >= 0)
                    {   // ensure item found
                        this.contactList.RemoveAt(index);
                    }

                    this.nameToContactMapper.Remove(name);
                    Console.WriteLine("Contact deleted successfully");
                }
                else
                {
                    Console.WriteLine("Entered name did't match with any record!");
                    Console.WriteLine("Valid names: ");
                    foreach (Contact contact in this.contactList)
                    {
                        Console.WriteLine(contact.firstName + " " + contact.lastName);
                    }
                }

                Console.WriteLine("\nTo Delete more contact details enter YES");
                string option = Console.ReadLine();
                if (option.ToLower() != "yes")
                {
                    flag = false;
                }
            }
        }

        /// <summary>
        /// Views the entries in sorted order by given property in option string
        /// </summary>
        /// <param name="option">The option.</param>
        public void ViewEntriesInSortedOrder(string option)
        {
            List<Contact> sortedContactList = this.contactList;
            if (option == "name")
            {
                sortedContactList = this.contactList.OrderBy(obj => (obj.firstName + obj.lastName)).ToList();
            }
            if (option == "city")
            {
                sortedContactList = this.contactList.OrderBy(obj => (obj.city)).ToList();
            }
            if (option == "state")
            {
                sortedContactList = this.contactList.OrderBy(obj => (obj.state)).ToList();
            }
            if (option == "zip")
            {
                sortedContactList = this.contactList.OrderBy(obj => (obj.zip)).ToList();
            }

            int contactCount = 1;
            foreach (Contact contact in sortedContactList)
            {
                Console.WriteLine("\n" + contactCount + ".");
                Console.WriteLine("First Name:\t" + contact.firstName);
                Console.WriteLine("Last Name:\t" + contact.lastName);
                Console.WriteLine("Address:\t" + contact.address);
                Console.WriteLine("City:\t" + contact.city);
                Console.WriteLine("State:\t" + contact.state);
                Console.WriteLine("ZIP:\t" + contact.zip);
                Console.WriteLine("Phone Number:\t" + contact.phoneNumber);
                Console.WriteLine("Email:\t" + contact.email + "\n");
                contactCount++;
            }
        }
    }
}