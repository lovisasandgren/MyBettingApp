using MyBettingApp.Models;
using System.Net.Mail;

namespace MyBettingApp.Service
{
	public class MailService
	{
		private readonly IConfiguration _config;

		public MailService(IConfiguration config)
		{
			_config = config;
		}
		private string startContentAlwaysProfit = @"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <h2>Bets för garanterad vinst<br/></h2>
                    </head>
                    <body>";

		private string startContentBestOdds = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <h2>Bästa oddsen på bettingsidorna<br/></h2>
                    </head>
                    <body>";

		private string endContent = "<p>-------------------</p>" +
			"</body>\r\n                    </html>";


		public string CreateContentForBestOdds(List<Game> games)
		{
			string content = startContentBestOdds;
			foreach (var game in games)
			{
				content += $"-----------------------------<br/>" +
					$"<b>{game.HomeTeam} VS {game.AwayTeam}</b>" +
					$"<p>Bäst odds för hemmalaget: {game.HomeTeam} - <b>{game.BettingCompanyHomeOdds}</b>, odds: <b>{game.BestHomeTeamOdds}</b></p>" +
					$"<p>Bäst odds för bortalaget: {game.AwayTeam} - <b>{game.BettingCompanyAwayOdds}</b>, odds: <b>{game.BestAwayTeamOdds}</b></p>" +
					$"<p>Bäst odds för lika - <b>{game.BettingCompanyDrawOdds} </b>, odds: <b>{game.BestDrawOdds}</b></p>";
			}

			content += endContent;

			return content;
		}
		public string CreateContentForTopThree(List<Game> games)
		{
			string content = startContentBestOdds;

			foreach (var game in games)
			{
				content += $@"
            <div style='border:1px solid #ddd; border-radius:8px; padding:15px; margin-bottom:20px; font-family:Arial, sans-serif;'>
                <h2 style='margin-top:0; background:#f4f4f4; padding:10px; border-radius:6px;'>{game.HomeTeam} VS {game.AwayTeam}</h2>
                
                <h3 style='color:#2c3e50;'>Topp tre odds – {game.HomeTeam}</h3>
                <table style='width:100%; border-collapse:collapse; margin-bottom:15px;'>
                    <tr><th>Plats</th><th>Spelbolag</th><th>Odds</th></tr>
                    <tr><td>1</td><td>{game.BettingCompanyHomeOdds}</td><td><b>{game.BestHomeTeamOdds}</b></td></tr>
                    <tr><td>2</td><td>{game.BettingCompanyHomeTop2Odds}</td><td>{game.Top2HomeTeamOdds}</td></tr>
                    <tr><td>3</td><td>{game.BettingCompanyHomeTop3Odds}</td><td>{game.Top3HomeTeamOdds}</td></tr>
                    <tr style='background:#f9f9f9;'><td colspan='2'>Lägsta oddset</td><td>{game.LowestHomeTeamOdds} ({game.BettingCompanyHomeLowestOdds})</td></tr>
                </table>

                <h3 style='color:#2c3e50;'>Topp tre odds – {game.AwayTeam}</h3>
                <table style='width:100%; border-collapse:collapse; margin-bottom:15px;'>
                    <tr><th>Plats</th><th>Spelbolag</th><th>Odds</th></tr>
                    <tr><td>1</td><td>{game.BettingCompanyAwayOdds}</td><td><b>{game.BestAwayTeamOdds}</b></td></tr>
                    <tr><td>2</td><td>{game.BettingCompanyAwayTop2Odds}</td><td>{game.Top2AwayTeamOdds}</td></tr>
                    <tr><td>3</td><td>{game.BettingCompanyAwayTop3Odds}</td><td>{game.Top3AwayTeamOdds}</td></tr>
                    <tr style='background:#f9f9f9;'><td colspan='2'>Lägsta oddset</td><td>{game.LowestAwayTeamOdds} ({game.BettingCompanyAwayLowestOdds})</td></tr>
                </table>

                <h3 style='color:#2c3e50;'>Topp tre odds – Oavgjort</h3>
                <table style='width:100%; border-collapse:collapse;'>
                    <tr><th>Plats</th><th>Spelbolag</th><th>Odds</th></tr>
                    <tr><td>1</td><td>{game.BettingCompanyDrawOdds}</td><td><b>{game.BestDrawOdds}</b></td></tr>
                    <tr><td>2</td><td>{game.BettingCompanyDrawTop2Odds}</td><td>{game.Top2DrawOdds}</td></tr>
                    <tr><td>3</td><td>{game.BettingCompanyDrawTop3Odds}</td><td>{game.Top3DrawOdds}</td></tr>
                    <tr style='background:#f9f9f9;'><td colspan='2'>Lägsta oddset</td><td>{game.LowestDrawOdds} ({game.BettingCompanyDrawLowestOdds})</td></tr>
                </table>
            </div>";
			}

			content += endContent;
			return content;
		}


