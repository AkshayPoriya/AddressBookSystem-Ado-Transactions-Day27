// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileIOOperations.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using CsvHelper;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    class FileIOOperations
    {

        /// <summary>
        /// Writes the data to text file.
        /// Store all contact details from address book directory to AddressBookDirectory.txt file
        /// </summary>
        public static void AppendContactDetailsToTextFile()
        {
            try
            {
                string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions\AddressBookSystem\AddressBookDirectory.txt";

                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine($"\n\n******************* New Data Added *******************\n");
                    foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                    {
                        sr.WriteLine($"\n******************* AddressBook: {pair.Key} *******************\n");
                        sr.WriteLine("Number of contacts: " + pair.Value.contactList.Count);
                        sr.WriteLine("----------------Contact Details----------------");
                        int contactCount = 1;
                        foreach (Contact contact in pair.Value.contactList)
                        {
                            sr.WriteLine(contactCount + ".");
                            sr.WriteLine("First Name:\t" + contact.firstName);
                            sr.WriteLine("Last Name:\t" + contact.lastName);
                            sr.WriteLine("Address:\t" + contact.address);
                            sr.WriteLine("City:\t" + contact.city);
                            sr.WriteLine("State:\t" + contact.state);
                            sr.WriteLine("ZIP:\t" + contact.zip);
                            sr.WriteLine("Phone Number:\t" + contact.phoneNumber);
                            sr.WriteLine("Email:\t" + contact.email + "\n");
                            contactCount++;
                        }
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        /// <summary>
        /// Reads the data from AddressBookDirectory.txt file.
        /// </summary>
        public static void ReadContactDetailsFromTextFile()
        {
            try
            {
                string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions\AddressBookSystem\AddressBookDirectory.txt";
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist!");
                    return;
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        public static void AppendContactDetailsToCsvFile()
        {
            try
            {
                foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                {
                    string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions\AddressBookSystem\AddressBook_" + pair.Key + ".csv";
                    using (StreamWriter writer = new StreamWriter(path))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(pair.Value.contactList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        public static void ReadContactDetailsFromCsvFile()
        {
            try
            {
                foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                {
                    string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions\AddressBookSystem\AddressBook_" + pair.Key + ".csv";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File doesn't exist!");
                        return;
                    }

                    using (var streamReader = new StreamReader(path))
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        var records = csvReader.GetRecords<Contact>().ToList();
                        Console.WriteLine("\n******************* AddressBook_" + pair.Key + ".csv *******************\n");
                        foreach (Contact contact in records)
                        {
                            Console.Write(contact.firstName);
                            Console.Write("\t" + contact.lastName);
                            Console.Write("\t" + contact.address);
                            Console.Write("\t" + contact.city);
                            Console.Write("\t" + contact.state);
                            Console.Write("\t" + contact.zip);
                            Console.Write("\t" + contact.phoneNumber);
                            Console.Write("\t" + contact.email + "\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        public static void AppendContactDetailsToJsonFile()
        {
            try
            {
                foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                {
                    string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions\AddressBookSystem\AddressBook_" + pair.Key + ".json";
                    using (StreamWriter sw = new StreamWriter(path))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, pair.Value.contactList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        public static void ReadContactDetailsFromJsonFile()
        {
            try
            {
                foreach (KeyValuePair<string, AddressBook> pair in AddressBookDirectory.addressBookMapper)
                {
                    string path = @"G:\Programming\Bridge Labz\04 C# IO Streams\10_AddressBookSystem-Ado.Net,Transactions0\AddressBookSystem\AddressBook_" + pair.Key + ".json";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("File doesn't exist!");
                        return;
                    }

                    IList<Contact> records = JsonConvert.DeserializeObject<IList<Contact>>(File.ReadAllText(path));
                    Console.WriteLine("\n******************* AddressBook_" + pair.Key + ".json *******************\n");
                    foreach (Contact contact in records)
                    {
                        Console.Write(contact.firstName);
                        Console.Write("\t" + contact.lastName);
                        Console.Write("\t" + contact.address);
                        Console.Write("\t" + contact.city);
                        Console.Write("\t" + contact.state);
                        Console.Write("\t" + contact.zip);
                        Console.Write("\t" + contact.phoneNumber);
                        Console.Write("\t" + contact.email + "\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }
    }
}