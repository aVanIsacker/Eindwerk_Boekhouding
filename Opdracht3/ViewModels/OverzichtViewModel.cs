using Opdracht3.Models;
using Opdracht3.Services;
using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Opdracht3.ViewModels
{
    public class OverzichtViewModel : ObservableObject
    {
        //public IBoekhoudingDataService _dataservice;
        private ObservableCollection<TotaalOverzicht> _totaalOverzicht;
        private ObservableCollection<TotaalOverzicht> _winstVerlies;
        private ObservableCollection<int> _jaren; 
        private TotaalOverzicht _selectedTotaalOverzicht;

        private ObservableCollection<OpenstaandeFactuur> _openstaandeFacturen;

        private IBoekhoudingDataService dataService;
        private OpenstaandeFactuur _selectedFactuur;
        private int _selectedJaar;

        public OverzichtViewModel(IBoekhoudingDataService dataService)
        {
            this.dataService = dataService;

            RefreshDataSourceCommand = new RelayCommand(RefreshData);
            Jaren = new ObservableCollection<int>(dataService.GetActiveYears());
            SelectedJaar = Jaren.First();
        }

        public ICommand RefreshDataSourceCommand { get; private set; }

        public void RefreshData()
        {
            Jaren = new ObservableCollection<int>(dataService.GetActiveYears());
            VernieuwViewData();

        }

        public void VernieuwViewData()
        {
            var overzicht = dataService.GeefTotaalOverzicht(SelectedJaar);
            WinstVerlies = new ObservableCollection<TotaalOverzicht>(overzicht);
            TotaalOverzicht = new ObservableCollection<TotaalOverzicht>(overzicht);
            OpenstaandeFacturen = new ObservableCollection<OpenstaandeFactuur>(dataService.GetOpenstaandeFacturen(SelectedJaar));
        }

        public ObservableCollection<int> Jaren
        {
            get { return _jaren; }
            set { OnPropertyChanged(ref _jaren, value); }
        }

        public ObservableCollection<TotaalOverzicht> WinstVerlies
        {
            get { return _winstVerlies; }
            set { OnPropertyChanged(ref _winstVerlies, value); }
        }

        public ObservableCollection<TotaalOverzicht> TotaalOverzicht
        {
            get { return _totaalOverzicht; }
            set { OnPropertyChanged(ref _totaalOverzicht, value); }
        }

        public ObservableCollection<OpenstaandeFactuur> OpenstaandeFacturen
        {
            get { return _openstaandeFacturen; }
            set { OnPropertyChanged(ref _openstaandeFacturen, value); }
        }

        public OpenstaandeFactuur SelectedFactuur
        {
            get { return _selectedFactuur; }
            set { OnPropertyChanged(ref _selectedFactuur, value); }
        }
        public int SelectedJaar
        {
            get { return _selectedJaar; }
            set
            {
                OnPropertyChanged(ref _selectedJaar, value);
                VernieuwViewData(); 
            }
        }

        public TotaalOverzicht SelectedTotaaloverzicht
        {
            get { return _selectedTotaalOverzicht; }
            set { OnPropertyChanged(ref _selectedTotaalOverzicht, value); }
        }
    }
}
