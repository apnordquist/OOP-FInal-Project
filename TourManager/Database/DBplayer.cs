using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Data;

namespace TourManager.Database
{
    internal class DBplayer : DatabaseConnection
    {
/*        //create player table
        public void Create()
        {
            string query = "DROP TABLE `dbplayer`;\r\nCREATE TABLE `dbplayer` (\r\n\t`id` INT(11) NOT NULL,\r\n\t`firstname` VARCHAR(30) NULL DEFAULT NULL COLLATE,\r\n\t`lastname` VARCHAR(30) NULL DEFAULT NULL,\r\n\t`wins` INT(11) NULL DEFAULT NULL,\r\n\t`draws` INT(11) NULL DEFAULT NULL,\r\n\t`losses` INT(11) NULL DEFAULT NULL,\r\n\t`score` INT(11) NULL DEFAULT NULL,\r\n\tPRIMARY KEY (`id`)\r\n);";

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
        //Save player to database
        public void Save(int id, string firstname, string lastname, int wins, int draws, int losses, int score)
        {
            string query = $"INSERT INTO dbplayer (id, firstname, lastname, wins, draws, losses, score) VALUES('{id}', '{firstname}', '{lastname}','{wins}','{draws}','{losses}','{score}')";

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

        //load playerlist from database
        public List<Player> Load()
        {
            string query = $"SELECT * FROM dbplayer";

            //Create a var to store the result
            List<Player> players = new List<Player>();
            List<string> list = new List<string>();
            Player newplayer;

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
                    list.Add(dataReader["id"].ToString());
                    list.Add(dataReader["firstname"].ToString());
                    list.Add(dataReader["lastname"].ToString());
                    list.Add(dataReader["wins"].ToString());
                    list.Add(dataReader["draws"].ToString());
                    list.Add(dataReader["losses"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                newplayer = new Player(int.Parse(list[0]), list[1], list[2], int.Parse(list[3]), int.Parse(list[4]), int.Parse(list[5]));
                //return list to be displayed
                players.Append(newplayer);
            }
            return players;
        }
    }
}
