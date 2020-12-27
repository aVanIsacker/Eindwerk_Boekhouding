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
            ClearKasVerichtingCommand = new RelayCommand(ClearKasVerrichting);
            AddKasVerrichtingCommand = new RelayCommand(VoegKasVerrichtingToe);
            EditKasVerrichtingCommand = new RelayCommand(WijzigKasVerrichting);
            DeleteKasVerrichtingCommand = new RelayCommand(VerwijderKasVerrichting);
            SelectedKasVerrichting = new KasVerrichting();
        }

        private void ClearKasVerrichting()
        {
            SelectedKasVerrichting = new KasVerrichting();
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
            KasBoek = new ObservableCollection<KasVerrichting>(_dataService.VoegKasVerrichtingToe(SelectedKasVerrichting));
            SelectedKasVerrichting = new KasVerrichting();
        }

        public ICommand AddKasVerrichtingCommand { get; private set; }
        public ICommand EditKasVerrichtingCommand { get; private set; }
        public ICommand DeleteKasVerrichtingCommand { get; private set; }
        public ICommand ClearKasVerichtingCommand { get; private set; }

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
