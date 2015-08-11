using System;
using Boonbook.Models.Users.ViewModels;

namespace Boonbook.Models.Characters.ViewModels
{
    public class CharacterSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url => "/api/characters/" + Id;
    }
}