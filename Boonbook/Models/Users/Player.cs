﻿using System.Collections.Generic;

namespace Boonbook.Models.Users
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string MesNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public List<Role> Roles { get; set; }

    }

}