﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    public class Tournament
    {
        //attributes
        public string Name {  get; set; }
        public string Organizer { get; set; }
        public DateTime? Date { get; set; }
        public List<Player> PlayerList { get; set; }
        public List<Round> RoundList { get; set; }
        //constructor
        public Tournament(string name, string organizer, DateTime? date)
        {
            Name = name;
            Organizer = organizer;
            Date = date;
            PlayerList = new List<Player> ();
            RoundList = new List<Round> ();
        }
        //methods
        public void NewPlayer(string firstname, string lastname)
        {
            Player player = new Player(firstname, lastname);
            PlayerList.Add(player);
        }
        public void AddPlayer(Player player) //add existing player to Tournament
        {
            PlayerList.Add(player);
        }
        public void RemovePlayer(Player player) //remove player from Tournament
        {
            PlayerList.Remove(player);
        }
        public void RankPlayers() //method to rank players
        {
            PlayerList.Sort(new ComparePlayers()); //use IComparer class
        }
        public void PrintStandings()
        {
            RankPlayers();
            Console.WriteLine("Name\tPoints\tRecord");
            foreach (Player p in PlayerList)
            {
                p.UpdateScore();
                Console.WriteLine($"{p.Name}\t{p.Score}\t{p.PrintRecords}");
            }
        }
        public bool IsEmpty()
        {
            if ( Organizer == null && Date == null)
                return true;
            else
                return false;
        }
        public void Clear()
        {
            PlayerList = null;
            RoundList = null;
        }
    }
}
