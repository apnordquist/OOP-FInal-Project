using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Data
{
    public class ComparePlayers : IComparer<Player>
    {
        public int Compare(Player x, Player y) //method to rank players
        {
            if (x.Score < y.Score)
                return -1;
            if (x.Score > y.Score)
                return 1;
            else //if scores are equal, look at number of wins
                if (x.Wins < y.Wins)
                return -1;
            if (x.Wins > y.Wins)
                return 1;
            else
                return 0;
        }
    }
}
