using System;
using Ventura.Helpers;

namespace Ventura.Controls
{
    internal static class AutoCompletionTools
    {
        internal static string AutoCompleteDate(string origtext)
        {
            string trimtext = origtext.Trim();

            if (trimtext == "")
                return "";

            // retrieve Locale information
            var dateorder = GlobalizationHelper.DateOrder();

            // split the textbox.value up in 1,2 or 3 parts
            string[] values = SplitInto3(trimtext);

            // It is possible that the parts are all non-numeric
            if (values[0].Length + values[1].Length + values[2].Length == 0)
                return origtext;

            #region Support for unseparated dates xxyy, xxyyzz or xxyyzzzz
            if (values[0].Length > 0 && values[1].Length == 0 && values[2].Length == 0)
            {
                string temp = values[0];

                switch (temp.Length)
                {
                    case 4:
                        values[0] = temp.Substring(0, 2);
                        values[1] = temp.Substring(2, 2);
                        values[2] = "";
                        break;
                    case 6:
                        values[0] = temp.Substring(0, 2);
                        values[1] = temp.Substring(2, 2);
                        values[2] = temp.Substring(4, 2);
                        break;
                    case 8:

                        if (dateorder == DateOrder.YMD)
                        {
                            values[0] = temp.Substring(0, 4);
                            values[1] = temp.Substring(4, 2);
                            values[2] = temp.Substring(6, 2);
                        }
                        else // DMY or MDY
                        {
                            values[0] = temp.Substring(0, 2);
                            values[1] = temp.Substring(2, 2);
                            values[2] = temp.Substring(4, 4);
                        }
                        break;
                }
            }
            #endregion

            // test a new datetime value
            DateTime? candidate_value = null;

            try // If the Date is invalid, there will be an Exception
            {

                #region Convert the 0, 1, 2 or 3-string-parts to a DateTime value, throws Exception upon failure

                if (values[0].Length > 0 && values[1].Length == 0 && values[2].Length == 0)
                {
                    candidate_value = new DateTime(DateTime.Now.Year,
                                                 DateTime.Now.Month,
                                                 Convert.ToInt32(values[0]));
                }
                else if (values[0].Length > 0 && values[1].Length > 0 && values[2].Length == 0 && dateorder == DateOrder.MDY)
                {
                    candidate_value = new DateTime(DateTime.Now.Year,
                                                 Convert.ToInt32(values[0]),
                                                 Convert.ToInt32(values[1]));
                }
                else if (values[0].Length > 0 && values[1].Length > 0 &&
                         values[2].Length == 0 && (dateorder == DateOrder.DMY | dateorder == DateOrder.YMD))
                {
                    candidate_value = new DateTime(DateTime.Now.Year,
                                                 Convert.ToInt32(values[1]),
                                                 Convert.ToInt32(values[0]));
                }
                else if (dateorder == DateOrder.DMY)
                {
                    int year = Convert.ToInt32(values[2]);

                    if (values[2].Length <= 2 && year < 100)
                        year = GlobalizationHelper.ToFourDigitYear(year);

                    candidate_value = new DateTime(year,
                                                 Convert.ToInt32(values[1]),
                                                 Convert.ToInt32(values[0]));
                }
                else if (dateorder == DateOrder.MDY)
                {
                    int year = Convert.ToInt32(values[2]);

                    if (values[2].Length <= 2 && year < 100)
                        year = GlobalizationHelper.ToFourDigitYear(year);

                    candidate_value = new DateTime(year,
                                                 Convert.ToInt32(values[0]),
                                                 Convert.ToInt32(values[1]));
                }
                else if (dateorder == DateOrder.YMD)
                {
                    int year = Convert.ToInt32(values[0]);

                    if (values[0].Length <= 2 && year < 100)
                        year = GlobalizationHelper.ToFourDigitYear(year);

                    candidate_value = new DateTime(year,
                                                 Convert.ToInt32(values[1]),
                                                 Convert.ToInt32(values[2]));
                }

                #endregion

                if (candidate_value == null)
                    return trimtext;

                return candidate_value.Value.ToShortDateString();

            }
            catch (Exception)
            {
                return trimtext;
            }

        } // end of method

        private static string[] SplitInto3(string text)
        {
            int arraypos = 0;
            string[] values = new string[3];
            values[0] = "";
            values[1] = "";
            values[2] = "";

            // split the textvalue up in 3 parts
            for (int x = 0; x < text.Length; x++)
            {
                char midchar = text[x];

                if (Char.IsNumber(midchar) == true)
                    values[arraypos] += midchar;
                else
                {
                    if (values[arraypos].Length > 0)
                        arraypos++;

                    if (arraypos > 2)
                        break;
                }
            }

            return values;
        }

        internal static string AutoCompleteIntegral(string origtext, bool nullable)
        {
            string trimtext = origtext.Trim();

            if (trimtext == "")
            {
                if (!nullable)
                    trimtext = "0";
            }

            return trimtext;
        } // end of method

        internal static string AutoCompleteFloatingPoint(string origtext, bool nullable)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

            string trimtext = origtext.Trim();

            if (trimtext == "")
            {
                if (nullable)
                    return "";

                trimtext = "0";
            }

            if (separator == ".")
                trimtext = trimtext.Replace(",", ".");
            else
                trimtext = trimtext.Replace(".", ",");

            return trimtext;
        }

        internal static string AutoCompleteDecimal(string origtext, bool nullable, int precision, int scale)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

            string trimtext = origtext.Trim();

            if (trimtext == "")
            {
                if (nullable)
                    return "";

                trimtext = "0";
            }

            if (separator == ".")
                trimtext = trimtext.Replace(",", ".");
            else
                trimtext = trimtext.Replace(".", ",");

            try
            {
                // use rounding if the number of decimals need to be reduced.
                decimal dec = Convert.ToDecimal(trimtext);
                dec = decimal.Round(dec, scale);
                trimtext = dec.ToString("F" + scale.ToString());
            }
            catch
            { }

            return trimtext;
        }


        internal static string AutoCompleteString(string origtext, InputStringFormatting formatting)
        {
            string trimtext = origtext.Trim();

            if (formatting == InputStringFormatting.ToUpper)
                trimtext = trimtext.ToUpper();
            else if (formatting == InputStringFormatting.ToLower)
                trimtext = trimtext.ToLower();

            return trimtext;
        }

        //internal static string FormatDateSample()
        //{
        //    var dateorder = GlobalizationHelper.DateOrder();
        //    string separator = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator;
        //    if (dateorder == DateOrder.DMY)
        //        return "dd" + separator + "mm" + separator + "jjjj";
        //    if (dateorder == DateOrder.MDY)
        //        return "mm" + separator + "dd" + separator + "jjjj";
        //    if (dateorder == DateOrder.YMD)
        //        return "jjjj" + separator + "mm" + separator + "dd";
        //    return "??";
        //}

    } // end of class

    public enum InputStringFormatting
    {
        None = 0,
        ToUpper = 1,
        ToLower = 2
    }


} // end of namespace 
