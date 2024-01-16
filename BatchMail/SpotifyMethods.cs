using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchMail
{
    internal class SpotifyMethods
    {
        public async Task<string> getToken()
        {
            //one time token generation
            bool needToken = true; //not automated yet
            string accessToken = "";
            if (needToken)
            {
                string clientId = "1e3dcf37deb84f8e90326b1dbecc384d";
                string clientSecret = "ad52b0c63f234a1583a47c93d7684e3c";
                string redirectUri = "http://localhost:3000/callback";
                string spotifyAuthorizeUrl = "https://accounts.spotify.com/authorize";
                string scopes = "playlist-modify-public";
                //add scopes
                spotifyAuthorizeUrl = $"{spotifyAuthorizeUrl}" +
        $"?client_id={clientId}" +
        "&response_type=code" +
        $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
        $"&scope={Uri.EscapeDataString(scopes)}";

                string spotifyTokenUrl = "https://accounts.spotify.com/api/token";

                //get authCode
                string authorizationCode = GenericMethods.GetAuthorizationCode(clientId, redirectUri, spotifyAuthorizeUrl);
                authorizationCode = authorizationCode.Replace("\r", "").Replace("\n", "");

                //get token with authCode (token is valid for 1 hour)
                accessToken = await GenericMethods.GetAccessToken(clientId, clientSecret, authorizationCode, redirectUri, spotifyTokenUrl);
                Console.WriteLine("Access Token: " + accessToken);
            }
            else
            {
                //in case token is still valid
                accessToken = "AQA1n-p9j0sOq8RmkXIoSIa9ydsdV11j7YM8mGYoUE-DdG1YC-G4xBjWNM8btzG9701dcLHIeSgPR3Qn_6Dsivdu5unrpKs0kzj7KG5A3Z5eLZ9vhWdSmptsKEDZDivb69O9v0b0Vxb-E45EabiB7xDKeB3Fq_DMrkB2_FF0yZv0QLL2Xlp0bnverN1SrdPtqfKI4FC1asM0YStJJocREftSgQNgWw";
            }
            accessToken = accessToken.Replace("\r", "").Replace("\n", "");
            return accessToken;
        }

        public async Task<string> getArtistData (string artistId, string accessToken)
        {
            string res = "";
            //endpoint for artist data
            string artistEndpoint = $"https://api.spotify.com/v1/artists/{artistId}";
            //API request
            string artistData = await GenericMethods.MakeApiRequest(accessToken, artistEndpoint);
            //Console.WriteLine("Artist Data:");
            Console.WriteLine(artistData);
            return res;
        }

        //allows to search with a keyword and retrieve the results as a list
        public async Task<List<string>> searchMusic(string keyword, string accessToken)
        {
            //endpoint for search
            string searchEndpoint = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(keyword)}&type=track";
            string searchResult = await GenericMethods.MakeApiRequest(accessToken, searchEndpoint);
            //parse the result into a list of trackIds
            try
            {
                dynamic resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject(searchResult);
                dynamic tracksArray = resultObject.tracks.items;
                List<string> trackIds = new List<string>();

                foreach (var track in tracksArray)
                {
                    string trackId = track.id;
                    Console.WriteLine($"{trackId}");
                    trackIds.Add(trackId);
                }
                return trackIds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"parsing error: {ex.Message}");
                return null;
            }
        }

        //create a playlist with specified name
        //doesn't work with current token authorisations
        public async Task<string> CreatePlaylist(string playlistName, string accessToken)
        {
            //endpoint for playlists
            string createPlaylistEndpoint = $"https://api.spotify.com/v1/me/playlists";

            //playlist instruction
            string payload = $"{{\"name\":\"{playlistName}\", \"public\":false}}";
            string playlistResult = await GenericMethods.MakeApiRequestPayload(accessToken, createPlaylistEndpoint, HttpMethod.Post, payload);

            //extract playlist ID
            try
            {
                dynamic resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject(playlistResult);
                // Extract the playlist ID from the response
                return resultObject.id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"parsing error: {ex.Message}");
                return null;
            }
        }
    }
}
