using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_FInalProject.Data
{
    internal class Match
    {
        //atributes
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Round Round { get; set; }
        public string Result { get; set; }
        //constructor
        public Match (Player player1, Player player2)
        {  
            Player1 = player1; 
            Player2 = player2;
        }
        //method
        public void EnterResult(string winner)
        {
            Result = winner;
            //update records
            switch (winner) 
            {
                case "P1 Wins":
                    Player1.Wins++;
                    Player2.Losses++;
                    break;
                case "P2 Wins":
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
