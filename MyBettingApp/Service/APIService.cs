using Microsoft.Extensions.Logging;
using MyBettingApp.Models;
using Newtonsoft.Json;
using System.Net.Http;

public class APIService
{
	private readonly string _apiKey = "d822d85bcaed6d120011ed888768e26b";
	private readonly string _url = "https://api.the-odds-api.com/v4/sports/soccer_epl/odds/?apiKey=d822d85bcaed6d120011ed888768e26b&regions=eu&markets=h2h";
	private readonly ILogger<APIService> _logger;
	public List<Game> games = new();

	public APIService(ILogger<APIService> logger)
	{
		_logger = logger;
	}

	public async Task<List<GameModel.Match>> GetMatchInfo()
	{
		_logger.LogInformation("GetMatchInfo called at {Time}", DateTime.UtcNow);

		var client = new HttpClient();
		List<GameModel.Match> matches = new List<GameModel.Match>();

		var request = new HttpRequestMessage(HttpMethod.Get, this._url);
		request.Headers.Add("api_token", this._apiKey);

		try
		{
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();

			if (!string.IsNullOrEmpty(responseBody))
			{
				matches = JsonConvert.DeserializeObject<List<GameModel.Match>>(responseBody);
				_logger.LogInformation("GetMatchInfo fetched {Count} matches at {Time}", matches.Count, DateTime.UtcNow);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error fetching match info at {Time}", DateTime.UtcNow);
		}

		return matches;
	}
}
