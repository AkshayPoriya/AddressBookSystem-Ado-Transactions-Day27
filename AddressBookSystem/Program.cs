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
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            List<Contact> contactList = DBOperations.GetAllDetails();
            Program.DisplayContactDetails(contactList);
        }

        /// <summary>
        /// Displays the contact details.
        /// </summary>
        /// <param name="contactList">The contact list.</param>
        public static void DisplayContactDetails(List<Contact> contactList)
        {
            Console.WriteLine("Contact Details:");
            Console.Write("{0,-15}", "first_name");
            Console.Write("{0,-15}", "last_name");
            Console.Write("{0,-30}", "address");
            Console.Write("{0,-20}", "email");
            Console.Write("{0,-20}", "address_book_name");
            Console.Write("{0,-15}", "contact_type");
            Console.WriteLine();
            foreach (Contact contact in contactList)
            {
                Console.Write("{0,-15}", contact.firstName);
                Console.Write("{0,-15}", contact.lastName);
                Console.Write("{0,-30}", contact.address);
                Console.Write("{0,-20}", contact.email);
                Console.Write("{0,-20}", contact.addressBookName);
                Console.Write("{0,-15}", contact.contactType);
                Console.WriteLine();
            }
        }
    }
}
