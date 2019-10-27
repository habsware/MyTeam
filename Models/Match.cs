using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTeam.Models
{
    public class Match
    {
        public int Id { get; set; }
        
        public int HomeTeamId { get; set; }
        
        public int AwayTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime UtcDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public Competition Competition  { get; set; }
        public int CompetitionId  { get; set; }
        
    }
}