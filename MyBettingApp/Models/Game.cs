namespace MyBettingApp.Models
{
    public class Game
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string BettingCompanyHomeOdds { get; set; }
        public string BettingCompanyAwayOdds { get; set; }
        public string BettingCompanyDrawOdds { get; set; }
        public double BestHomeTeamOdds { get;set; }
        public double BestAwayTeamOdds { get; set; }
        public double BestDrawOdds { get; set; }
        public string BettingCompanyHomeLowestOdds { get; set; }
        public string BettingCompanyAwayLowestOdds { get; set; }
        public string BettingCompanyDrawLowestOdds { get; set; }
        public double LowestHomeTeamOdds { get; set; }
        public double LowestAwayTeamOdds { get; set; }
        public double LowestDrawOdds { get; set; }
        //Top 2
        public string BettingCompanyHomeTop2Odds { get; set; }
        public string BettingCompanyAwayTop2Odds { get; set; }
        public string BettingCompanyDrawTop2Odds { get; set; } 
        public double Top2HomeTeamOdds { get; set; }
        public double Top2AwayTeamOdds { get; set; }
        public double Top2DrawOdds { get; set; }
        //Top 3
        public string BettingCompanyHomeTop3Odds { get; set; }
        public string BettingCompanyAwayTop3Odds { get; set; }
        public string BettingCompanyDrawTop3Odds { get; set; } 
        public double Top3HomeTeamOdds { get; set; }
        public double Top3AwayTeamOdds { get; set; }
        public double Top3DrawOdds { get; set; }

        // Constructor
        public Game(string homeTeam, string awayTeam, string bettingCompanyHomeOdds, string bettingCompanyAwayOdds, string bettingCompanyDrawOdds, double bestHomeTeamOdds, double bestAwayTeamOdds, double bestDrawOdds)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            BettingCompanyHomeOdds = bettingCompanyHomeOdds;
            BettingCompanyAwayOdds = bettingCompanyAwayOdds;
            BettingCompanyDrawOdds = bettingCompanyDrawOdds;
            BestHomeTeamOdds = bestHomeTeamOdds;
            BestAwayTeamOdds = bestAwayTeamOdds;
            BestDrawOdds = bestDrawOdds;
            BettingCompanyHomeLowestOdds = "";
            BettingCompanyAwayLowestOdds = "";
            BettingCompanyDrawLowestOdds = "";

            BettingCompanyHomeTop2Odds = "";
            BettingCompanyAwayTop2Odds = "";
            BettingCompanyDrawTop2Odds = "";

            BettingCompanyHomeTop3Odds = "";
            BettingCompanyAwayTop3Odds = "";
            BettingCompanyDrawTop3Odds = "";
        }

        // Constructor
        public Game(
            string homeTeam,
            string awayTeam,
            string bettingCompanyHomeOdds,
            string bettingCompanyAwayOdds,
            string bettingCompanyDrawOdds,
            double bestHomeTeamOdds,
            double bestAwayTeamOdds,
            double bestDrawOdds,
            string bettingCompanyHomeLowestOdds,
            string bettingCompanyAwayLowestOdds,
            string bettingCompanyDrawLowestOdds,
            double lowestHomeTeamOdds,
            double lowestAwayTeamOdds,
            double lowestDrawOdds,
            string bettingCompanyHomeTop2Odds,
            string bettingCompanyAwayTop2Odds,
            string bettingCompanyDrawTop2Odds,
            double top2HomeTeamOdds,
            double top2AwayTeamOdds,
            double top2DrawOdds,
            string bettingCompanyHomeTop3Odds,
            string bettingCompanyAwayTop3Odds,
            string bettingCompanyDrawTop3Odds,
            double top3HomeTeamOdds,
            double top3AwayTeamOdds,
            double top3DrawOdds)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            BettingCompanyHomeOdds = bettingCompanyHomeOdds;
            BettingCompanyAwayOdds = bettingCompanyAwayOdds;
            BettingCompanyDrawOdds = bettingCompanyDrawOdds;
            BestHomeTeamOdds = bestHomeTeamOdds;
            BestAwayTeamOdds = bestAwayTeamOdds;
            BestDrawOdds = bestDrawOdds;
            BettingCompanyHomeLowestOdds = bettingCompanyHomeLowestOdds;
            BettingCompanyAwayLowestOdds = bettingCompanyAwayLowestOdds;
            BettingCompanyDrawLowestOdds = bettingCompanyDrawLowestOdds;
            LowestHomeTeamOdds = lowestHomeTeamOdds;
            LowestAwayTeamOdds = lowestAwayTeamOdds;
            LowestDrawOdds = lowestDrawOdds;
            BettingCompanyHomeTop2Odds = bettingCompanyHomeTop2Odds;
            BettingCompanyAwayTop2Odds = bettingCompanyAwayTop2Odds;
            BettingCompanyDrawTop2Odds = bettingCompanyDrawTop2Odds;
            Top2HomeTeamOdds = top2HomeTeamOdds;
            Top2AwayTeamOdds = top2AwayTeamOdds;
            Top2DrawOdds = top2DrawOdds;
            BettingCompanyHomeTop3Odds = bettingCompanyHomeTop3Odds;
            BettingCompanyAwayTop3Odds = bettingCompanyAwayTop3Odds;
            BettingCompanyDrawTop3Odds = bettingCompanyDrawTop3Odds;
            Top3HomeTeamOdds = top3HomeTeamOdds;
            Top3AwayTeamOdds = top3AwayTeamOdds;
            Top3DrawOdds = top3DrawOdds;
        }


    }
}
