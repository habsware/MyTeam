using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Areas.Identity.Data;
using MyTeam.Models;

namespace MyTeam.Controllers
{
    public class SquadController : MyTeamController
    {
        public SquadController(UserManager<MyTeamUser> userManager) : base(userManager)
        {
        }
        public async Task<IActionResult> Index()
        {
            var myTeamEnumName = GetMyCurrentEnumTeamName();
            var myTeamId = Convert.ToInt32(myTeamEnumName);
            var uri = "v2/teams/" + myTeamId;
            var myTeam = await GetFootballDataResources(new Team(),uri);
            return View(myTeam);
        }

      
    }
}