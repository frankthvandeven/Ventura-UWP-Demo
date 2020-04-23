using System;

namespace Ventura.Helpers
{
    public static class Sqlite
    {

        public static DateTime TEXTToDateTime(string text)
        {
            return Parsers.ParseISO8601String(text);
        }

        public static string DateTimeToTEXT(DateTime value)
        {
            //2015-07-25 23:55:45.9330028+00:00

            string text = value.ToString("yyyy-MM-dd HH:mm:ss");

            return text;
        }

        public static DateTime? TEXTToDateTimeNullable(string text)
        {
            if (text == null)
                return null;

            if (text.Trim().Length == 0)
                return null;

            return TEXTToDateTime(text);
        }

        public static string DateTimeToTEXTNullable(DateTime? datetime)
        {
            if (datetime == null)
                return null;

            return DateTimeToTEXT(datetime.Value);
        }


    }
}
