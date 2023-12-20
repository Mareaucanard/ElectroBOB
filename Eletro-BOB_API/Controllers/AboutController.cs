using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;

namespace Eletro_BOB_API.Controllers
{

    [Route("/about.json")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        class Client
        {
            public string host { get; set; }
        }

        class Actions
        {
            public string name { get; set; }
            public string description { get; set; }
        }
        class Reactions
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        class Services
        {
            public string name { get; set; }
            public Actions[] actions { get; set; }
            public Reactions[] reactions { get; set; }
        }

        class Server
        {
            public int current_time { get; set; }
            public Services[] services { get; set; }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Client client = new Client();
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    client.host = endPoint.Address.ToString();
                }
                Server server = new Server();
                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                server.current_time = (int)t.TotalSeconds;
                Actions action = new Actions();
                action.name = "Timer";
                action .description = "Timer for triggering action every n minutes";
                Reactions reaction = new Reactions();
                reaction.name = "Send Email";
                reaction.description = "Send an email to a specific address";
                Services service = new Services();
                service.name = "Basics";
                service.actions = new Actions[1];
                service.actions.Append(action);
                service.reactions = new Reactions[1];
                service.reactions.Append(reaction);
                server.services = new Services[1];
                server.services.Append(service);
                string json = JsonSerializer.Serialize(client);
                json += JsonSerializer.Serialize(server);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest("Error when getting preferences");
            }
        }
    }
}
