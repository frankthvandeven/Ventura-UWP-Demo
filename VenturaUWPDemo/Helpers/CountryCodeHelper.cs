using Demo.VenturaAutoCreate;
using Ventura.Controls;

namespace Demo.Helpers
{
    public static class CustomerIdHelper
    {

        public static PriKey_Customers_Record LoadRow(long customer_id)
        {
            var recordset = new PriKey_Customers_Recordset();

            recordset.ExecSql(customer_id);

            if (recordset.RecordCount == 0)
                return null;

            return recordset.CurrentRecord;
        }

        public static bool Exists(long customer_id)
        {
            var record = LoadRow(customer_id);

            if (record == null)
                return false;

            return true;
        }

        // [error] [warning]
        public static void Validate(ValidateEventArgsBase e, long customer_id)
        {
            var record = LoadRow(customer_id);
            
            if (record == null)
            {
                e.Remark = $"Customer ID {customer_id} is unknown.";
                return;
            }

            e.Remark = record.FirstName + " " + record.LastName;
            e.IsValid = true;
        }
    }
}
