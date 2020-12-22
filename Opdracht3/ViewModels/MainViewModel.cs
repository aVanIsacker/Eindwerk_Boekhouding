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
        //private KlantenVM _klantenVM;
        //private KasboekVM _kasBoekVM;

        private LeveranciersViewModel _leveranciersViewModel;
        private AankoopDagBoekViewModel _aankoopDagBoekViewModel;

        //private VerkoopdagboekVM _verkoopDagboekVM;
        //private OverzichtVM _overzichtVM;

        private LoginViewModel _loginViewModel;

        public MainViewModel()
        {
            _loginViewModel =new LoginViewModel();
            //ActivateItem(_loginVM);


            _dataService = new MockBoekhoudingDataService();
            LeveranciersViewModel = new LeveranciersViewModel(_dataService);
            AankoopViewModel = new AankoopDagBoekViewModel(_dataService);

            

            //KlantVM = new KlantenVM(_dataService);
            //KasBoekVM = new KasboekVM(_dataService);
            //VerkoopVM = new VerkoopdagboekVM(_dataService);
            //TotOverzichtVM = new OverzichtVM(_dataService);
        }

        public LeveranciersViewModel LeveranciersViewModel
        {
            get { return _leveranciersViewModel; }
            set { OnPropertyChanged(ref _leveranciersViewModel, value); }
        }
        public AankoopDagBoekViewModel AankoopViewModel
        {
            get { return _aankoopDagBoekViewModel; }
            set { OnPropertyChanged(ref _aankoopDagBoekViewModel, value); }
        }

        /*
        public KlantenVM KlantVM
        {
            get { return _klantenVM; }
            set { OnPropertyChanged(ref _klantenVM, value); }
        }
        public KasboekVM KasBoekVM
        {
            get { return _kasBoekVM; }
            set { OnPropertyChanged(ref _kasBoekVM, value); }
        }
        public VerkoopdagboekVM VerkoopVM
        {
            get { return _verkoopDagboekVM; }
            set { OnPropertyChanged(ref _verkoopDagboekVM, value); }
        }
        public OverzichtVM TotOverzichtVM
        {
            get { return _overzichtVM; }
            set { OnPropertyChanged(ref _overzichtVM, value); }
        }
        */
    }
}




