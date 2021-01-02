using Opdracht3.Services;
using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Opdracht3.ViewModels
{
    public class VerkoopDagBoekViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<VerkoopFactuur> _verkoopFactuur;
        private VerkoopFactuur _selectedVerkoopFactuur;
        private ObservableCollection<Klant> _klanten;

        public VerkoopDagBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            VerkoopFacturen = new ObservableCollection<VerkoopFactuur>(dataService.GeefVerkoopDagBoek());

            AddVerkoopCommand = new RelayCommand(VoegVerkoopToe);
            EditVerkoopCommand = new RelayCommand(WijzigVerkoop);
            DeleteVerkoopCommand = new RelayCommand(VerwijderVerkoop);
            SelectedVerkoopFactuur = new VerkoopFactuur();
            Klanten = new ObservableCollection<Klant>(_dataService.GeefAlleKlanten());
        }
        
        private void VerwijderVerkoop()
        {
            VerkoopFacturen = new ObservableCollection<VerkoopFactuur>(_dataService.VerwijderVerkoopFactuur(SelectedVerkoopFactuur));
            if (_verkoopFactuur.Count > 0) SelectedVerkoopFactuur = _verkoopFactuur[0];
        }

        private void WijzigVerkoop()
        {
            _dataService.WijzigVerkoopFactuur(SelectedVerkoopFactuur);
        }

        private void VoegVerkoopToe()
        {
            VerkoopFactuur verkoopDagBoek = new VerkoopFactuur() { UniekNr = 0, BetaalDatum = DateTime.Now, BedragExclBTW = 0, BTWTarief = 0, FactuurDatum = DateTime.Now, Type = "NA", Omschrijving = "NA" };
            VerkoopFacturen = new ObservableCollection<VerkoopFactuur>(_dataService.VoegVerkoopFactuurToe(verkoopDagBoek));
            SelectedVerkoopFactuur = _verkoopFactuur[_verkoopFactuur.Count - 1];
        }

        public ICommand AddVerkoopCommand { get; private set; }
        public ICommand EditVerkoopCommand { get; private set; }
        public ICommand DeleteVerkoopCommand { get; private set; }
        public ObservableCollection<Klant> Klanten
        {
            get { return _klanten; }
            set { OnPropertyChanged(ref _klanten, value); }
        }
        public ObservableCollection<VerkoopFactuur> VerkoopFacturen
        {
            get { return _verkoopFactuur; }
            set { OnPropertyChanged(ref _verkoopFactuur, value); }
        }
        public VerkoopFactuur SelectedVerkoopFactuur
        {
            get { return _selectedVerkoopFactuur; }
            set { OnPropertyChanged(ref _selectedVerkoopFactuur, value); }
        }


        //public Func<object, string, bool> KlantenFilter
        //{
        //    get
        //    {
        //        return (item, text) =>
        //        {
        //            var customer = item as Contact;
        //            if (customer == null)
        //                return false;
        //            if (item is Klant klant)
        //            {
        //                return klant.ToString().Contains(text);
        //            }
        //            if (item is Leverancier leverancier)
        //            {
        //                return leverancier.NaamBedrijf.Contains(text);
        //            }
        //            return false;
        //        };
        //    }
        //}
    }
}
