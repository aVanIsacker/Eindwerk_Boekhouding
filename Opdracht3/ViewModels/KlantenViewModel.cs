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
    public class KlantenViewModel : ObservableObject
    {


        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Klant> _klanten;
        private Klant _selectedKlant;
        private int _id;

        public int Id { get { return _id; } set { OnPropertyChanged(ref _id, value); } }

        public KlantenViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            Klanten = new ObservableCollection<Klant>(_dataService.GeefAlleKlanten());

            AddKlantCommand = new RelayCommand(VoegKlantToe);
            EditKlantCommand = new RelayCommand(WijzigKlant);
            DeleteKlantCommand = new RelayCommand(VerwijderKlant);
          
        }

        private void VerwijderKlant()
        {
            Klanten = new ObservableCollection<Klant>(_dataService.VerwijderKlant(SelectedKlant));
            if (_klanten.Count > 0) SelectedKlant = _klanten[0];
        }

        private void WijzigKlant()
        {
            _dataService.WijzigKlant(SelectedKlant);
        }

        private void VoegKlantToe()
        {
            Klant klant = new Klant() { ContactNr = 0, Familienaam = "NA", Straat = "NA", Postcode = 0, Gemeente = "NA" };
            Klanten = new ObservableCollection<Klant>(_dataService.VoegKlantToe(klant));
            SelectedKlant = _klanten[_klanten.Count - 1];
        }

        public ICommand AddKlantCommand { get; private set; }
        public ICommand EditKlantCommand { get; private set; }
        public ICommand DeleteKlantCommand { get; private set; }

        public ObservableCollection<Klant> Klanten
        {
            get { return _klanten; }
            set { OnPropertyChanged(ref _klanten, value); }
        }
        public Klant SelectedKlant
        {
            get { return _selectedKlant; }
            set { OnPropertyChanged(ref _selectedKlant, value); }
        }

    }
}
