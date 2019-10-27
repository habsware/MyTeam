using System;

namespace MyTeam.Models
{
    public class Player
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string DateOfBirth { get; set; }
        public string Position { get; set; }        
        public string Nationality { get; set; }   
        public DateTime LastUpdated { get; set; }     
    }
}