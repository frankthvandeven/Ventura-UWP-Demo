using Demo.VenturaAutoCreate;
using Ventura.Controls;

namespace Demo.Helpers
{
    public static class CountryCodeHelper
    {

        public static PriKey_CountryCodes_Record LoadRow(string country_code_id)
        {
            var recordset = new PriKey_CountryCodes_Recordset();

            recordset.ExecSql(country_code_id);

            if (recordset.RecordCount == 0)
                return null;

            return recordset.CurrentRecord;
        }

        public static bool Exists(string country_code_id)
        {
            var record = LoadRow(country_code_id);

            if (record == null)
                return false;

            return true;
        }

        // [error] [warning]
        public static void Validate(ValidateEventArgsBase e, string country_code_id)
        {
            var record = LoadRow(country_code_id);
            
            if (record == null)
            {
                e.Remark = $"Country code {country_code_id} is unknown.";
                return;
            }

            e.Remark = record.Name;
            e.IsValid = true;
        }
    }
}
