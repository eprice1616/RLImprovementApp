using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using RocketLeagueApp.Model;


namespace RocketLeagueApp.ViewModel

{ 
    class StatsViewModel
    {
        private readonly string apiKey = "5d1f8cb5-b2b0-4052-8619-f98e09c857cb";
        private readonly string baseUrl = "https://api.tracker.gg/api/v2/rocket-league/standard/profile/";

        public async Task<PlayerStats> GetPlayerStats(string platform, string playername)
        {
            string url = $"{baseUrl}{platform}/{playername}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Tracker API Key", apiKey);
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                JObject data = JObject.Parse(jsonResponse);
                return new PlayerStats
                {
                    Rank = data["data"]["segments"][0]["stats"]["tier"]["metadata"]["name"].ToString(),
                    ShootingPercentage = Convert.ToDouble(data["data"]["segments"][0]["stats"]["shootingPercentage"]["value"]),
                    ShotsPerGame = Convert.ToDouble(data["data"]["segments"][0]["stats"]["shotsPerGame"]["value"]),
                    SavePercentage = Convert.ToDouble(data["data"]["segments"][0]["stats"]["savesPercentage"]["value"]),
                    SavesPerGame = Convert.ToDouble(data["data"]["segments"][0]["stats"]["savesPerGame"]["value"]),
                    GoalPerMatch = Convert.ToDouble(data["data"]["segments"][0]["stats"]["goalsPerGame"]["value"])
                };
            }
        }

    }
}

