using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    internal class DBplayer : DatabaseConnection
    {
        //Save player to database
        public void Save(int id, string firstname, string lastname, int wins, int draws, int losses, int score)
        {
            string query = $"INSERT INTO DBplayer (id, firstname, lastname, wins, draws, losses, score) VALUES('{id}', '{firstname}', '{lastname}','{wins}','{draws}','{losses}','{score}')";

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

        //load playerlist from database
        public List<Player> Load()
        {
            string query = $"SELECT * FROM DBplayer";

            //Create a var to store the result
            List<Player> players = new List<Player>();
            List<string> list = new List<string>();
            Player newplayer;

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
                this.CloseConnection();

                newplayer = new Player(int.Parse(list[0]), list[1], list[2], int.Parse(list[3]), int.Parse(list[4]), int.Parse(list[5]));
                //return list to be displayed
                players.Append(newplayer);
            }
            return players;
        }
    }
}
