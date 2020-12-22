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
    public class LeveranciersViewModel : ObservableObject
    {
        

        private IBoekhoudingDataService _dataService;
        private ObservableCollection<Leverancier> _leveranciers;
        private Leverancier _selectedLeverancier;
        //private int _id;

        //public int Id { get { return _id; } set { OnPropertyChanged(ref _id, value); } }

        public LeveranciersViewModel(IBoekhoudingDataService dataService)
        {
            _dataService = dataService;
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.GeefAlleLeveranciers());
            AddLeverancierCommand = new RelayCommand(VoegLeverancierToe);
            EditLeverancierCommand = new RelayCommand(WijzigLeverancier);
            DeleteLeverancierCommand = new RelayCommand(VerwijderLeverancier);
            /*
            if (Leveranciers.Count > 0)
            {
                SelectedLeverancier = Leveranciers[0];
            }
            */
        }

        private void VerwijderLeverancier()
        {
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.VerwijderLeverancier(SelectedLeverancier));
            if (_leveranciers.Count > 0) SelectedLeverancier = _leveranciers[0];
        }

        private void WijzigLeverancier()
        {
            _dataService.WijzigLeverancier(SelectedLeverancier);
        }

        private void VoegLeverancierToe()
        {
            Leverancier leverancier = new Leverancier() { ContactNr = 0, NaamBedrijf = "NA", BTWNr = "NA", Straat = "NA", Postcode = 0,  Gemeente = "NA" };
            Leveranciers = new ObservableCollection<Leverancier>(_dataService.VoegLeverancierToe(leverancier));
            SelectedLeverancier = _leveranciers[_leveranciers.Count - 1];
        }

        public ICommand AddLeverancierCommand { get; private set; }
        public ICommand EditLeverancierCommand { get; private set; }
        public ICommand DeleteLeverancierCommand { get; private set; }
        
        public ObservableCollection<Leverancier> Leveranciers
        {
            get { return _leveranciers; }
            set { OnPropertyChanged(ref _leveranciers, value); }
        }
        public Leverancier SelectedLeverancier
        {
            get { return _selectedLeverancier; }
            set { OnPropertyChanged(ref _selectedLeverancier, value); }
        }
    }                   
}
