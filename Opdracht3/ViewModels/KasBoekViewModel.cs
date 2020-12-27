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

        private ObservableCollection<Contact> _klanten;
        public KasBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            _kasBoek = new ObservableCollection<KasVerrichting>(dataService.GeefKasBoek());
            ClearKasVerichtingCommand = new RelayCommand(ClearKasVerrichting);
            AddKasVerrichtingCommand = new RelayCommand(VoegKasVerrichtingToe);
            EditKasVerrichtingCommand = new RelayCommand(WijzigKasVerrichting);
            DeleteKasVerrichtingCommand = new RelayCommand(VerwijderKasVerrichting);
            Klanten = new ObservableCollection<Contact>(dataService.GeefAlleKlanten());

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
            if(SelectedKasVerrichting.Contact == null)
            {
                return;
            }

            KasBoek = new ObservableCollection<KasVerrichting>(_dataService.VoegKasVerrichtingToe(SelectedKasVerrichting));
            SelectedKasVerrichting = new KasVerrichting();
        }

        public ICommand AddKasVerrichtingCommand { get; private set; }
        public ICommand EditKasVerrichtingCommand { get; private set; }
        public ICommand DeleteKasVerrichtingCommand { get; private set; }
        public ICommand ClearKasVerichtingCommand { get; private set; }

        public ObservableCollection<Contact> Klanten
        {
            get { return _klanten; }
            set { OnPropertyChanged(ref _klanten, value); }
        }

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


        public Func<object, string, bool> KlantenFilter
        {
            get
            {
                return (item, text) =>
                {
                    var customer = item as Contact;
                    if (customer == null)
                        return false;
                    if(item is Klant)
                    {
                        return ((Klant)item).ToString().Contains(text);
                    }
                    return false;
                };
            }
        }
    }
}
