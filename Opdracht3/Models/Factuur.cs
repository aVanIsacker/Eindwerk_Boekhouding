using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class Factuur:ObservableObject
    {
        public string UniekNr { get; set; }
        private DateTime _factuurDatum;
        public DateTime FactuurDatum
        {
            get
            {
                return _factuurDatum;
            }
            set
            {
                OnPropertyChanged(ref _factuurDatum, value);

            }
        }
        public string Maand { get; set; }
        public double BedragExclBTW { get; set; }
        public int BTWTarief { get; set; }
        public string Status { get; set; }
        public double BedragInclBTW { get { return BedragExclBTW + BTWBedrag; } }
        public string Omschrijving { get; set; }
        public DateTime BetaalDatum { get; set; }
        public double BTWBedrag { get { return BedragExclBTW * BTWTarief / 100.0; }  }

        public DateTime VervalDatum { get; }
        //public DateTime VervalDatum { get { return _factuurDatum.AddMonths(1); } }

        public Contact Contact { get; set; }


    }
}
