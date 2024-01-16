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
using System.Text.Json;
using BatchMail;
using System.Web;

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
        GenericMethods genericMethods = new GenericMethods();
        GenericTriggers genericTriggers = new GenericTriggers();
        SpotifyMethods spotifyMethods = new SpotifyMethods();


        //API test requests with token

        string spotifyToken = await spotifyMethods.getToken();
        string printe = $"Successfully retrieved Token: {spotifyToken}";
        Console.WriteLine(printe);
        Console.WriteLine("Testing spotify call");
        string testId = "0lzVrkjlIZJH18hk2Gcjkp"; //id of Kenji Kawai
        List<string> list = await spotifyMethods.searchMusic("Grève", spotifyToken);
        //string playlistId = await spotifyMethods.CreatePlaylist("playGreve", spotifyToken);
        Console.WriteLine("Testing spotify end");

        //action-reaction loop
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
                        genericMethods.sendMail(reaction);
                    }
                }

                //faire nouveau modèle par ex "actionTriggerBitCoin"
                //lui mettre plein de trigger
                //ajouter nbMin et nextTrigger (voir dans actionTrigger et comment c'est calculé)
                //faire migration
                //faire des foreach pareils pour des API potentielles
                //ex: tous les nbTime check si y'a les trigger de bitcoin et si oui trigger une reaction (voir comment le faire de manière universelle)
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("").Result;
                Console.WriteLine(response.Content);
            }

            //bitcoin API
            const string url = "https://api.coinbase.com/v2/prices/BTC-USD/buy";
            List<ActionTrigger> actionTriggersBitcoin = context.ActionTriggers.ToList();
            foreach (ActionTrigger action in actionTriggersBitcoin)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync("").Result;

                    //parse response
                    var jsonData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonData);
                    JsonDocument jsonDoc = JsonDocument.Parse(jsonData);

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
                            //reactions
                        }
                    }
                }
            }

            //Spotify API
            List<ActionTrigger> actionTriggersSpotify = context.ActionTriggers.ToList();

            foreach (ActionTrigger action in actionTriggersSpotify)
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
                        //reactions
                    }
                }

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync("").Result;
                Console.WriteLine(response.Content);
            }

            //SNCF API
            List<ActionTrigger> actionTriggersSNCF = context.ActionTriggers.ToList();
            foreach (ActionTrigger action in actionTriggersSNCF)
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
                        //reactions
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


