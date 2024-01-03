using System.Collections.Generic;
using System.Linq;

namespace MyBettingApp.Models
{
    public class CompareOdds
    {
        public List<Game> OddsForTheHighest(List<GameModel.Match> matches)
        {
            List<Game> bestOdds = new List<Game>();
            for (int i = 0; i < matches.Count; i++)
            {
                double bestHomeOdds = 0;
                double bestAwayOdds = 0;
                double bestDrawOdds = 0;
                string BestHomeOddsCompany = "";
                string BestAwayOddsCompany = "";
                string BestDrawOddsCompany = "";
                
                for (int j = 0; j < matches[i].bookmakers.Count; j++)
                {
                    
                    for (int k = 0; k < matches[i].bookmakers[j].markets.Count; k++)
                    {

                        if (matches[i].bookmakers[j].markets[k].outcomes[0].price > bestHomeOdds)
                        {
                            bestHomeOdds = matches[i].bookmakers[j].markets[k].outcomes[0].price;
                            BestHomeOddsCompany = matches[i].bookmakers[j].title;
                        }
                        if (matches[i].bookmakers[j].markets[k].outcomes[1].price > bestAwayOdds)
                        {
                            bestAwayOdds = matches[i].bookmakers[j].markets[k].outcomes[1].price;
                            BestAwayOddsCompany = matches[i].bookmakers[j].title;
                        }
                        if (matches[i].bookmakers[j].markets[k].outcomes[2].price > bestDrawOdds)
                        {
                            bestDrawOdds = matches[i].bookmakers[j].markets[k].outcomes[2].price;
                            BestDrawOddsCompany = matches[i].bookmakers[j].title;
                        }
                    }
                    
                }
                Game odds = new Game(matches[i].home_team, matches[i].away_team, BestHomeOddsCompany, BestAwayOddsCompany, BestDrawOddsCompany, bestHomeOdds, bestAwayOdds, bestDrawOdds);
                bestOdds.Add(odds);
            }
            return bestOdds;
        }



        public List<Game> OddsForTopThree(List<GameModel.Match> matches)
        {
            List<Game> bestOdds = new List<Game>();
            for (int i = 0; i < matches.Count; i++)
            {
                Dictionary<string, double> homeOdds = new Dictionary<string, double>();
                Dictionary<string, double> awayOdds = new Dictionary<string, double>();
                Dictionary<string, double> drawOdds = new Dictionary<string, double>();


                for (int j = 0; j < matches[i].bookmakers.Count; j++)
                {
                    int l = 0;
                    for (int k = 0; k < matches[i].bookmakers[j].markets.Count; k++)
                    {
                        homeOdds.Add(l+matches[i].bookmakers[j].title, matches[i].bookmakers[j].markets[k].outcomes[0].price);
                        awayOdds.Add(l+matches[i].bookmakers[j].title, matches[i].bookmakers[j].markets[k].outcomes[1].price);
                        drawOdds.Add(l+matches[i].bookmakers[j].title, matches[i].bookmakers[j].markets[k].outcomes[2].price);
                        l++;
                    };

                }
                var sortedHomeOdds = homeOdds.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                var sortedAwayOdds = awayOdds.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                var sortedDrawOdds = drawOdds.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                int hl = sortedHomeOdds.Count-1;
                int al = sortedAwayOdds.Count-1;
                int dl = sortedAwayOdds.Count-1;

                Game odds = new(
                    matches[i].home_team, 
                    matches[i].away_team, 
                    sortedHomeOdds.ElementAt(hl).Key.Substring(1), 
                    sortedAwayOdds.ElementAt(al).Key.Substring(1), 
                    sortedDrawOdds.ElementAt(dl).Key.Substring(1),
                    sortedHomeOdds.ElementAt(hl).Value, 
                    sortedAwayOdds.ElementAt(al).Value, 
                    sortedDrawOdds.ElementAt(dl).Value, 
                    sortedHomeOdds.ElementAt(0).Key.Substring(1), 
                    sortedAwayOdds.ElementAt(0).Key.Substring(1), 
                    sortedDrawOdds.ElementAt(0).Key.Substring(1), 
                    sortedHomeOdds.ElementAt(0).Value, 
                    sortedAwayOdds.ElementAt(0).Value, 
                    sortedDrawOdds.ElementAt(0).Value, 
                    sortedHomeOdds.ElementAt(hl-1).Key.Substring(1), 
                    sortedAwayOdds.ElementAt(al - 1).Key.Substring(1), 
                    sortedDrawOdds.ElementAt(dl - 1).Key.Substring(1), 
                    sortedHomeOdds.ElementAt(hl-1).Value, 
                    sortedAwayOdds.ElementAt(al - 1).Value, 
                    sortedDrawOdds.ElementAt(dl - 1).Value, 
                    sortedHomeOdds.ElementAt(hl - 2).Key.Substring(1), 
                    sortedAwayOdds.ElementAt(al - 2).Key.Substring(1), 
                    sortedDrawOdds.ElementAt(dl - 2).Key.Substring(1), 
                    sortedHomeOdds.ElementAt(hl - 2).Value, 
                    sortedAwayOdds.ElementAt(al - 2).Value, 
                    sortedDrawOdds.ElementAt(dl - 2).Value
                    );
                bestOdds.Add(odds);
            }
            return bestOdds;
        }

        public void CheckForAlwaysProfit()
        {

        }


    }
}
