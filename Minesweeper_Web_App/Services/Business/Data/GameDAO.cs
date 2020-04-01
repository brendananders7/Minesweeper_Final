using Minesweeper_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business.Data
{
    public class GameDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /*This method uses the connection to the database to add a new row in the game table
         * Takes a string(string is JSON serialized)
         * returns a boolean(true/false)
         */
        public bool create(string gameJSON)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //query to insert a new row into the database
                String query = "INSERT INTO dbo.Game (GameState) VALUES (@GAMESTATE)";

                //adding row
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //bind parameters
                    command.Parameters.AddWithValue("@GAMESTATE", gameJSON);

                    //open connection
                    connection.Open();

                    //execute query and store value returned in result
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

        /*This method uses the connection to the database to find a game that is in the game table
         * 
         * returns a boolean(true/false)
         */
        public bool read()
        {
            return true;
        }
    }
}