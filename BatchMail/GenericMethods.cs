using Eletro_BOB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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
    }
}
