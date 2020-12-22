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
        //private int _id;

        //public int Id { get { return _id; } set { OnPropertyChanged(ref _id, value); } }

        public VerkoopDagBoekViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            VerkoopFacturen = new ObservableCollection<VerkoopFactuur>(dataService.GeefVerkoopDagBoek());

            AddVerkoopCommand = new RelayCommand(VoegVerkoopToe);
            EditVerkoopCommand = new RelayCommand(WijzigVerkoop);
            DeleteVerkoopCommand = new RelayCommand(VerwijderVerkoop);

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
            VerkoopFactuur verkoopDagBoek = new VerkoopFactuur() { UniekNr = "NA", BetaalDatum = new DateTime(2020, 12, 22), BedragExclBTW = 0, BTWTarief = 0, FactuurDatum = new DateTime(2020,12,22), Type = "NA", Omschrijving = "NA" };
            VerkoopFacturen = new ObservableCollection<VerkoopFactuur>(_dataService.VoegVerkoopFactuurToe(verkoopDagBoek));
            SelectedVerkoopFactuur = _verkoopFactuur[_verkoopFactuur.Count - 1];
        }

        public ICommand AddVerkoopCommand { get; private set; }
        public ICommand EditVerkoopCommand { get; private set; }
        public ICommand DeleteVerkoopCommand { get; private set; }

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
    }
}
