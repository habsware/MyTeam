using System.Collections.Generic;

namespace MyTeam.Models
{
    public class ScorerStandings
    {
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public List<Scorer> Scorers { get; set; }

        public ScorerStandings()
        {
            Competition = new Competition();
            Season = new Season();
            Scorers = new List<Scorer>();
        }
    }
    public class Scorer
    {
        public Player Player { get; set; }
        public Team Team { get; set; }
        public int NumberOfGoals { get; set; }
    }
}