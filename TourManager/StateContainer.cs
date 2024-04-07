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
        private Tournament savedTournament = new Tournament("None", "None", "Today"); //the saved state between pages and default state

        public Tournament currentTournament //the state as reperesented on the page
        {
            get => savedTournament; //get the saved state
            set
            {
                savedTournament = value; //set state of the page
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
