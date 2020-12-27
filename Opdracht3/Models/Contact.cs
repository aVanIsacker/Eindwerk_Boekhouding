using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht3.ViewModels
{
    public class Contact
    {
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public string BTWNr { get; set; }
        public int ContactNr { get; set; }

        public virtual string GetName()
        {
            return BTWNr;
        }
    }
}
