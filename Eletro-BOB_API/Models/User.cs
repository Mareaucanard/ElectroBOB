﻿namespace Eletro_BOB_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PreferenceId { get; set; }
    }
}
