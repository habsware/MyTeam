using System;

namespace MyTeam.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }
        public string Plan { get; set; }
        public DateTime LastUpdated { get; set; }
        public Standings Standings { get; set; }
    }

    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}