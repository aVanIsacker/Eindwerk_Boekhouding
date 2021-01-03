using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Opdracht3.Helpers
{
    //[ValueConversion(typeof(int), typeof(String))]
    public class MaandIntToVolledigeNaamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName((int)value).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
