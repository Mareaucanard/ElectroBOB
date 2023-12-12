namespace Eletro_BOB_API.Models
{
    public class Preference
    {
        public Preference(int id, bool notif, bool email, bool sms)
        {
            Id = id;
            ActiveNotifications = notif;
            ActiveEmail = email;
            ActiveSMS = sms;
        }

        public int Id { get; set; }

        public bool ActiveNotifications { get; set; }
        public bool ActiveEmail { get; set; }
        public bool ActiveSMS { get; set; }
    }
}
