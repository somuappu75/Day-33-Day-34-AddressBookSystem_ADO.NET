using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystem_ADO.NET.AddressBookSystem_ADO.NET
{
   class AddressBookRepo
    {
        //Give path for Database Connection
        public static string connection = @"Server=.;Database=AddressBookServices;Trusted_Connection=True;";
        //Represents a connection to Sql Server Database
        SqlConnection sqlConnection = new SqlConnection(connection);
        public int InsertIntoTable(ContactDataManager addressBook)
        {
            int result = 0;
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spInsertintoTable", this.sqlConnection);
                    //setting command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBook.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBook.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBook.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBook.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBook.State);
                    sqlCommand.Parameters.AddWithValue("@zip", addressBook.zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", addressBook.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBook.Email);
                    sqlCommand.Parameters.AddWithValue("@addressBookName", addressBook.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@addressBookType", addressBook.Type);
                    sqlConnection.Open();
                    //Return the number of rows updated
                    result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        //Uc 3: Modify Existing Contact using their name
        public int UpdateQueryBasedonName()
        {
            //Open Connection
            sqlConnection.Open();
            string query = "Update Address_Book_Table set Email = 'Gourishete@gmail.com' where FirstName = 'gouri'";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();
            if (result != 0)
            {
                Console.WriteLine("Updated!");
            }
            else
            {
                Console.WriteLine("Not Updated!");
            }

            //Close Connection
            sqlConnection.Close();
            return result;
        }

        public void DisplayEmployeeDetails(SqlDataReader sqlDataReader)
        {

            ContactDataManager.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
            ContactDataManager.LastName = Convert.ToString(sqlDataReader["LastName"]);
            ContactDataManager.Address = Convert.ToString(sqlDataReader["Address"] + " " + sqlDataReader["City"] + " " + sqlDataReader["State"] + " " + sqlDataReader["zip"]);
            ContactDataManagerPhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNumber"]);
            ContactDataManager.Email = Convert.ToString(sqlDataReader["email"]);
            ContactDataManager.AddressBookName = Convert.ToString(sqlDataReader["AddressBookName"]);
            ContactDataManager.Type = Convert.ToString(sqlDataReader["TypeOfAddressBook"]);
            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", addressBook.FirstName, addressBook.LastName, addressBook.Address, addressBook.PhoneNumber, addressBook.Email, addressBook.AddressBookName, addressBook.Type);

        }
    }
}
