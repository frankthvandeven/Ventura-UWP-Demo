using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventura.Helpers
{
    public static class Parsers
    {

        private static readonly string[] _formats = { 
                // Basic formats
                "yyyyMMddTHHmmsszzz",
                "yyyyMMddTHHmmsszz",
                "yyyyMMddTHHmmssZ",
                // Extended formats
                "yyyy-MM-dd HH:mm:ss", // for VanArsdel.db
                "yyyy-MM-ddTHH:mm:sszzz",
                "yyyy-MM-ddTHH:mm:sszz",
                "yyyy-MM-ddTHH:mm:ssZ",
                // All of the above with reduced accuracy
                "yyyyMMddTHHmmzzz",
                "yyyyMMddTHHmmzz",
                "yyyyMMddTHHmmZ",
                "yyyy-MM-ddTHH:mmzzz",
                "yyyy-MM-ddTHH:mmzz",
                "yyyy-MM-ddTHH:mmZ",
                // Accuracy reduced to hours
                "yyyyMMddTHHzzz",
                "yyyyMMddTHHzz",
                "yyyyMMddTHHZ",
                "yyyy-MM-ddTHHzzz",
                "yyyy-MM-ddTHHzz",
                "yyyy-MM-ddTHHZ" };

        // 2018-04-17 17:31:31.4037443+00:00
        // 2018-04-17 17:31:31 == 19 characters

        public static DateTime ParseISO8601String(string str)
        {
            if (str.Length > 19 && str.Contains('+'))
                str = str.Substring(0, 19);

            return DateTime.ParseExact(str, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

    }
}
