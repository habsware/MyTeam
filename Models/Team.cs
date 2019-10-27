using System;
using System.Collections.Generic;

namespace MyTeam.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public List<Player> Squad { get; set; }
        public List<Competition> Competitions { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
        public string Venue { get; set; }
        public string CrestUrl { get; set; }
        public DateTime LastUpdated { get; set; }
                
        
    }
}