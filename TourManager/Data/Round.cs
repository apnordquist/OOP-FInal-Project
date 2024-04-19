using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    public class Round
    {
        //attributes
        public int CurrentRound { get; set; }
        public List<Match> Matches;
        //constructor
        public Round(int RoundNum)
        {
            CurrentRound = RoundNum;
            Matches = new List<Match>();
        }
        //methods
        public void CreatePairings(List<Player> PlayerList, int round) //creates a number of matches for the round
        {
            if (PlayerList.Count % 2 != 0) //make sure list is even
            {
                Player by = new Player("", "bye");
                PlayerList.Add(by); //add a 'bye' for one unmatched player, will count as a free win
            }
            List<Player> Finished = new List<Player>(); //players already in a pairing
            int table = 0; //starting table
            for (int i = 0; i < PlayerList.Count; i++) // count by 2 for each pairing
            {
                Player current = PlayerList[i];
                if (!Finished.Contains(current))
                {
                    table++;
                    for (int j = i + 1; j < PlayerList.Count; j++) //loop through players
                    {
                        if (current.Opponents.First == null) //if list is empty
                        {
                            Match pairing = new Match(current, PlayerList[j], round, table); //new match
                            current.Opponents.AddLast(PlayerList[j]); //add to past opponent
                            Matches.Add(pairing); //add to list
                            Finished.Add(PlayerList[j]); //add to finished to not pair again
                            break;
                        }
                        if (!current.Opponents.Contains(PlayerList[j])) //if not previous opponents
                        {
                            Match pairing = new Match(current, PlayerList[j], round, table); //new match
                            current.Opponents.AddLast(PlayerList[j]); //add to past opponent
                            Matches.Add(pairing); //add to list
                            Finished.Add(PlayerList[j]); //add to finished to not pair again
                            break;
                        } 
                    }
                }
            }
        }
        public string PrintPairings() // return all matches as a string
        {
            string Pairings = "";
            foreach (Match match in Matches)
            {
                Pairings += $"{match.Player1.Name} vs {match.Player2.Name}\n";
            }
            return Pairings;
        }
        public void UpdatePairing(Round CurrentRound, Player player1, Player player2, int table, int round) //manual override to create pairing
        {
            //add function to search and remove old pairings
            Match newMatch = new Match(player1, player2, table, round); //create the new match
            CurrentRound.Matches.Add(newMatch);
        }
    }
}
