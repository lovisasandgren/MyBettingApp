namespace MyBettingApp.Models
{
    public class OddsModel
    {
        

        public double HomeOdds { get; set; }
        public double DrawOdds { get; set; }
        public double AwayOdds { get; set; }
        public string HomeOddsCompany { get; set; }
        public string AwayOddsCompany { get; set; }
        public string DrawOddsCompany { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double procentHomeTeam { get; set; }
        public double procentAwayTeam { get; set; }
        public double procentDraw { get; set; }
        public double biggestWin {  get; set; }

        public OddsModel(double homeOdds, double drawOdds, double awayOdds, string homeOddsCompany, string awayOddsCompany, string drawOddsCompany, string homeTeam, string awayTeam)
        {
            HomeOdds = homeOdds;
            DrawOdds = drawOdds;
            AwayOdds = awayOdds;
            HomeOddsCompany = homeOddsCompany;
            AwayOddsCompany = awayOddsCompany;
            DrawOddsCompany = drawOddsCompany;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
        public OddsModel()
        {

        }
    }
}
