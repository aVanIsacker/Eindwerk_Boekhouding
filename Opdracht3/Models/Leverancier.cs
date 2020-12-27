using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class Leverancier : Contact
    {
        
        public string NaamBedrijf { get; set; }
        public override string GetName()
        {
            return $"{NaamBedrijf}";
        }
    }
}
