using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Areas.Identity.Data;
using Newtonsoft.Json;

namespace MyTeam.Controllers
{
    [Authorize]
    public class MyTeamController : Controller
    {
        protected readonly UserManager<MyTeamUser> UserManager;

        public MyTeamController(UserManager<MyTeamUser> userManager)
        {
            UserManager = userManager;
        }
        protected static async Task<T> GetFootballDataResources<T>(T viewModel, string uri)
        {
            var client = EstablishApiConnection();
            var res = await client.GetAsync(uri);
            if (!res.IsSuccessStatusCode) return viewModel;
            var teamResponse = res.Content.ReadAsStringAsync().Result;
            viewModel = JsonConvert.DeserializeObject<T>(teamResponse);
            return viewModel;
        }
        protected static HttpClient EstablishApiConnection()
        {
            var client = new HttpClient();
            const string baseUrl = "https://api.football-data.org/";
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            const string token = "54020c8ad3c944689b51bb2afbf16d42";
            client.DefaultRequestHeaders.Add("x-auth-token", token);
            return client;
        }
        protected MyTeamIdEnum GetMyCurrentEnumTeamName()
        {
            var currentUser = UserManager.GetUserAsync(User);
            var myTeamEnumName = currentUser.Result.MyTeamId;
            return myTeamEnumName;
        }
    }
}