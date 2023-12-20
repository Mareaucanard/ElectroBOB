using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using System.Net.Mail;
using System.Net;

Console.WriteLine("Initalisation of the batch");
{
    DbContextOptions<AreaContext> options = new DbContextOptionsBuilder<AreaContext>()
        .UseSqlServer("Server=10.15.190.28,1433; Database=AreaDB; User Id=SA; Password=Bob1234Bob1234; TrustServerCertificate=True; Persist Security Info=True; Encrypt=False; MultiSubnetFailover=True;")
        .Options;
    AreaContext context = new AreaContext(options);
    Console.WriteLine("Context created");
    while (true)
    {
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
        }
        Console.WriteLine("Next trigger");
        Thread.Sleep(5000);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
