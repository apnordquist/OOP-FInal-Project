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
/*        public void Create()
        {
            string query = "DROP TABLE `dbmatches`;\r\nCREATE TABLE `dbmatches` (\r\n\t`player1` INT(11) NOT NULL,\r\n\t`player2` INT(11) NOT NULL,\r\n\t`round` INT(11) NOT NULL,\r\n\t`table` INT(11) NOT NULL,\r\n\t`result` VARCHAR(30) NULL DEFAULT NULL,\r\n\tPRIMARY KEY (`player1`, `player2`)\r\n);";

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
        //Insert statement
        public void Save(int player1, int player2, int round, int table, string result)
        {
            string query = $"INSERT INTO dbmatches (player1, player2, round, table, result) VALUES('{player1}', '{player2}','{round}','{table}','{result}')";

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
                    list.Add(dataReader["player1"].ToString());
                    list.Add(dataReader["player2"].ToString());
                    list.Add(dataReader["round"].ToString());
                    list.Add(dataReader["table"].ToString());
                    list.Add(dataReader["result"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
                Player player1 = tournament.PlayerList[int.Parse(list[0])];
                Player player2 = tournament.PlayerList[int.Parse(list[1])];

                Match newMatch = new Match(player1, player2, int.Parse(list[2]), int.Parse(list[3]), list[4]);
                matches.Add(newMatch);
            }
            return matches;
        }
    }
}
