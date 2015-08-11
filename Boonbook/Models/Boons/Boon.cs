using System;
using Boonbook.Models.Characters;

namespace Boonbook.Models.Boons
{
    public class Boon
    {
        public int Id { get; set; }

        public Character Creditor { get; set; }
        public Character Debtor { get; set; }
        public Character Registrar { get; set; }
        
        public BoonLevel Level { get; set; }
        public string Stipulations { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        public string RegistrationCause { get; set; }
        
        public DateTime? ExpenditureDate { get; set; }
        public string ExpenditureCause { get; set; }
    }

}