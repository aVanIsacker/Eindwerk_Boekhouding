using Opdracht3.Services;
using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.ViewModels
{
    public class OverzichtViewModel : ObservableObject
    {
        //public IBoekhoudingDataService _dataservice;
        private ObservableCollection<TotaalOverzicht> _totaalOverzicht;
        private TotaalOverzicht _selectedTotaalOverzicht;
        private IBoekhoudingDataService dataService;

        public OverzichtViewModel(IBoekhoudingDataService dataService)
        {
            this.dataService = dataService;
            _totaalOverzicht = new ObservableCollection<TotaalOverzicht>(dataService.GeefTotaalOverzicht());
        }

        public ObservableCollection<TotaalOverzicht> TotaalOverzicht
        {
            get { return _totaalOverzicht; }
            set { OnPropertyChanged(ref _totaalOverzicht, value); }
        }
        public TotaalOverzicht SelectedTotaaloverzicht
        {
            get { return _selectedTotaalOverzicht; }
            set { OnPropertyChanged(ref _selectedTotaalOverzicht, value); }
        }
    }
}
