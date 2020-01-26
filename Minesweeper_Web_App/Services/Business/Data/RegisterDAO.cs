using Minesweeper_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business.Data
{
    public class RegisterDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddByUser(UserModel user)
        {
            if (checkForDuplicateUser(user) == false)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO dbo.Users (FirstName, LastName, Gender, Age, State, Email, Username, Password) VALUES (@FIRSTNAME, @LASTNAME, @GENDER, @AGE, @STATE, @EMAIL, @USERNAME, @PASSWORD)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FIRSTNAME", user.FirstName);
                        command.Parameters.AddWithValue("@LASTNAME", user.LastName);
                        command.Parameters.AddWithValue("@GENDER", user.Gender);
                        command.Parameters.AddWithValue("@AGE", user.Age);
                        command.Parameters.AddWithValue("@STATE", user.State);
                        command.Parameters.AddWithValue("@EMAIL", user.Email);
                        command.Parameters.AddWithValue("@USERNAME", user.Username);
                        command.Parameters.AddWithValue("@PASSWORD", user.Password);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        //Check for error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into database");
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("An error has occurred, duplicate username found");
                return false;
            }
        }

        public bool checkForDuplicateUser(UserModel user)
        {
            bool success = false;
            string queryString = "select * from dbo.users where username = @username";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}