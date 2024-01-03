using MyBettingApp.Models;
using System.Net.Mail;

namespace MyBettingApp.Service
{
    public class MailService
    {
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
            //string imageLink = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FUEFA_Champions_League&psig=AOvVaw0cLIT23wbFRjpx093D1FPH&ust=1703255188121000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCIj12ZreoIMDFQAAAAAdAAAAABAD";
            string content = startContentBestOdds;
            foreach (var game in games)
            {
                content += $"-----------------------------<br/>" +
                    $"<h3><b>{game.HomeTeam} VS {game.AwayTeam}</b></h3>" +
                    $"<h4><u><b>Topp tre odds för hemmalaget {game.HomeTeam}</b></u></h4>" +
                    $"<p>1. <b>{game.BettingCompanyHomeOdds}</b>, odds: <b>{game.BestHomeTeamOdds}</b></p>" +
                    $"<p>2. <b>{game.BettingCompanyHomeTop2Odds}</b>, odds: <b>{game.Top2HomeTeamOdds}</b></p>" +
                    $"<p>3. <b>{game.BettingCompanyHomeTop3Odds}</b>, odds: <b>{game.Top3HomeTeamOdds}</b></p>" +
                    $"<p>Lägsta oddset: <b>{game.BettingCompanyHomeLowestOdds}</b>, odds: <b>{game.LowestHomeTeamOdds}</b></p>" +
                    $"<h4><u><b>Topp tre odds för bortalaget {game.AwayTeam}</b></u></h4>" +
                    $"<p>1. <b>{game.BettingCompanyAwayOdds}</b>, odds: <b>{game.BestAwayTeamOdds}</b></p>" +
                    $"<p>2. <b>{game.BettingCompanyAwayTop2Odds}</b>, odds: <b>{game.Top2AwayTeamOdds}</b></p>" +
                    $"<p>3. <b>{game.BettingCompanyAwayTop3Odds}</b>, odds: <b>{game.Top3AwayTeamOdds}</b></p>" +
                    $"<p>Lägsta oddset: <b>{game.BettingCompanyAwayLowestOdds}</b>, odds: <b>{game.LowestAwayTeamOdds}</b></p>" +
                    $"<h4><u><b>Topp tre odds för lika</b></u></h4>" +
                    $"<p>1. <b>{game.BettingCompanyDrawOdds}</b>, odds: <b>{game.BestDrawOdds}</b></p>"+
                    $"<p>2. <b>{game.BettingCompanyDrawTop2Odds}</b>, odds: <b>{game.Top2DrawOdds}</b></p>" +
                    $"<p>3. <b>{game.BettingCompanyDrawTop3Odds}</b>, odds: <b>{game.Top3DrawOdds}</b></p>"+
                    $"<p>Lägsta oddset: <b>{game.BettingCompanyDrawLowestOdds}</b>, odds: <b>{game.LowestDrawOdds}</b></p>";
            }

            content += endContent;

            return content;
        }

        public string CreateContentForAlwaysProfit(List<OddsModel> winningOdds, double deposit)
        {
            string content = startContentAlwaysProfit;
            content += $"Total insats: {deposit} kronor<br/>";
            foreach (var game in winningOdds)
            {
                if (game.AwayTeam == null)
                {
                    continue;
                }
                content += $"-----------------------------<br/>" +
                    $"<b>{game.HomeTeam} VS {game.AwayTeam}</b>" +
                    $"<p><b>1. {game.HomeOdds}</b>. Bettingsida: <b>{game.HomeOddsCompany}</b> - Lägg <b>{game.procentHomeTeam}%</b> av din totala insats på detta bett.<br/>" +
                    $"{Math.Round(((game.procentHomeTeam / 100) * deposit), 2)} kronor<br/>" +
                    $"Procentuell vinst {Math.Round((((game.procentHomeTeam / 100) * game.HomeOdds) -1),4)}%.</p>" +
                    $"<p><b>X. {game.DrawOdds}</b>. Bettingsida: <b>{game.DrawOddsCompany}</b> - Lägg <b>{game.procentDraw}%</b> av din totala insats på detta bett.<br/>" +
                    $"{Math.Round(((game.procentDraw / 100) * deposit),2)} kronor<br/>" +
                    $"Procentuell vinst {Math.Round((((game.procentDraw / 100) * game.DrawOdds) - 1),4)}%.</p>" +
                    $"<p><b>2. {game.AwayOdds}</b>. Bettingsida: <b>{game.AwayOddsCompany}</b> - Lägg <b>{game.procentAwayTeam}%</b> av din totala insats på detta bett.<br/>"+
                    $"{Math.Round(((game.procentAwayTeam / 100) * deposit), 2)} kronor<br/>"+
                    $"Procentuell vinst {Math.Round((((game.procentAwayTeam / 100) * game.AwayOdds) - 1),4)}%.</p>";
            }

            content += endContent;

            return content;
        }

        public string SendResultMail(string content, List<string> mailadresses, string subject)
        {

            try
            {
                MailMessage mail = new MailMessage();
                
                foreach (var toMail in mailadresses)
                {
                    mail.To.Add(toMail);
                }
                //mail.To.Add("john.renstrom13@gmail.com");
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
