using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Areas.Identity.Data;
using Newtonsoft.Json;

namespace MyTeam.Controllers
{
    public class MatchesController : MyTeamController
    {
        public MatchesController(UserManager<MyTeamUser> userManager) : base(userManager)
        {
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var currentUser =  await UserManager.GetUserAsync(User);
            var myTeamEnumName = currentUser.MyTeamId;
            var myTeamIdInt = Convert.ToInt32(myTeamEnumName);
            var uri = "v2/teams/" + myTeamIdInt + "/matches?status=SCHEDULED";
            var viewModel = await GetFootballDataResources(new MatchesViewModel(), uri);
            return View(viewModel);
        }
    }
}