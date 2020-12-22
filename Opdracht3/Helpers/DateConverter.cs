using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Opdracht3.Helpers
{
    [ValueConversion(  typeof(DateTime), typeof(String))]
    public class DateTimeToFutureExpireDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((DateTime)value).AddDays(3 * 7).ToString("dd/MM/yyyy");

            return "";
   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return DateTime.Parse(value.ToString());
            else
                return DateTime.Today;
        }
    }
}
