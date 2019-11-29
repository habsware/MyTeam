using System;
using System.Collections.Generic;

namespace MyTeam.Models
{
    public class Standings
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public string Type{ get; set; }
        public string Group{ get; set; }
        public List<TableItem> Table{ get; set; }
        public DateTime LastUpdated { get; set; }
    }
}