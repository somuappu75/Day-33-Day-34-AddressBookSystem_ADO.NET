using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystem_ADO.NET
{
    class AddressBookRepo
    {
        //Give path for Database Connection
        public static string connection = @"Server=.;Database=AddressBookServices;Trusted_Connection=True;";
        //Represents a connection to Sql Server Database
        SqlConnection sqlConnection = new SqlConnection(connection);
    }
}
