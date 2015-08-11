using System;
using Boonbook.Models.Users;

namespace Boonbook.Models.Characters
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Player Player { get; set; }

        public Clan Clan { get; set; }
        public Sect Sect { get; set; }
        public SocialClass SocialClass { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? RetireDate { get; set; }
    }

    
}