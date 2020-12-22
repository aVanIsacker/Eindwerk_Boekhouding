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
    public class KasBoekViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private ObservableCollection<KasVerrichting> _kasBoek;
        private KasVerrichting _selectedKasVerrichting;
        public KasBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            _kasBoek = new ObservableCollection<KasVerrichting>(dataService.GeefKasBoek());

            AddKasVerrichtingCommand = new RelayCommand(VoegKasVerrichtingToe);
            EditKasVerrichtingCommand = new RelayCommand(WijzigKasVerrichting);
            DeleteKasVerrichtingCommand = new RelayCommand(VerwijderKasVerrichting);


        }

        private void VerwijderKasVerrichting()
        {
            KasBoek = new ObservableCollection<KasVerrichting>(_dataService.VerwijderKasVerrichting(SelectedKasVerrichting));
            if (_kasBoek.Count > 0) SelectedKasVerrichting = _kasBoek[0];
        }

        private void WijzigKasVerrichting()
        {
            _dataService.WijzigKasBoek(SelectedKasVerrichting);
        }

        private void VoegKasVerrichtingToe()
        {
            KasVerrichting kasBoek = new KasVerrichting(); //{ UniekNr = "NA", FactuurDatum = new DateTime(2020, 1, 13), Type = "Bedrijfskosten", Omschrijving = "NA", BedragExclBTW = 60.0, BTWTarief = 21 };
            KasBoek = new ObservableCollection<KasVerrichting>(_dataService.VoegKasVerrichtingToe(kasBoek));
            SelectedKasVerrichting = _kasBoek[_kasBoek.Count - 1];
        }

        public ICommand AddKasVerrichtingCommand { get; private set; }
        public ICommand EditKasVerrichtingCommand { get; private set; }
        public ICommand DeleteKasVerrichtingCommand { get; private set; }


        public ObservableCollection<KasVerrichting> KasBoek
        {
            get { return _kasBoek; }
            set { OnPropertyChanged(ref _kasBoek, value); }
        }
        public KasVerrichting SelectedKasVerrichting
        {
            get { return _selectedKasVerrichting; }
            set { OnPropertyChanged(ref _selectedKasVerrichting, value); }
        }
    }
}
