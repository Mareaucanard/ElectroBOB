using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using System.Net.Mail;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;

try
{

    IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

    Console.WriteLine("Initalisation of the batch");
    {
        DbContextOptions<AreaContext> options = new DbContextOptionsBuilder<AreaContext>()
            .UseMySql(configuration.GetConnectionString("AreaDataBase"), ServerVersion.AutoDetect(configuration.GetConnectionString("AreaDataBase"))).Options;
        AreaContext context = new AreaContext(options);
        Console.WriteLine("Context created");
        const string url = "https://api.coinbase.com/v2/prices/BTC-USD/buy";
        while (true)
        {
            Console.WriteLine("In the loop");
            List<ActionTrigger> actionTriggers = context.ActionTriggers.ToList();
            foreach (ActionTrigger action in actionTriggers)
            {
                if (action.NextTrigger < DateTime.Now)
                {
                    action.NextTrigger = DateTime.Now;
                    Console.WriteLine(action.NextTrigger);
                    action.NextTrigger = action.NextTrigger.AddMinutes(action.nbMin);
                    Console.WriteLine(action.NextTrigger);
                    context.Update(action);
                    context.SaveChanges();
                    List<ReactionTrigger> reactions = context.ReactionTriggers.Where(r => r.AreaId == action.AreaId).ToList();
                    foreach (ReactionTrigger reaction in reactions)
                    {
                        var email = new MailMessage(reaction.From, reaction.To, "Eletro-BOB à quelque chose à te dire...", reaction.Message);
                        using (var smtpClient = new SmtpClient { Host = "localhost", Port = 25 })
                        {
                            smtpClient.Send(email);
                        }
                    }
                }
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("").Result;
                Console.WriteLine(response.Content);
            }
            Console.WriteLine("Next trigger");
            Thread.Sleep(5000);
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
