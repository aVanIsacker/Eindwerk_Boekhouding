using Opdracht3.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Opdracht3.Helpers
{
    class BTWConverter : IMultiValueConverter
    {
       

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // dus, we krijgen het BedragExclBTW --> dit is de value --->dus nodig value+(value*BTWTarief/100.0) of value + BTWBedrag

            //BedragInclBTW 
            // als zowel value niet nul is en % btw geselecteerd is

            //if (values != null)
            //{
            //    double exclBTW = (double)values.GetValue(0);
            //    double BTWBedrag =  (double)values.GetValue(1) * 6 / 100.0;
            //    double inclBTW = exclBTW + BTWBedrag;
            //    // hoe selecteer ik de input van de BTW, ipv deze waar ik het aan bind, moet ik de source en target hiervoor gebruiken? MultiBinding in VerkoopDagBoekView?

            //    return inclBTW.ToString();

            //}

            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
