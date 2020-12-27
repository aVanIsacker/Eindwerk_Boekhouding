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


            if (values[0] != null)     //hier BedragExclBTW inkrijgen ipv value
            {
                //int index = (int)values[1];

                //if (index == 1) //tarief 6%
                //{
                //    double exclBTW = (double)values[1];
                //    double BTWBedrag = (double)values[1] * 6 / 100.0;
                //    double inclBTW = exclBTW + BTWBedrag;
                //    return inclBTW.ToString();
                //}

                //if (index == 2) //tarief 21%
                //{
                //    double exclBTW = (double)values[1];
                //    double BTWBedrag = (double)values[1] * 21 / 100.0;
                //    double inclBTW = exclBTW + BTWBedrag;
                //    return inclBTW.ToString();
                //}

            }

            return "";
        }

        

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        // hier niet multi geprobeerd, maar met parameter, lukte niet

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    // dus, we krijgen het BedragExclBTW --> dit is de value --->dus nodig value+(value*BTWTarief/100.0) of value + BTWBedrag

        //    //BedragInclBTW 
        //    // als zowel value niet nul is en % btw geselecteerd is


        //    if (value!= null)     //hier BedragExclBTW inkrijgen ipv value
        //    {
        //        int index = (int)parameter;

        //        if (index == 1) //tarief 6%
        //        {
        //            double exclBTW = (double)value;
        //            double BTWBedrag = (double)value * 6 / 100.0;
        //            double inclBTW = exclBTW + BTWBedrag;
        //            return inclBTW.ToString();
        //        }

        //        if (index == 2) //tarief 21%
        //        {
        //            double exclBTW = (double)value;
        //            double BTWBedrag = (double)value * 21 / 100.0;
        //            double inclBTW = exclBTW + BTWBedrag;
        //            return inclBTW.ToString();
        //        }

        //    }

        //    return "";
        //}

        //public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
