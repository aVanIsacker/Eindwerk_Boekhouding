using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3.Utilities
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Geeft het getal terug afgerond naar boven met X aantal plaatsen na de comma.
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="places">Aantal plaatsen na de comma</param>
        /// <returns>Double afgerond</returns>
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
    }
}
