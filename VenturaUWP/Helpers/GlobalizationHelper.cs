using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Ventura.Helpers
{
    public static class GlobalizationHelper
    {

        public static DateOrder DateOrder()
        {
            return (DateOrder)Convert.ToInt32(GetInfo(LOCALE_IDATE));
        }

        /// <summary>
        /// Converts the specified year to a four-digit year by using the System.Globalization.Calendar.TwoDigitYearMax
        ///  property to determine the appropriate century.
        /// </summary>
        public static int ToFourDigitYear(int year)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.Calendar.ToFourDigitYear(year);
        }


        [DllImport("kernel32.dll")]
        private static extern int GetLocaleInfo(int Locale, int LCType, [Out] StringBuilder lpLCData, int cchData);

        private const int LOCALE_SYSTEM_DEFAULT = 0x400;
        //private const int LOCALE_SDECIMAL = 0xE;
        private const int LOCALE_IDATE = 0x21;

        private static string GetInfo(int lInfo)
        {
            StringBuilder lpLCData = new StringBuilder(256);
            int ret = GetLocaleInfo(LOCALE_SYSTEM_DEFAULT, lInfo, lpLCData, lpLCData.Capacity);

            if (ret > 0)
            {
                return lpLCData.ToString().Substring(0, ret - 1);
            }

            return string.Empty;
        }

    }

    public enum DateOrder
    {
        MDY = 0,
        DMY = 1,
        YMD = 2
    }

}
