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


            if (!String.IsNullOrEmpty(values[0].ToString()) && !String.IsNullOrEmpty(values[1].ToString()))
            {
                double btw;
                double bedragExcl;
                bool hasValidBedragExcl = double.TryParse(values[0].ToString(), out bedragExcl);
                bool hasValidBTW = double.TryParse(values[1].ToString(), out btw);
                if (hasValidBedragExcl && hasValidBTW)
                {
                    double bedragIncl = bedragExcl + bedragExcl * btw / 100.00;
                    return bedragIncl.ToString();
                }

            }

            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
