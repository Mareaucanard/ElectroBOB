using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using System.Net.Mail;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using System.Text.Json;
using BatchMail;
using System.Web;

try
{
    Console.WriteLine("Initalisation of the batch");
    {
        DbContextOptions<AreaContext> options = new DbContextOptionsBuilder<AreaContext>()
            .UseSqlServer("Server=192.168.144.1,1433; Database=Area; User Id=Bob; Password=Bob123; TrustServerCertificate=False; Persist Security Info=True; Encrypt=False; MultiSubnetFailover=True;")
            .Options;
        AreaContext context = new AreaContext(options);
        Console.WriteLine("Context created");
        GenericMethods genericMethods = new GenericMethods();
        GenericTriggers genericTriggers = new GenericTriggers();

        //one time token generation
        bool needToken = false;
        string test_token = "BQANVCPBYSvFuA2CCK23RLkXC2iCGmAVWb2hp5NBZWUB87JxtmHjtncvJiMdgxraNF3g8xit8KNJ2_CLb5H4gnH0vUfgEJRlehsmnKStuv9LBN49Ajk6S06xcGj0pbONC_FUh17hJvup9K_ejc2ByMOW2-nSiyFgDgh3odRkvebtODxSIsQjmIByGA3hEG5vJ9lMR8jZCruGRDsppvLFLQ";
        if (needToken)
        {
            // Replace with your Spotify application's client ID and client secret
            string clientId = "1e3dcf37deb84f8e90326b1dbecc384d";
            string clientSecret = "ad52b0c63f234a1583a47c93d7684e3c";
            string redirectUri = "http://localhost:3000/callback";
            string spotifyAuthorizeUrl = "https://accounts.spotify.com/authorize";
            string spotifyTokenUrl = "https://accounts.spotify.com/api/token";

            // Step 1: Obtain Authorization Code
            string authorizationCode = ""; 
            if (true)
            {
                authorizationCode = GetAuthorizationCode(clientId, redirectUri, spotifyAuthorizeUrl);
            }
            else
            {
                authorizationCode = "AQATu1iWGi7HTIm40kewsZGORcmH4XD-UlVa4rLaS5_06aKMHfJhc8K6jJczDHJO3G5lzyQx39qCj9zz8hFVOiztmOYxKkT3AaKPYn78R8J6_wDk2RhJl62Fh3B26yAxeTbyZTiH2DzDL8fO5Bg6bFuABEtws8oBzq1eqCYbgusaqMCEaH0Idp5jRKWcylVNkgseOMszC00OtHE_RwmtX-g7PMONCg";
            }
            authorizationCode = authorizationCode.Replace("\r", "").Replace("\n", "");
            // Spotify token endpoint
            string tokenUrl = "https://accounts.spotify.com/api/token";
            // Step 2: Exchange Authorization Code for Access Token
            string accessToken = await GetAccessToken(clientId, clientSecret, authorizationCode, redirectUri, tokenUrl);

            // Now you have the access token and can make requests to the Spotify API
            Console.WriteLine("Access Token: " + accessToken);

            // Make Spotify API requests using the access token...
            test_token = "";
        }

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

static string GetAuthorizationCode(string clientId, string redirectUri, string authorizeUrl)
{
    // Redirect the user to the Spotify authorization page
    string authorizeUri = $"{authorizeUrl}?client_id={clientId}&response_type=code&redirect_uri={HttpUtility.UrlEncode(redirectUri)}&scope=user-read-private%20user-read-email";

    Console.WriteLine("Please visit this URL to authorize the application:");
    Console.WriteLine(authorizeUri);

    Console.Write("Enter the authorization code: ");
    return Console.ReadLine();
}
static async Task<string> GetAccessToken(string clientId, string clientSecret, string authorizationCode, string redirectUri, string tokenUrl)
{
    using (HttpClient client = new HttpClient())
    {
        // Prepare the request parameters
        var content = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
            });

        // Make the request to exchange authorization code for access token
        HttpResponseMessage response = await client.PostAsync(tokenUrl, content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            // Parse the JSON response and extract the access token
            // Note: Consider using a JSON parsing library or framework for production code
            return responseBody.Split('"')[3];
        }
        else
        {
            throw new Exception($"Failed to obtain access token. Status code: {response.StatusCode}");
        }
    }
}

static async Task<string> GetOccessToken(string clientId, string clientSecret, string authorizationCode, string redirectUri, string tokenUrl)
{
    using (HttpClient client = new HttpClient())
    {
        // Prepare the request parameters
        var content = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
            });

        // Make the request to exchange authorization code for access token
        HttpResponseMessage response = await client.PostAsync(tokenUrl, content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            // Parse the JSON response and extract the access token
            // Note: Consider using a JSON parsing library or framework for production code
            return responseBody.Split('"')[3];
        }
        else
        {
            throw new Exception($"Failed to obtain access token. Status code: {response.StatusCode}");
        }
    }
}