		public string CreateContentForAlwaysProfit(List<OddsModel> winningOdds, double deposit)
		{
			string content = startContentAlwaysProfit;
			content += $"<p><b>Total insats:</b> {deposit} kronor</p>";

			foreach (var game in winningOdds)
			{
				if (game.AwayTeam == null)
					continue;

				content += $@"
            <div style='border:1px solid #ddd; border-radius:8px; padding:15px; margin-bottom:20px; font-family:Arial, sans-serif;'>
                <h2 style='margin-top:0; background:#f4f4f4; padding:10px; border-radius:6px;'>{game.HomeTeam} VS {game.AwayTeam}</h2>
                
                <table style='width:100%; border-collapse:collapse; margin-bottom:15px;'>
                    <tr style='background:#e0f7fa;'><th>Bett</th><th>Bettingsida</th><th>Procent av insats</th><th>Belopp (kr)</th><th>Procentuell vinst</th></tr>
                    <tr>
                        <td><b>1. {game.HomeOdds}</b></td>
                        <td>{game.HomeOddsCompany}</td>
                        <td>{game.procentHomeTeam}%</td>
                        <td>{Math.Round(((game.procentHomeTeam / 100) * deposit), 2)}</td>
                        <td><b>{Math.Round((((game.procentHomeTeam / 100) * game.HomeOdds) - 1) * 100, 2)}%</b></td>
                    </tr>
                    <tr>
                        <td><b>X. {game.DrawOdds}</b></td>
                        <td>{game.DrawOddsCompany}</td>
                        <td>{game.procentDraw}%</td>
                        <td>{Math.Round(((game.procentDraw / 100) * deposit), 2)}</td>
                        <td><b>{Math.Round((((game.procentDraw / 100) * game.DrawOdds) - 1) * 100, 2)}%</b></td>
                    </tr>
                    <tr>
                        <td><b>2. {game.AwayOdds}</b></td>
                        <td>{game.AwayOddsCompany}</td>
                        <td>{game.procentAwayTeam}%</td>
                        <td>{Math.Round(((game.procentAwayTeam / 100) * deposit), 2)}</td>
                        <td><b>{Math.Round((((game.procentAwayTeam / 100) * game.AwayOdds) - 1) * 100, 2)}%</b></td>
                    </tr>
                </table>
            </div>";
			}

			content += endContent;
			return content;
		}


		public string SendResultMail(string content, string subject)
		{

			try
			{
				var mailAddresses = _config.GetSection("EmailList").Get<List<string>>();

				MailMessage mail = new MailMessage();

				foreach (var toMail in mailAddresses)
				{
					mail.To.Add(toMail);
				}
				mail.From = new MailAddress("apirequestlogger@gmail.com");
				mail.Subject = subject;
				mail.Body = content;
				mail.IsBodyHtml = true;
				SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
				smtp.EnableSsl = true;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new System.Net.NetworkCredential("apirequestlogger@gmail.com", "aeoa jjox kvce qxnd");
				smtp.Send(mail);

				return "success";
			}
			catch (Exception ex)
			{
				return $"failed, errormsg: {ex}";
			}
		}

	}
}
