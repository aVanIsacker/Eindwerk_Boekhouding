using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class Factuur : ObservableObject
    {
        public Factuur()
        {
            FactuurDatum = DateTime.Now;
        }
        public int UniekNr { get; set; }

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
        public string Maand
        {
            get
            {
                return _factuurDatum.ToString("MMM");
            }
            set
            { }
        }

        private double _bedragExclBtw;
        public double BedragExclBTW
        {
            get
            {
                return _bedragExclBtw;
            }
            set
            {
                OnPropertyChanged(ref _bedragExclBtw, value);
                OnPropertyChanged(nameof(BedragInclBTW));
            }
        }

        private int _btwTarief;
        public int BTWTarief
        {
            get
            {
                return _btwTarief;
            }
            set
            {
                OnPropertyChanged(ref _btwTarief, value);
                OnPropertyChanged(nameof(BedragInclBTW));
            }
        }

        public string Status { get; set; }
        public double BedragInclBTW { get { return BedragExclBTW + BTWBedrag; } }
        public string Omschrijving { get; set; }


        public DateTime BetaalDatum { get; set; }


        public double BTWBedrag { get { return Utils.RoundUp(BedragExclBTW * BTWTarief / 100.0, 2); } }

        public DateTime VervalDatum { get; }
        //public DateTime VervalDatum { get { return _factuurDatum.AddMonths(1); } }
        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; } 
            set { OnPropertyChanged(ref _contact, value); }
            
        }


    }
}
