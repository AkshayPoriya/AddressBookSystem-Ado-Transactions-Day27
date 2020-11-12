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

    public class DBOperations
    {
        /// <summary>
        /// UC16
        /// Gets all details.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
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

        /// <summary>
        /// UC17
        /// Updates the contact address.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <exception cref="System.Exception"></exception>
        public static void UpdateContactAddress(string firstName, string lastName, string address)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spUpdateContactAddress", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    sqlCommand.Parameters.AddWithValue("@address", address);
                    sqlCommand.ExecuteNonQuery();
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

        /// <summary>
        /// UC17
        /// Gets the address.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetAddress(string firstName, string lastName)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = @"select address from contacts 
                                    where first_name=@firstName and last_name = @lastName";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                    string address = (string)sqlCommand.ExecuteScalar();
                    return address;
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
