﻿using System.Collections.Generic;

namespace Projekt_s16696.Models
{
    public class Client
    {
        public int IdClient { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }

        public string clientToken { get; set; }

        public string Password { get; set; }

    }
}