using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.Models
{
    public class OpenstaandeFactuur
    {
        public int Jaar { get; set; }
        public int Maand { get; set; }

        public string FullMaand
        {
            get
            {
                return CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName(Maand).ToUpper();
            }
        }
        
        public double Inkomend { get; set; } //openstaande debiteuren
        public double Uitgaand { get; set; } //openstaande crediteuren
    }
}
