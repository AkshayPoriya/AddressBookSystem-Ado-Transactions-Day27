using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            int actual1 = DBOperations.GetNumberOfContactsForState("Haryana");
            int expected1 = 0;
            int actual2 = DBOperations.GetNumberOfContactsForState("NYC");
            int expected2 = 6;
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
    }
}
