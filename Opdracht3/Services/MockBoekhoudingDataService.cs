using Opdracht3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.Services
{
    public class MockBoekhoudingDataService : IBoekhoudingDataService
    {
        #region fields
        private IList<Klant> _klanten;
        private IList<Leverancier> _leveranciers;
        private IList<AankoopFactuur> _aankoopDagBoek;
        private IList<VerkoopFactuur> _verkoopDagBoek;
        private IList<KasVerrichting> _kasBoek;
        #endregion

        //constructor:
        public MockBoekhoudingDataService()
        {
            InitLijsten();
        }
        private void InitLijsten()
        {
            InitKlanten();
            InitLeveranciers();
            InitAankoopDagBoek();
            InitVerkoopDagBoek();
            InitKasBoek();
        }


        //Klanten lijst
        private void InitKlanten()
        {
            _klanten = new List<Klant>()
            {
                new Klant(){ ContactNr=1,Voornaam = "Maria", Familienaam="De Smet", BTWNr="", Straat="Nijvelsesteenweg 346", Postcode=1500,Gemeente="Halle" },
                new Klant(){ ContactNr=2,Voornaam="Arthur", Familienaam="Peeters", BTWNr="12345647",Straat="Biesputstraat 24",Postcode=1040,Gemeente="Etterbeek"},
                new Klant(){ ContactNr=3,Voornaam="Lucas", Familienaam="Goossens", BTWNr="12345648",Straat="Prins Boudewijnlaan 95",Postcode=2550,Gemeente="Kontich"},
                new Klant(){ ContactNr=4,Voornaam="Elena", Familienaam="Mertens", BTWNr="",Straat="Roeselaarsestraat 282",Postcode=8870,Gemeente="Izegem"},
                new Klant(){ ContactNr=5,Voornaam="Mohamed", Familienaam="Kasmi", BTWNr="",Straat="Kuringersteenweg 241",Postcode=3500,Gemeente="Hasselt"},
                new Klant(){ ContactNr=6,Voornaam="Jean", Familienaam="Jacobs", BTWNr="",Straat="Vorkstraat 56",Postcode=9000,Gemeente="Gent"},
                new Klant(){ ContactNr=7,Voornaam="Olivia", Familienaam="Wouters", BTWNr="",Straat="Rozenwijk 11",Postcode=8900,Gemeente="Dikkebus"},
                new Klant(){ ContactNr=8,Voornaam="Mila", Familienaam="Gaillez", BTWNr="",Straat="Rue des Patriotes 18",Postcode=7860,Gemeente="Lessines"},
                new Klant(){ ContactNr=9,Voornaam="Adam", Familienaam="Willems", BTWNr="",Straat="Haverveeld 8",Postcode=8890,Gemeente="Lendelede"},
                new Klant(){ ContactNr=10,Voornaam="Victor", Familienaam="Claes", BTWNr="",Straat="Wijngaardstraat 11",Postcode=8500,Gemeente="Kortrijk"}
            };
        }
        public IList<Klant> GeefAlleKlanten()
        {
            return _klanten;
        }


        //Lijst Kasboek
        private void InitKasBoek()
        {
            _kasBoek = new List<KasVerrichting>(){
                new KasVerrichting() {  UniekNr = "14001", FactuurDatum = new DateTime(2020,1,13), Type="Bedrijfskosten", Omschrijving="Benzine",Contact=_klanten[0], BedragExclBTW=60.0,  BTWTarief=21},
                new KasVerrichting() {  UniekNr = "14002", FactuurDatum = new DateTime(2020,1,30), Contact=_klanten[0]}, //Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14003", FactuurDatum = new DateTime(2020,2,1), Contact=_klanten[1]},//Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14004", FactuurDatum = new DateTime(2020,2,25), Contact=_klanten[1]}//Verder aan te vullen
            };
        }
        public IList<KasVerrichting> GeefKasBoek()
        {
            return _kasBoek;
        }

        //Lijst VerkoopDagboek
        private void InitVerkoopDagBoek()
        {
            _verkoopDagBoek = new List<VerkoopFactuur>()
            {
                new VerkoopFactuur(){UniekNr="25002", Maand = "JUL", FactuurDatum = new DateTime(2020,7,25), Type = "Product", Omschrijving = "Tafel", BedragExclBTW = 260.0, BTWTarief = 21, Status = "Open", Contact = _klanten[1]},
                new VerkoopFactuur(){UniekNr="25003", Maand = "JUN", FactuurDatum = new DateTime(2020,6,2), Type = "Dienst", Omschrijving = "Herstelling werkblad", BedragExclBTW = 340.0, BTWTarief = 6, Status = "Open", Contact = _klanten[3]},
                new VerkoopFactuur(){UniekNr="25004", Maand = "MEI", FactuurDatum = new DateTime(2020,5,14), Type = "Dienst", Omschrijving = "Herstoffering", BedragExclBTW = 450.0, BTWTarief = 6, Status = "Betaald", BetaalDatum= new DateTime(2020,6,3),  Contact = _klanten[0]},
                new VerkoopFactuur(){UniekNr="25005", Maand = "JUL", FactuurDatum = new DateTime(2020,7,10), Type = "Product", Omschrijving = "Zetel", BedragExclBTW = 687.0, BTWTarief = 21, Status = "Betaald", BetaalDatum = new DateTime(2020,8,6), Contact = _klanten[2]},
            };
        }
        public IList<VerkoopFactuur> GeefVerkoopDagBoek()
        {
            return _verkoopDagBoek;
        }


        //Lijst AankoopDagboek
        private void InitAankoopDagBoek()
        {
            _aankoopDagBoek = new List<AankoopFactuur>()
            {
                new AankoopFactuur(){ UniekNr= "7427", Maand = "JUL", FactuurDatum= new DateTime(2020,12,7), Type = "Bedrijfskosten", Omschrijving="Wasmachine Siemens", BedragExclBTW= 120.10, BTWTarief=21, Status = "Betaald", BetaalDatum=new DateTime(2020,12,8), Contact = _leveranciers[0]  },
                new AankoopFactuur(){ UniekNr= "6372", Maand = "JAN", FactuurDatum= new DateTime(2020,12,1), Type = "Inkoop", Omschrijving="Koffiezet Senseo", BedragExclBTW= 60.22, BTWTarief=6, Status = "Open", BetaalDatum=new DateTime(2020,12,6), Contact = _leveranciers[1] , }

            };
        }
        public IList<AankoopFactuur> GeefAankoopDagBoek()
        {
            return _aankoopDagBoek;
        }
        


        //Leverancier Lijst
        private void InitLeveranciers()
        {
            _leveranciers = new List<Leverancier>()
            {
                new Leverancier(){ ContactNr=56, NaamBedrijf="Bedrijf A", BTWNr="00014578441", Straat="Bedrijfstraat 1", Postcode=9000,Gemeente="Gent" },
                new Leverancier(){ ContactNr=38, NaamBedrijf="Bedrijf B", BTWNr="0008965321",Straat="Bedrijfstraat 2",Postcode=8500,Gemeente="Brugge"},
                new Leverancier(){ ContactNr=86, NaamBedrijf="Bedrijf C", BTWNr="00077638903",Straat="Landgraafstraat 15",Postcode=8500,Gemeente="Brugge"}

            };
        }
        public IList<Leverancier> GeefAlleLeveranciers()
        {
            return _leveranciers;
        }


        //verwijder, wijzig en toevoegen van aankoopfactuur
        public void WijzigAankoopFactuur(AankoopFactuur selectedAankoopFactuur)
        {

            int index = _aankoopDagBoek.IndexOf(selectedAankoopFactuur);
            if (index >= 0)
            {
                _aankoopDagBoek[index] = selectedAankoopFactuur;
            }
        }
        public IList<AankoopFactuur> VerwijderAankoopFactuur(AankoopFactuur selectedAankoopFactuur)
        {
            _aankoopDagBoek.Remove(selectedAankoopFactuur);
            return _aankoopDagBoek;
        }
        public IList<AankoopFactuur> VoegAankoopFactuurToe(AankoopFactuur factuur)
        {
            _aankoopDagBoek.Add(factuur);
            return _aankoopDagBoek;
        }


        //Verwijder, wijzig en toevoegen van verkoopfactuur
        public void WijzigVerkoopFactuur(VerkoopFactuur selectedVerkoopFactuur)
        {

            int index = _verkoopDagBoek.IndexOf(selectedVerkoopFactuur);
            if (index >= 0)
            {
                _verkoopDagBoek[index] = selectedVerkoopFactuur;
            }
        }
        public IList<VerkoopFactuur> VerwijderVerkoopFactuur(VerkoopFactuur selectedVerkoopFactuur)
        {
            _verkoopDagBoek.Remove(selectedVerkoopFactuur);
            return _verkoopDagBoek;
        }
        public IList<VerkoopFactuur> VoegVerkoopFactuurToe(VerkoopFactuur factuur)
        {
            _verkoopDagBoek.Add(factuur);
            return _verkoopDagBoek;
        }


        //verwijder, wijzig en toevoegen van kasboek
        public void WijzigKasBoek(KasVerrichting selectedKasVerrichting)
        {
            int index = _kasBoek.IndexOf(selectedKasVerrichting);
            if (index >= 0)
            {
                _kasBoek[index] = selectedKasVerrichting;
            }
        }
        public IList<KasVerrichting> VoegKasVerrichtingToe(KasVerrichting kasVerrichting)
        {
            _kasBoek.Add(kasVerrichting);
            return _kasBoek;
        }

        public IList<KasVerrichting> VerwijderKasVerrichting(KasVerrichting selectedKasVerrichting)
        {
            _kasBoek.Remove(selectedKasVerrichting);
            return _kasBoek;
        }



        //verwijder, wijzig en toevoegen van Leverancier
        public void WijzigLeverancier(Leverancier selectedLeverancier)
        {
            int index = _leveranciers.IndexOf(selectedLeverancier);
            if (index >= 0) _leveranciers[index] = selectedLeverancier;
        }

        public IList<Leverancier> VerwijderLeverancier(Leverancier selectedLeverancier)
        {
            _leveranciers.Remove(selectedLeverancier);
            return _leveranciers;
        }

        public IList<Leverancier> VoegLeverancierToe(Leverancier leverancier)
        {
            _leveranciers.Add(leverancier);
            return _leveranciers;
        }

        //verwijder, wijzig en toevoegen van klant
        public IList<Klant> VoegKlantToe(Klant klant)
        {
            int ContactNr = (_klanten.Count > 0) ? _klanten.Max(b => b.ContactNr) + 1 : 1;
            klant.ContactNr = ContactNr;
            _klanten.Add(klant);
            return _klanten;
        }
        public void WijzigKlant(Klant selectedKlant)
        {
            int index = _klanten.IndexOf(selectedKlant);
            if (index >= 0)
            {
                _klanten[index] = selectedKlant;
            }
        }
        public IList<Klant> VerwijderKlant(Klant selectedKlant)
        {
            _klanten.Remove(selectedKlant);
            return _klanten;
        }

    }
}
