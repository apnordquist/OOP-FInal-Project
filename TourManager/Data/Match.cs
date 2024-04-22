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
        public bool Reported { get; set; }
        //constructor
        //default
        public Match(Player player1, Player player2, int round, int table)
        {
            Player1 = player1;
            Player2 = player2;
            Round = round;
            Table = table;
            Reported = false;
        }
        //from database
        public Match(Player player1, Player player2, int round, int table, string result)
        {
            Player1 = player1;
            Player2 = player2;
            Round = round;
            Table = table;
            Result = result;
            if (result != null) 
            { 
                Reported = true;
            }
        }
        //method
        public void EnterResult(string winner)
        {
            Result = winner; //store in object
            if (Reported == false)
            {
                //report match
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
                Reported = true;
            }
            else
            {
                //update results
                switch (winner)
                {
                    case "P1":
                        Player1.Wins++;
                        Player2.Losses++;
                        Player2.Wins--;
                        Player1.Losses--;
                        break;
                    case "P2":
                        Player1.Losses++;
                        Player2.Wins++;
                        Player2.Losses--;
                        Player1.Wins--;
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
}
