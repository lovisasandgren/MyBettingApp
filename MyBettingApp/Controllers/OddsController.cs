using Microsoft.AspNetCore.Mvc;
using MyBettingApp.Models;
using MyBettingApp.Service;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MyBettingApp.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class OddsController : Controller
	{
		private readonly APIService _apiService = new APIService();
		private readonly CompareOdds _compareOdds = new CompareOdds();
		private readonly MailService _mailService = new MailService(
			new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
		);

		private readonly ILogger<OddsController> _logger;

		// Lägg till ILogger via dependency injection
		public OddsController(ILogger<OddsController> logger)
		{
			_logger = logger;
		}

		[HttpGet("SendAlwaysProfil")]
		public string SendAlwaysProfil()
		{
			_logger.LogInformation("SendAlwaysProfil called at {Time}", DateTime.UtcNow);

			try
			{
				List<GameModel.Match> matches = _apiService.GetMatchInfo().Result;
				List<OddsModel> oddsList = _compareOdds.CheckForAlwaysProfit(matches);
				string contentAlwaysProfit = _mailService.CreateContentForAlwaysProfit(oddsList, 200.0);
				_mailService.SendResultMail(contentAlwaysProfit, "Garanterad vinst");

				_logger.LogInformation("SendAlwaysProfil finished successfully at {Time}", DateTime.UtcNow);
				return "ok";
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in SendAlwaysProfil at {Time}", DateTime.UtcNow);
				return "error";
			}
		}

		[HttpGet("SendOddsForTopThree")]
		public string SendOddsForTopThree()
		{
			_logger.LogInformation("SendOddsForTopThree called at {Time}", DateTime.UtcNow);

			try
			{
				List<Game> topThreeOdds = _compareOdds.OddsForTopThree(_apiService.GetMatchInfo().Result);
				string contentTopThree = _mailService.CreateContentForTopThree(topThreeOdds);
				_mailService.SendResultMail(contentTopThree, "Bästa bettingsidorna för Premier League");

				_logger.LogInformation("SendOddsForTopThree finished successfully at {Time}", DateTime.UtcNow);
				return "ok";
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in SendOddsForTopThree at {Time}", DateTime.UtcNow);
				return "error";
			}
		}
	}
}
