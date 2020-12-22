using Opdracht3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.Services
{
    public interface IBoekhoudingDataService
    {
        IList<AankoopFactuur> GeefAankoopDagBoek();
        IList<KasVerrichting> GeefKasBoek();
        IList<VerkoopFactuur> GeefVerkoopDagBoek(); 

        IList<Klant> GeefAlleKlanten();
        IList<Leverancier> GeefAlleLeveranciers();



        //Lijst verwijderen, toevoegen en wijzigen van Aankoopfactuur
        IList<AankoopFactuur> VoegAankoopFactuurToe(AankoopFactuur factuur);
        IList<AankoopFactuur> VerwijderAankoopFactuur(AankoopFactuur selectedAankoopFactuur);
        void WijzigAankoopFactuur(AankoopFactuur selectedAankoopFactuur);


        //Lijst verwijderen, toevoegen en wijzigen van Leverancier
        IList<Leverancier> VoegLeverancierToe(Leverancier leverancier);
        IList<Leverancier> VerwijderLeverancier(Leverancier selectedLeverancier);
        void WijzigLeverancier(Leverancier selectedLeverancier);


        //lijst verwijderen, toevoegen en wijzigen van Kasboek
        IList<KasVerrichting> VoegKasVerrichtingToe(KasVerrichting kasVerrichting);
        IList<KasVerrichting> VerwijderKasVerrichting(KasVerrichting selectedKasVerrichting);
        void WijzigKasBoek(KasVerrichting selectedKasVerrichting);

        //Lijst verwijderen, toevoegen en wijzigen van Klant
        IList<Klant> VoegKlantToe(Klant klant);
        IList<Klant> VerwijderKlant(Klant selectedKlant);
        void WijzigKlant(Klant selectedKlant);

        //Lijst verwijderen, toevoegen en wijzigen van VerkoopFactuur
        IList<VerkoopFactuur> VoegVerkoopFactuurToe(VerkoopFactuur factuur);
        IList<VerkoopFactuur> VerwijderVerkoopFactuur(VerkoopFactuur selectedVerkoopFactuur);
        void WijzigVerkoopFactuur(VerkoopFactuur selectedVerkoopFactuur);

    }
}
