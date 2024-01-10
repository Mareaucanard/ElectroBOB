using Eletro_BOB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace BatchMail
{
    public class GenericMethods
    {
        public void sendMail(ReactionTrigger reaction)
        {
            var email = new MailMessage(reaction.From, reaction.To, "Eletro-BOB à quelque chose à te dire...", reaction.Message);
            using (var smtpClient = new SmtpClient { Host = "localhost", Port = 25 })
            {
                smtpClient.Send(email);
            }
        }

        public static async Task<string> MakeApiRequest(string accessToken, string endPoint)
        {
            using (HttpClient client = new HttpClient())
            {
                //set up headers
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                //get request
                HttpResponseMessage response = await client.GetAsync(endPoint);

                //check success of request
                if (response.IsSuccessStatusCode)
                {
                    //read and return the response content
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<string> GetAccessToken(string clientId, string clientSecret, string authorizationCode, string redirectUri, string tokenUrl)
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

        public static string GetAuthorizationCode(string clientId, string redirectUri, string authorizeUrl)
        {
            // Redirect the user to the Spotify authorization page
            string authorizeUri = $"{authorizeUrl}?client_id={clientId}&response_type=code&redirect_uri={HttpUtility.UrlEncode(redirectUri)}&scope=user-read-private%20user-read-email";

            Console.WriteLine("Please visit this URL to authorize the application:");
            Console.WriteLine(authorizeUri);

            Console.Write("Enter the authorization code: ");
            return Console.ReadLine();
        }

        public static async Task<string> MakeApiRequestPayload(string accessToken, string endpoint, HttpMethod method, string payload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //set up headers
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    HttpRequestMessage request = new HttpRequestMessage(method, endpoint);

                    //Include payload in request if method is post or put
                    if (method == HttpMethod.Put || method == HttpMethod.Post)
                    {
                        request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
                    }
                    //get request
                    HttpResponseMessage response = await client.SendAsync(request);

                    //check success
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other errors, e.g., network issues
                Console.WriteLine($"error making API request: {ex.Message}");
                return null;
            }
        }
    }
}
