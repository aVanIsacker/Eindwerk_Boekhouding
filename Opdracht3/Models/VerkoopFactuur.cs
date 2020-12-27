using Opdracht3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class VerkoopFactuur : Factuur
    {
        public string Type { get; set; }

        public VerkoopFactuur()
        {
            UniekNr = Constants.VerkoopFactuurNummer;
        }
    }
}
