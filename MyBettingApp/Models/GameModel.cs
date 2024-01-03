namespace MyBettingApp.Models
{
    public class GameModel
    {
        public class Outcome
        {
            public string name { get; set; }
            public double price { get; set; }
        }

        public class Market
        {
            public string key { get; set; }
            public DateTime last_update { get; set; }
            public List<Outcome> outcomes { get; set; }
        }

        public class Bookmaker
        {
            public string key { get; set; }
            public string title { get; set; }
            public DateTime last_update { get; set; }
            public List<Market> markets { get; set; }
        }

        public class Match
        {
            public string id { get; set; }
            public string sport_key { get; set; }
            public string sport_title { get; set; }
            public DateTime commence_time { get; set; }
            public string home_team { get; set; }
            public string away_team { get; set; }
            public List<Bookmaker> bookmakers { get; set; }
        }

    }
}
