using System;

namespace MyTeam.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public DateTime LastUpdated { get; set; }
        public Standings Standings { get; set; }
    }
}