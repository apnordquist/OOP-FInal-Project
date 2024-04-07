using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    public class Match
    {
        //atributes
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Round { get; set; }
        public string Result { get; set; }
        public int Table { get; set; }
        //constructor
        public Match(Player player1, Player player2, int table, int round)
        {
            Player1 = player1;
            Player2 = player2;
            Table = table;
            Round = round;
        }
        //method
        public void EnterResult(string winner)
        {
            //update records
            switch (winner)
            {
                case "P1":
                    Player1.Wins++;
                    Player2.Losses++;
                    break;
                case "P2":
                    Player1.Losses++;
                    Player2.Wins++;
                    break;
                case "Draw":
                    Player1.Draws++;
                    Player2.Draws++;
                    break;
            }
            Player1.UpdateScore();
            Player2.UpdateScore();
        }
    }
}
