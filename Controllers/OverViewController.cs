using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Newtonsoft.Json;

namespace MyTeam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var viewModel = new Team();
            var fetchViewModel = await GetRealMadridTeamResources(viewModel);
            return View(fetchViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private static async Task<Team> GetRealMadridTeamResources(Team team)
        {
            var client = new HttpClient();
            //Passing service base url
            const string baseUrl = "https://api.football-data.org/";
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            const string token = "54020c8ad3c944689b51bb2afbf16d42";
            client.DefaultRequestHeaders.Add("x-auth-token", token);
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var res = await client.GetAsync("v2/teams/86");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var teamResponse = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                team = JsonConvert.DeserializeObject<Team>(teamResponse);
            }

            return team;
        }

        public IActionResult UserTeam()
        {
            return View();
        }
        
    }
}