using Opdracht3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{ 
    public class AankoopFactuur : Factuur
    {
        public string Type { get; set; }

        public Leverancier Leverancier
        {
            get { return Contact as Leverancier; }
            set
            {
                Contact = value;
            }
        }

        public AankoopFactuur()
        {
            UniekNr = Constants.VerkoopFactuurNummer;
        }
    }
}
