using System.Collections.Generic;

namespace MyTeam.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}