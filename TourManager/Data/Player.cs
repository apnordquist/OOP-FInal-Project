using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    public class Player
    {
        //attributes
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name;
        public int Wins = 0;
        public int Draws = 0;
        public int Losses = 0;
        public LinkedList<Player>? Opponents;
        public int Score = 0; //combined value of wins, draws, and losses
        Random rnd = new Random();
        //constructor
        //default
        public Player(string firstname, string lastname)
        {
            PlayerID = rnd.Next(1,1000);
            FirstName = firstname;
            LastName = lastname;
            Name = firstname + " " + lastname;
            Opponents = new LinkedList<Player>();
        }
        //from database
        public Player(int id, string firstname, string lastname, int wins, int draws, int losses, int score) 
        {
            PlayerID = id;
            FirstName = firstname;
            LastName = lastname;
            Name = firstname + " " + lastname;
            Opponents = new LinkedList<Player>();
            Wins = wins;
            Draws = draws;
            Losses = losses;
            Score = score;
        }
        //methods
        public void UpdateScore() //to update score after each round
        {
            Score = Wins * 3 + Draws; //wins worth more than draws, losses count for 0
        }
        public string PrintRecords()
        {
            string record = Wins + "-" + Draws + "-" + Losses;
            return record;
        }
        public override string ToString()
        {
            return $"{Name:25} {Score:25} {Wins:25} {Draws:25} {Losses:25}";
        }
    }
}