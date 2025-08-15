using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using MyBettingApp.Models;
using Newtonsoft.Json;

namespace MyBettingApp.Service
{
    public class APIService
    {
        private readonly string _apiKey = "d822d85bcaed6d120011ed888768e26b";
        private readonly string _url = "https://api.the-odds-api.com/v4/sports/soccer_epl/odds/?apiKey=d822d85bcaed6d120011ed888768e26b&regions=eu&markets=h2h";
        public List<Game> games = new();
        
        public async Task<List<GameModel.Match>> GetMatchInfo()
        {

            var client = new HttpClient();
            List<GameModel.Match> matches = new List<GameModel.Match>();

            var request = new HttpRequestMessage(HttpMethod.Get, this._url);
            request.Headers.Add("api_token", this._apiKey);
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                if(responseBody != null)
                {
                    matches = JsonConvert.DeserializeObject<List<GameModel.Match>>(responseBody);
                }
                


            }
            catch (Exception)
            {

            }


           return matches;
        }
    }
}
