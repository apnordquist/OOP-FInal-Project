using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Data;

namespace TourManager.Database
{
    internal class DBmatch : DatabaseConnection
    {
        //create match table
        public void Create()
        {
            string query = "DROP TABLE `dbmatches`;CREATE TABLE `dbmatches` (`player1` INT(11) NOT NULL,`player2` INT(11) NOT NULL,`round` INT(11) NOT NULL,`table` INT(11) NOT NULL,`result` VARCHAR(30) NULL DEFAULT NULL,PRIMARY KEY (`player1`, `player2`));";

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
        //Insert statement
        public void Save(int player1, int player2, int round, int table, string result)
        {
            string query = $"INSERT INTO dbmatches VALUES('{player1}', '{player2}','{round}','{table}','{result}')";

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

        //Select statement
        public List<Match> Load(Tournament tournament)
        {
            string query = $"SELECT * FROM dbmatches";

            //Create a var to store the result
            List<Match> matches = new List<Match>();

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
                    string player1ID = dataReader["player1"].ToString();
                    string player2ID = dataReader["player2"].ToString();
                    string round = dataReader["round"].ToString();                  
                    string table = dataReader["table"].ToString();
                    string result = dataReader["result"].ToString();
                    //get players from playerlist
                    Player player1 = tournament.SearchByID(int.Parse(player1ID));
                    Player player2 = tournament.SearchByID(int.Parse(player2ID));

                    Match newMatch = new Match(player1, player2, int.Parse(round), int.Parse(table), result);
                    matches.Add(newMatch);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }
            return matches;
        }
    }
}
