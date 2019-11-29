using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyTeam.Models;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Areas.Identity.Data;
using MyTeam.ViewModels;
using Newtonsoft.Json;

namespace MyTeam.Controllers
{
    public class OverViewController : MyTeamController
    {
        public OverViewController(UserManager<MyTeamUser> userManager) : base(userManager)
        {
        }
        public async Task<IActionResult> Index()
        {
            var myTeamEnumName = GetMyCurrentEnumTeamName();
            var myTeamId = Convert.ToInt32(myTeamEnumName);
            var teamUri = "v2/teams/" + myTeamId;
            var viewModel = new OverViewModel();
            viewModel.MyTeam = await GetFootballDataResources(new Team(), teamUri);
            var competitionIds = viewModel.MyTeam.ActiveCompetitions
                .Where(a =>a.Plan == "TIER_ONE")
                .Select(a => a.Id).ToList();
            var i = 0;
            foreach (var uri in competitionIds.Select(competitionId => "v2/competitions/" + competitionId + "/standings"))
            {
                viewModel.CompetitionStandings.Add(await GetFootballDataResources(new CompetitionStandings(), uri));
                var filteredStandings = viewModel.CompetitionStandings[i].Standings.Where(s => s.Type == "TOTAL").ToList();
                viewModel.CompetitionStandings[i].Standings = filteredStandings;
                i++;
            }

            viewModel.News = await GetMyTeamNews(myTeamEnumName.ToString().ToLower());
            
            return View(viewModel);
        }

        public async Task<IActionResult> TopScorer()
        {
            var viewModel = new ScorerViewModel();
            var myTeamEnumName = GetMyCurrentEnumTeamName();
            var myTeamId = Convert.ToInt32(myTeamEnumName);
            var teamUri = "v2/teams/" + myTeamId;
            var myTeam = await GetFootballDataResources(new Team(), teamUri);
            var competitionIds = myTeam.ActiveCompetitions
                .Where(a =>a.Plan == "TIER_ONE")
                .Select(a => a.Id).ToList();
            
            foreach (var competitionId in competitionIds)
            {
                var uri = "v2/competitions/" + competitionId + "/scorers";
                viewModel.ScorerStandings.Add(await GetFootballDataResources(new ScorerStandings(), uri));
            }
            return View(viewModel);
        }
        
        public async Task<IActionResult> SelectedTeam(int id)
        {
            var dateFrom = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            var dateTo = DateTime.Now.ToString("yyyy-MM-dd");
            var matchesUri = "v2/teams/" + id + "/matches?dateFrom=" + dateFrom + "&dateTo=" + dateTo;
            var teamUri = "v2/teams/" + id;
            var viewModel = new SelectedTeamViewModel
            {
                Team = await GetFootballDataResources(new Team(), teamUri),
                TeamMatches = await GetFootballDataResources(new TeamMatches(), matchesUri)
            };
            return View(viewModel);
        }
        
        private static HttpClient EstablishSkySportApiConnection()
        {
            var client = new HttpClient();
            const string baseUrl = "https://skysportsapi.herokuapp.com/";
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        private static async Task<List<News>> GetMyTeamNews(string myTeamName)
        {
            var client = EstablishSkySportApiConnection();
            var res = await client.GetAsync("sky/football/getteamnews/" + myTeamName + "/v1.0");
            var myTeamNews = new List<News>();
            if (res.IsSuccessStatusCode)
            {
                var teamResponse = res.Content.ReadAsStringAsync().Result;
                myTeamNews = JsonConvert.DeserializeObject<List<News>>(teamResponse);
            }
            return myTeamNews;
        }
    }
}