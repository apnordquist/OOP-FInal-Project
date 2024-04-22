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
        //create player table
        public void Create()
        {
            string query = "DROP TABLE `dbplayer`; CREATE TABLE `dbplayer` (`id` INT(11) NOT NULL, `firstname` VARCHAR(30) NULL DEFAULT NULL, `lastname` VARCHAR(30) NULL DEFAULT NULL, `wins` INT(11) NULL DEFAULT NULL, `draws` INT(11) NULL DEFAULT NULL, `losses` INT(11) NULL DEFAULT NULL, `score` INT(11) NULL DEFAULT NULL, PRIMARY KEY (`id`));";

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
        //Save player to database
        public void Save(int id, string firstname, string lastname, int wins, int draws, int losses, int score)
        {
            string query = $"INSERT INTO dbplayer VALUES ('{id}', '{firstname}', '{lastname}','{wins}','{draws}','{losses}','{score}')";

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
            string query = $"SELECT * FROM dbplayer;";

            //list for the loaded players
            List<Player> players = new List<Player>();

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
                    string id = dataReader["id"].ToString();
                    string first = dataReader["firstname"].ToString();
                    string last = dataReader["lastname"].ToString();
                    string wins = dataReader["wins"].ToString();
                    string draws = dataReader["draws"].ToString();
                    string losses = dataReader["losses"].ToString();
                    string score = dataReader["score"].ToString();
                    Player newplayer = new Player(int.Parse(id), first, last, int.Parse(wins), int.Parse(draws), int.Parse(losses), int.Parse(score));
                    players.Add(newplayer);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }
            //return list to be displayed
            return players;
        }
    }
}
