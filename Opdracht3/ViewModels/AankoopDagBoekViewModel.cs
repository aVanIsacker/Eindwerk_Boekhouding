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
    public class AankoopDagBoekViewModel : ObservableObject
    {

        private IBoekhoudingDataService _dataService;
        private ObservableCollection<AankoopFactuur> _aankoopFactuur;
        private AankoopFactuur _selectedAankoopFactuur;
        private ObservableCollection<Leverancier> _leveranciers;
        //private int _id;

        //public int Id { get { return _id; } set { OnPropertyChanged(ref _id, value);  } }

        public AankoopDagBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            AankoopFacturen = new ObservableCollection<AankoopFactuur>(dataService.GeefAankoopDagBoek());
            AddAankoopCommand = new RelayCommand(VoegAankoop);
            EditAankoopCommand = new RelayCommand(WijzigAankoop);
            DeleteAankoopCommand = new RelayCommand(VerwijderAankoop);
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.GeefAlleLeveranciers());

        }

        private void VerwijderAankoop()
        {
            AankoopFacturen = new ObservableCollection<AankoopFactuur>(_dataService.VerwijderAankoopFactuur(SelectedAankoopFactuur));
            if (_aankoopFactuur.Count > 0) SelectedAankoopFactuur = _aankoopFactuur[0];
        }

        private void WijzigAankoop()
        {
            _dataService.WijzigAankoopFactuur(SelectedAankoopFactuur);
            RefreshData();
        }

        private void VoegAankoop()
        {
            AankoopFactuur aankoopDagBoek = new AankoopFactuur() { UniekNr = 0, BetaalDatum = DateTime.Now, BedragExclBTW = 0, BTWTarief = 21, FactuurDatum = DateTime.Now, Omschrijving = "NA" };
            AankoopFacturen = new ObservableCollection<AankoopFactuur>(_dataService.VoegAankoopFactuurToe(aankoopDagBoek));
            SelectedAankoopFactuur = _aankoopFactuur[_aankoopFactuur.Count - 1];
        }

        internal void RefreshData()
        {
            SelectedAankoopFactuur = new AankoopFactuur();
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.GeefAlleLeveranciers());
            AankoopFacturen = new ObservableCollection<AankoopFactuur>(_dataService.GeefAankoopDagBoek());
        }

        public ICommand AddAankoopCommand { get; private set; }
        public ICommand EditAankoopCommand { get; private set; }
        public ICommand DeleteAankoopCommand { get; private set; }

        public ObservableCollection<AankoopFactuur> AankoopFacturen
        {
            get { return _aankoopFactuur; }
            set { OnPropertyChanged(ref _aankoopFactuur, value); }
        }
        public AankoopFactuur SelectedAankoopFactuur
        {
            get { return _selectedAankoopFactuur; }
            set { OnPropertyChanged(ref _selectedAankoopFactuur, value); }
        }

        public ObservableCollection<Leverancier> Leveranciers
        {
            get { return _leveranciers; }
            set { OnPropertyChanged(ref _leveranciers, value); }
        }
    }
}
