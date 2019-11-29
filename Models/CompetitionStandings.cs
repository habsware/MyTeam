using System.Collections.Generic;

namespace MyTeam.Models
{
    public class CompetitionStandings
    {
        public List<Standings> Standings { get; set; }
        public Competition Competition { get; set; }
        
    }
}