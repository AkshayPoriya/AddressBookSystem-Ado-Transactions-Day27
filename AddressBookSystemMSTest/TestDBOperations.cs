using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookSystemMSTest
{
    [TestClass]
    public class TestDBOperations
    {
        /// <summary>
        /// UC17
        /// Tests the update address.
        /// </summary>
        [TestMethod]
        public void TestUpdateAddress()
        {
            //Arrange
            //Act
            DBOperations.UpdateContactAddress("Ben", "Geller", "New York City");
            string actual = DBOperations.GetAddress("Ben", "Geller");
            string expected = "New York City";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC19
        /// Tests the get number of contacts for city.
        /// </summary>
        [TestMethod]
        public void TestGetNumberOfContactsForCity()
        {
            //Arrange
            //Act
            int actual1 = DBOperations.GetNumberOfContactsForCity("Delhi");
            int expected1 = 0;
            int actual2 = DBOperations.GetNumberOfContactsForCity("New York");
            int expected2 = 6;
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        /// <summary>
        /// UC19
        /// Tests the state of the get number of contacts for.
        /// </summary>
        [TestMethod]
        public void TestGetNumberOfContactsForState()
        {
            //Arrange
            //Act
            int actual1 = DBOperations.GetNumberOfContactsForState("Himachal");
            int expected1 = 0;
            int actual2 = DBOperations.GetNumberOfContactsForState("NYC");
            int expected2 = 6;
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }


        /// <summary>
        /// UC20
        /// Tests the add contact.
        /// </summary>
        [TestMethod]
        public void TestAddContact()
        {
            //Arrange
            Contact contact = new Contact();
            contact.firstName = "Akshay";
            contact.lastName = "Poriya";
            contact.address = "KZH";
            contact.city = "jind";
            contact.state = "haryana";
            contact.zip = "111111";
            contact.phoneNumber = "80941445XX";
            contact.email = "aks@poriya.com";
            contact.contactType = "self";
            contact.addressBookName = "owner";
            contact.dateAdded = Convert.ToDateTime("1/1/2012");
            //Act
            DBOperations.AddContact(contact);
            string actual = DBOperations.GetAddress("Akshay", "Poriya");
            string expected = "KZH";
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
