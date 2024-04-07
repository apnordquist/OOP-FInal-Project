using Google.Android.Material.Color.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Util.Jar.Attributes;

namespace TourManager.Data
{
    public class Player
    {
        //attributes
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name;
        public int Wins = 0;
        public int Draws = 0;
        public int Losses = 0;
        public LinkedList<Player>? Opponents;
        public int Score = 0; //combined value of wins, draws, and losses
        //constructor
        public Player(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            Name = firstname + " " + lastname;
            Opponents = new LinkedList<Player>();
        }
        //methods
        public string PrintRecords()
        {
            string record = Wins + "-" + Draws + "-" + Losses;
            return record;
        }
        public void UpdateScore() //to update score after each round
        {
            Score = Wins * 3 + Draws; //wins worth more than draws, losses count for 0
        }
        public override string ToString()
        {
            return $"{Name:25} {Score:25} {Wins:25} {Draws:25} {Losses:25}";
        }
    }
}