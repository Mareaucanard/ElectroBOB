# Batchmail
BatchMail est la partie qui gère les appels d'API externes et les déclenchements de réactions.

## GenericMethods
Ce fichier contient des méthodes basiques et utiles à différentes APIs.
### void sendMail(ReactionTrigger reaction)
Cette méthode permet d'envoyer un mail avec les informations fournies dans le paramètre reaction.
### static string GetAuthorizationCode(string clientId, string redirectUri, string authorizeUrl)
Comme son nom l'indique, cette méthode permet de demander un code d'autorisation lors d'une authentification.

Cette méthode est uniquement pour la connectivité sans front end. 
### static async Task<string> GetAccessToken(string clientId, string clientSecret, string authorizationCode, string redirectUri, string tokenUrl)
Cette méthode permet de récupérer un token d'accès à l'api après avoir reçu un code d'authorisation.
Cette méthode est uniquement pour la connectivité sans front end et requiert une action côté terminal.
### static async Task<string> MakeApiRequest(string accessToken, string endPoint)
Envoie une requête API au endpoint donné.
### static async Task<string> MakeApiRequestPayload(string accessToken, string endpoint, HttpMethod method, string payload)
Envoie une requête API au endpoint donné, accompagné d'un payload.

## GenericTriggers
Ce fichier contient des moyens de déclencher des réactions.
### bool minThreshold(float threshold, float value)
Se déclenche si une valeur dépasse un minimum.
### bool maxThreshold(float threshold, float value)
Se déclenche si une valeur dépasse un maximum.
### public bool postFromUser(string user, string targetUser)
Se déclenche si un certain utilisateur envoie une publication.

## SpotifyMethods
Ce fichier contient des méthodes spécifiques à l'API Spotify.
### async Task<string> getToken()
Suite d'appels pour une authentification avec Token plus rapide.

Cette méthode est uniquement pour la connectivité sans front end. 
### async Task<string> getArtistData (string artistId, string accessToken)
Récupère les informations d'un artiste disponibles sur Spotify.
### async Task<List<string>> searchMusic(string keyword, string accessToken)
Effectue une recherche parmis les musiques disponibles sur Spotify avec les mots clés donnés.
### async Task<string> CreatePlaylist(string playlistName, string accessToken)
Crée une playlist nommée avec le nom donné en paramètre.
(Pas acceptée par l'API Spotify actuellement)