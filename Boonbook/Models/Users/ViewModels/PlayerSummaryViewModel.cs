using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boonbook.Models.Users.ViewModels
{
    public class PlayerSummaryViewModel
    {
        public string MesNumber { get; set; }
        public string Name { get; set; }

        public string Url => "api/players/" + MesNumber;
    }
}