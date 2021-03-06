﻿// --------------------------------------------------------------------------------------------------------------------
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

        /// <summary>
        /// UC18
        /// Retrieves the contact between two dates.
        /// </summary>
        /// <param name="date1">The date1.</param>
        /// <param name="date2">The date2.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static List<Contact> RetrieveContactBetweenTwoDates(string date1, string date2)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            List<Contact> contactList = new List<Contact>();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spGetDetailsBetweenTwoDates", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@date1", date1);
                    sqlCommand.Parameters.AddWithValue("@date2", date2);
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
        /// UC19
        /// Gets the number of contacts for city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static int GetNumberOfContactsForCity(string city)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spGetNumberOfContactsForCity", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@city", city);
                    int city_count = (int)sqlCommand.ExecuteScalar();
                    return city_count;
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
        /// UC19
        /// Gets the number of contacts for State.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static int GetNumberOfContactsForState(string state)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spGetNumberOfContactsForState", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@state", state);
                    int state_count = (int)sqlCommand.ExecuteScalar();
                    return state_count;
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

        public static void AddContact(Contact contact)
        {
            SqlConnection sqlConnection = DBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.spAddNewContact", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@first_name", contact.firstName);
                    sqlCommand.Parameters.AddWithValue("@last_name", contact.lastName);
                    sqlCommand.Parameters.AddWithValue("@address", contact.address);
                    sqlCommand.Parameters.AddWithValue("@city", contact.city);
                    sqlCommand.Parameters.AddWithValue("@state", contact.state);
                    sqlCommand.Parameters.AddWithValue("@zip", contact.zip);
                    sqlCommand.Parameters.AddWithValue("@phone_number", contact.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@email", contact.email);
                    sqlCommand.Parameters.AddWithValue("@contact_type", contact.contactType);
                    sqlCommand.Parameters.AddWithValue("@address_book_name", contact.addressBookName);
                    sqlCommand.Parameters.AddWithValue("@date_added", contact.dateAdded);
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
    }
}
