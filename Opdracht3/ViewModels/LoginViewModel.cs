using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.ViewModels
{
    public class LoginViewModel : Screen 
    {
        private string _gebruikersNaam;

        public string GebruikersNaam
        {
            get { return _gebruikersNaam; }
            set { _gebruikersNaam = value;
                NotifyOfPropertyChange(() => GebruikersNaam);
            }

        }

        private string _wachtwoord;

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set
            {
                _wachtwoord = value;
                NotifyOfPropertyChange(() => Wachtwoord);
            }

        }

        public bool KanLoginKnop(string gebruikersNaam, string wachtwoord)
        {
            bool output = false;
            if (gebruikersNaam.Length > 0 && wachtwoord.Length > 0)
            {
                output = true;
            }

            return output;
        }

        public void LoginKnop(string gebruikersNaam, string wachtwoord)
        {
            Console.WriteLine();
        }


    }
}
