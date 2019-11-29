using System;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Real Madrid")]
        RealMadrid = 86,
        [Display(Name = "FC Barcelona")]
        Barcelona = 81,
        [Display(Name = "Atletico Madrid")]
        AtleticoMadrid = 78,
        [Display(Name = "Bayern Munich")]
        BayernMunich = 5,
        [Display(Name = "Borussia Dortmund")]
        BorussiaDortmund = 4,
        [Display(Name = "Paris SG")]
        ParisStGermain = 524,
        [Display(Name = "Tottenham Hotspurs")]
        TottenhamHotspur = 73,
        [Display(Name = "Liverpool")]
        Liverpool = 64,
        [Display(Name = "Arsenal")]
        Arsenal = 57,
        [Display(Name = "Chelsea FC")]
        Chelsea = 61,
        [Display(Name = "Manchester United")]
        ManchesterUnited = 66,
        [Display(Name = "Manchester City FC")]
        ManchesterCity = 65
        
    }
}