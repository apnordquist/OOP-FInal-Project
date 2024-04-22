using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Data;

namespace TourManager.Database
{
    internal class DBtournaments : DatabaseConnection
    {
       //create player table
        public void Create()
        {
            string query = "DROP TABLE `dbtournament`;CREATE TABLE `dbtournament` (`name` VARCHAR(30) NOT NULL,`organizer` VARCHAR(30) NULL DEFAULT NULL,`date` VARCHAR(30) NULL DEFAULT NULL,`rounds` INT(11) NULL,PRIMARY KEY (`name`));";

            //open connection
            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
        //Save Tournament
        public void Save(string name, string organizer, string date, int rounds)
        {
            string query = $"INSERT INTO dbtournament VALUES('{name}', '{organizer}','{date}','{rounds}')";

            //open connection
            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        //Load Tournament
        public Tournament? Load()
        {
            string query = $"SELECT * FROM dbtournament";

            //Create a var to store the result
            Tournament? select = null;

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    List<string> list = new List<string>();
                    list.Add(dataReader["name"].ToString());
                    list.Add(dataReader["organizer"].ToString());
                    list.Add(dataReader["date"].ToString());
                    list.Add(dataReader["rounds"].ToString());
                    select = new Tournament(list[0], list[1], list[2], int.Parse(list[3]));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();


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
