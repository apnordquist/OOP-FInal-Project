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
/*        //create player table
        public void Create()
        {
            string query = "DROP TABLE `dbtournament`;\r\nCREATE TABLE `dbtournament` (\r\n\t`name` VARCHAR(30) NOT NULL,\r\n\t`organizer` VARCHAR(30) NULL DEFAULT NULL,\r\n\t`date` VARCHAR(30) NULL DEFAULT NULL,\r\n\tPRIMARY KEY (`name`)\r\n)\r\n;";

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
        }*/
        //Save Tournament
        public void Save(string name, string organizer, string date, int rounds)
        {
            string query = $"INSERT INTO dbtournament (name, organizer, date, rounds) VALUES('{name}', '{organizer}','{date}','{rounds}')";

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
            Tournament? select;
            List<string> list = new List<string>();

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
                    list.Add(dataReader["name"].ToString());
                    list.Add(dataReader["organizer"].ToString());
                    list.Add(dataReader["date"].ToString());
                    list.Add(dataReader["rounds"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                select = new Tournament(list[0], list[1], list[2], int.Parse(list[3]));
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
