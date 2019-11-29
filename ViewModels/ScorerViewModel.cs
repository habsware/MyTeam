using System.Collections.Generic;
using MyTeam.Models;

namespace MyTeam.ViewModels
{
    public class ScorerViewModel
    {
        public List<ScorerStandings> ScorerStandings { get; set; }

        public ScorerViewModel()
        {
            ScorerStandings = new List<ScorerStandings>();
        }
    }
}