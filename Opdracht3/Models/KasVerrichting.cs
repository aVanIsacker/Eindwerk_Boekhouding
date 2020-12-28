using Opdracht3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class KasVerrichting : Factuur
    {
        public KasVerrichting()
        {
            UniekNr = Constants.KasverichtingNummer;
        }
        public string Betaalwijze { get; set; }
        public string Type { get; set; }
    }
}
