using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyTeam.Controllers
{
    [Authorize]
    public class MatchesController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            var viewModel = new MatchesViewModel();
            var fetchedViewModel = await GetRealMadridScheduledMatches(viewModel);
            return View(fetchedViewModel);
        }
        private static async Task<MatchesViewModel> GetRealMadridScheduledMatches(MatchesViewModel matchesViewModel)
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
            var res = await client.GetAsync("v2/teams/86/matches?status=SCHEDULED");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var teamResponse = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                matchesViewModel = JsonConvert.DeserializeObject<MatchesViewModel>(teamResponse);
            }

            return matchesViewModel;
        }
    }
}