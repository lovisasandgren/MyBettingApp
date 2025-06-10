using Microsoft.AspNetCore.Mvc;
using MyBettingApp.Models;
using MyBettingApp.Service;
using System.Diagnostics;

namespace MyBettingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string GetAPI()
        {
            List<string> mailadresses = new List<string>
            {
                "lovisa.sandgren@gmail.com"
            };


            APIService aPIService = new();
            List<GameModel.Match> matches;
            CompareOdds co = new();
            //List<Game> bestOdds = new();
            List<Game> topThreeOdds = new();
            MailService mailService = new();
            List<OddsModel> oddsList = new();

            matches = aPIService.GetMatchInfo().Result;
            //bestOdds = co.OddsForTheHighest(matches);
            //topThreeOdds = co.OddsForTopThree(matches);
            oddsList = co.CheckForAlwaysProfit(matches);
            string contentAlwaysProfit = mailService.CreateContentForAlwaysProfit(oddsList, 200.0);
            mailService.SendResultMail(contentAlwaysProfit, mailadresses, "Garanterad vinst");

            //string contentTopThree = mailService.CreateContentForTopThree(topThreeOdds);
            //mailService.SendResultMail(contentTopThree, mailadresses,"Bästa bettingsidorna för Champions League");



            return("ok")
        }

    }
}