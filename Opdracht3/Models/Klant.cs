using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class Klant: Contact
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public override string ToString()
        {
            return $"{Voornaam} {Familienaam}";
        }

        public override string GetName()
        {
            return $"{Voornaam} {Familienaam}" ;
        }
    }
}
