using System;
using Boonbook.Models.Characters;
using Boonbook.Models.Characters.ViewModels;

namespace Boonbook.Models.Boons.ViewModels
{
    public class BoonDetailViewModel
    {
        public int Id { get; set; }

        public CharacterSummaryViewModel Creditor { get; set; }
        public CharacterSummaryViewModel Debtor { get; set; }
        public CharacterSummaryViewModel Registrar { get; set; }

        public string Level { get; set; }
        public string Stipulations { get; set; }

        public string RegistrationDate { get; set; }
        public string RegistrationCause { get; set; }

        public string ExpenditureDate { get; set; }
        public string ExpenditureCause { get; set; }

        public bool Active => String.IsNullOrEmpty(ExpenditureDate);
    }
}