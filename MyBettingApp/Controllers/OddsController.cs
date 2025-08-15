using Microsoft.AspNetCore.Mvc;
using MyBettingApp.Models;
using MyBettingApp.Service;
using System.Collections.Generic;

namespace MyBettingApp.Controllers;
[ApiController]
[Route("api/[Controller]")]

public class OddsController : Controller
{
	private readonly APIService _apiService = new APIService();
	private readonly CompareOdds _compareOdds = new CompareOdds();
	private readonly MailService _mailService = new MailService(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

	[HttpGet("SendAlwaysProfil")]
	public string SendAlwaysProfil()
	{
		List<GameModel.Match> matches = _apiService.GetMatchInfo().Result;
		List<OddsModel> oddsList = _compareOdds.CheckForAlwaysProfit(matches);
		string contentAlwaysProfit = _mailService.CreateContentForAlwaysProfit(oddsList, 200.0);
		_mailService.SendResultMail(contentAlwaysProfit, "Garanterad vinst");

		return "ok";
	}

	[HttpGet("SendOddsForTopThree")]
	public string SendOddsForTopThree()
	{
		List<GameModel.Match> matches = _apiService.GetMatchInfo().Result;
		List<Game> topThreeOdds = _compareOdds.OddsForTopThree(matches);
		string contentTopThree = _mailService.CreateContentForTopThree(topThreeOdds);
		_mailService.SendResultMail(contentTopThree, "Bästa bettingsidorna för Premier League");

		return "ok";
	}

}

