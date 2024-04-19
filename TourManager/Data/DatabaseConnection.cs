using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    internal class DatabaseConnection
    {
        internal MySqlConnection connection;
        internal string server;
        internal string database;
        private string uid;
        private string password;

        //Constructor
        internal DatabaseConnection()
        {
            Initialize();
        }

        //Initialize values
        internal void Initialize()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "9224033",
                Database = "connectcsharptomysql",
            };

            connection = new MySqlConnection(builder.ConnectionString);
        }

        //open connection to database
        internal bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        internal bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Save Tournament
        public void Save(string name, string organizer, string date)
        {
            string query = $"INSERT INTO tournaments (name, organizer, date) VALUES('{name}', '{organizer}','{date}')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Load Tournament
        public Tournament? Load()
        {
            string query = $"SELECT * FROM tournaments";

            //Create a var to store the result
            Tournament? select;
            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["name"].ToString());
                    list.Add(dataReader["organizer"].ToString());
                    list.Add(dataReader["date"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                select = new Tournament(list[0], list[1], list[2]);
                //return list to be displayed
                return select;
            }
            else
            {
                return null;
            }
        }
    }
}
