using System;
using Boonbook.Models.Characters.ViewModels;

namespace Boonbook.Models.Boons.ViewModels
{
    public class BoonSummaryViewModel
    {
        public int Id { get; set; }
        
        public CharacterSummaryViewModel Creditor { get; set; }
        public CharacterSummaryViewModel Debtor { get; set; }

        public string Level { get; set; }

        public string Url => "/api/boons/" + Id;
    }
}