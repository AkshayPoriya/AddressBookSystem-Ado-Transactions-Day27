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
    }
}
