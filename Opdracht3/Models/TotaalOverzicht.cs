using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class TotaalOverzicht
    {
        public List<AankoopFactuur> AankoopDagBoek;
        public List<VerkoopFactuur> VerkoopDagBoek;
        public List<KasVerrichting> KasBoek;

        public int Maand { get; internal set; }

        //public double TeBetalenBTW6 { get; }
        //public double TeBetalenBTW21 { get; }
        //public double TeOntvangenBTW6 { get; }
        //public double TeOntvangenBTW21 { get; }

        public double TeBetalenBTW { get; set; }
        public double TeOntvangenBTW { get; set; }
        public double BTWSaldo { get { return TeBetalenBTW - TeOntvangenBTW; } }
        public double OpenstaandeDebiteuren { get; internal set; }
        public double OpenstaandeCrediteuren { get; internal set; }
        public double Omzet { get; internal set; }
        public double BedrijfsKosten { get; internal set; }
        public double Totaal { get { return Omzet - BedrijfsKosten;  } }
        public double ResultaatVoorAfschrijvingEnBelastingen { get; }
        public string Jaar { get; set; }
    }

}
