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
    public class IntToVisibilityConverter : IValueConverter
    {
       
        //public object Convert(object value, Type targetType, object parameter, string language)
        //{
        //    int index = (int)value;
        //    return index == 0 ? Visibility.Hidden : Visibility.Visible;
        //}

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)value;
            return index == 2 ? Visibility.Hidden : Visibility.Visible;
        }


        //public object ConvertBack(object value, Type targetType, object parameter, string language)
        //{
        //    throw new NotImplementedException();
        //}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
