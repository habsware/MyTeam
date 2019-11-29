using System.Collections.Generic;
using MyTeam.Models;

namespace MyTeam.ViewModels
{
    public class SelectedTeamViewModel
    {
        public Team Team { get; set; }
        public TeamMatches TeamMatches { get; set; }
    }

    public class TeamMatches
    {
        public List<Match> Matches { get; set; }
    }
}