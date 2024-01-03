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
        public void GetAPI()
        {
            APIService aPIService = new();
            List<GameModel.Match> matches;
            CompareOdds co = new();
            //List<Game> bestOdds = new();
            List<Game> topThreeOdds;
            MailService mailService = new();

            matches = aPIService.GetMatchInfo().Result;
            //bestOdds = co.OddsForTheHighest(matches);
            topThreeOdds = co.OddsForTopThree(matches);

            string content = mailService.CreateContentForTopThree(topThreeOdds);
            
            //mailService.SendResultMail(content);

        }

    }
}