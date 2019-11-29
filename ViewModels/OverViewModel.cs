using System.Collections.Generic;
using MyTeam.Models;

namespace MyTeam.ViewModels
{
    public class OverViewModel
    {
        public Team MyTeam { get; set; }
        public List<CompetitionStandings> CompetitionStandings { get; set; }
        public List<News> News{ get; set; }

        public OverViewModel()
        {
            MyTeam = new Team();
            CompetitionStandings = new List<CompetitionStandings>();
            News = new List<News>();
        }
    }
}