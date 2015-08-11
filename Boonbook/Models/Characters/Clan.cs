using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boonbook.Models.Characters
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool PillarClan { get; set; }
    }

    
}