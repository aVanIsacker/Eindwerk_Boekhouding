using Opdracht3.Models;
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
    public class OverzichtViewModel : ObservableObject
    {
        //public IBoekhoudingDataService _dataservice;
        private ObservableCollection<TotaalOverzicht> _totaalOverzicht;
        private TotaalOverzicht _selectedTotaalOverzicht;

        private ObservableCollection<OpenstaandeFactuur> _openstaandeFacturen;

        private IBoekhoudingDataService dataService;
        private OpenstaandeFactuur _selectedFactuur;

        public OverzichtViewModel(IBoekhoudingDataService dataService)
        {
            this.dataService = dataService;

            RefreshDataSourceCommand = new RelayCommand(RefreshData);
            TotaalOverzicht = new ObservableCollection<TotaalOverzicht>(dataService.GeefTotaalOverzicht());
            OpenstaandeFacturen = new ObservableCollection<OpenstaandeFactuur>(dataService.GetOpenstaandeFacturen());
        }

        public ICommand RefreshDataSourceCommand { get; private set; }

        public void RefreshData()
        {
            TotaalOverzicht.Clear();
            OpenstaandeFacturen.Clear();

            TotaalOverzicht = new ObservableCollection<TotaalOverzicht>(dataService.GeefTotaalOverzicht());
            OpenstaandeFacturen = new ObservableCollection<OpenstaandeFactuur>(dataService.GetOpenstaandeFacturen());
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

        public TotaalOverzicht SelectedTotaaloverzicht
        {
            get { return _selectedTotaalOverzicht; }
            set { OnPropertyChanged(ref _selectedTotaalOverzicht, value); }
        }
    }
}
