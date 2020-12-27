using Opdracht3.Services;
using Opdracht3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IBoekhoudingDataService _dataService;
        private KlantenViewModel _klantenViewModel;
        private LeveranciersViewModel _leveranciersViewModel;
        private AankoopDagBoekViewModel _aankoopDagBoekViewModel;
        private VerkoopDagBoekViewModel _verkoopDagBoekViewModel;
        private KasBoekViewModel _kasBoekViewModel;
        private OverzichtViewModel _overzichtViewModel;
        private LoginViewModel _loginViewModel;

        public MainViewModel()
        {
            _loginViewModel =new LoginViewModel();
            //ActivateItem(_loginVM);


            _dataService = new MockBoekhoudingDataService();

            KlantenViewModel = new KlantenViewModel(_dataService);
            LeveranciersViewModel = new LeveranciersViewModel(_dataService);
            AankoopDagBoekViewModel = new AankoopDagBoekViewModel(_dataService);
            VerkoopDagBoekViewModel = new VerkoopDagBoekViewModel(_dataService);
            KasBoekViewModel = new KasBoekViewModel(_dataService);
            OverzichtViewModel = new OverzichtViewModel(_dataService);
         



        }
        private int _selectedTabIndex;

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { 
                _selectedTabIndex = value; 
                UpdateView(value); 
            }
        }

        private void UpdateView(int index)
        {
            switch(index)
            {
                case 0:
                    VerkoopDagBoekViewModel.RefreshData();
                    break;
                case 2:
                    KasBoekViewModel.RefreshData();
                    break;
                case 5:
                    OverzichtViewModel.RefreshData();
                    break;
                default:
                    break;
            }
        }

        public LeveranciersViewModel LeveranciersViewModel
        {
            get { return _leveranciersViewModel; }
            set { OnPropertyChanged(ref _leveranciersViewModel, value); }
        }
        public AankoopDagBoekViewModel AankoopDagBoekViewModel
        {
            get { return _aankoopDagBoekViewModel; }
            set { OnPropertyChanged(ref _aankoopDagBoekViewModel, value); }
        }

        public KlantenViewModel KlantenViewModel
        {
            get { return _klantenViewModel; }
            set { OnPropertyChanged(ref _klantenViewModel, value); }
        }

        public VerkoopDagBoekViewModel VerkoopDagBoekViewModel
        {
            get { return _verkoopDagBoekViewModel; }
            set { OnPropertyChanged(ref _verkoopDagBoekViewModel, value); }
        }



        public KasBoekViewModel KasBoekViewModel
        {
            get { return _kasBoekViewModel; }
            set { OnPropertyChanged(ref _kasBoekViewModel, value); }
        }

        public OverzichtViewModel OverzichtViewModel
        {
            get { return _overzichtViewModel; }
            set { OnPropertyChanged(ref _overzichtViewModel, value); }
        }
    }
}




