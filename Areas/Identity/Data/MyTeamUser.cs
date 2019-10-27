using System;
using Microsoft.AspNetCore.Identity;

namespace MyTeam.Areas.Identity.Data
{
    public class MyTeamUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        
        [PersonalData]
        public DateTime DayOfBirth { get; set; }
        
        [PersonalData]
        public MyTeamIdEnum MyTeamId { get; set; }    
    }

    public enum MyTeamIdEnum
    {
        RealMadrid = 46,
        BayernMunchen = 43
    }
}