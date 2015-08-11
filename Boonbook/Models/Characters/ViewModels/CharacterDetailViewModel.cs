using System;
using Boonbook.Models.Users.ViewModels;

namespace Boonbook.Models.Characters.ViewModels
{
    public class CharacterDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PlayerSummaryViewModel Player { get; set; }

        public string Clan { get; set; }
        public string Sect { get; set; }
        public string SocialClass { get; set; }

        public string StartDate { get; set; }
        public string RetireDate { get; set; }

        public bool Active => String.IsNullOrEmpty(StartDate);
    }
}