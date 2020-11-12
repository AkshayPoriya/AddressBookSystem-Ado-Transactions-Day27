// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBOperations.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    class DBOperations
    {
        public static List<Contact> GetAllDetails()
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            List<Contact> contactList = new List<Contact>();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spGetAllDetails", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    if (dataReader.HasRows == false)
                    {
                        return contactList;
                    }
                    else
                    {
                        while (dataReader.Read())
                        {
                            string firstName = dataReader["first_name"].ToString();
                            string lastName = dataReader["last_name"].ToString();
                            string address = dataReader["address"].ToString();
                            string city = dataReader["city"].ToString();
                            string state = dataReader["state"].ToString();
                            string zip = dataReader["zip"].ToString();
                            string phoneNumber = dataReader["phone_number"].ToString();
                            string email = dataReader["email"].ToString();
                            string addressBookName = dataReader["name"].ToString();
                            string type = dataReader["type"].ToString();

                            Contact contact = new Contact();
                            contact.firstName = firstName;
                            contact.lastName = lastName;
                            contact.address = address;
                            contact.city = city;
                            contact.state = state;
                            contact.zip = zip;
                            contact.phoneNumber = phoneNumber;
                            contact.email = email;
                            contact.addressBookName = addressBookName;
                            contact.contactType = type;

                            contactList.Add(contact);
                        }
                        dataReader.Close();
                        return contactList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
