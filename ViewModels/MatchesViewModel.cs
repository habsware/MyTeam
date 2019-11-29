using System.Collections.Generic;
using Match = MyTeam.Models.Match;

namespace MyTeam.ViewModels
{
    public class MatchesViewModel
    {
        public List<Match> Matches { get; set; }

        public MatchesViewModel()
        {
            Matches = new List<Match>();
        }
    }
}