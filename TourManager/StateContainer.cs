using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Components.Pages;
using TourManager.Data;

namespace TourManager
{
    public class StateContainer
    {
        //saved tournament
        private Tournament savedTournament = new Tournament("None", "None");

        //tournament to be called for each page
        public Tournament currentTournament 
        {
            //call tournament
            get => savedTournament;
            set
            {
                //set tournament for the page
                savedTournament = value; 
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
