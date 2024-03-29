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
        public int CurrentRound = 0;
        public LinkedList<Match> Matches;
        //constructor
        public Round(int RoundNum, LinkedList<Match> Pairings)
        {
            CurrentRound = RoundNum;
            Matches = Pairings;
        }
        //methods
        public void CreatePairings(Tournament tournament) //creates a number of matches for the round
        {
            CurrentRound++;
            Matches = new LinkedList<Match>();
            tournament.RankPlayers();
            for (int i = 0; i < tournament.PlayerList.Count; i += 2) // count by 2 for each pairing
            {
                //skeleton pairing
                Player current = tournament.PlayerList[i];
                Player opponent = null;

                for (int j = i + 1; j < tournament.PlayerList.Count; j++) //loop through players
                {
                    if (!current.Opponents.Contains(tournament.PlayerList[j])) //filter out previous opponents
                    {
                        opponent = tournament.PlayerList[j]; //next closest ranked player
                        break;
                    }
                    if (opponent != null) //if opponent found, create pairing
                    {
                        Match pairing = new Match(current, opponent); //new match
                        Matches.AddLast(pairing); //add to list
                        break;
                    }
                    else
                    {
                        //if no opponent is found
                    }
                }
            }
            Round NextRound = new Round(CurrentRound, Matches); //create the round object
        }
        public void UpdatePairing(Round round, Player player1, Player player2) //manual override to create pairing
        {
            //add function to search and remove old pairings
            Match newMatch = new Match(player1, player2); //create the new match
            round.Matches.AddLast(newMatch);
        }

    }
}
