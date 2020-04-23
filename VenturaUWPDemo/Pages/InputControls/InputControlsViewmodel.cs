using Demo.VenturaAutoCreate;
using Demo.VenturaRecordsets;
using System;
using Ventura;
using Ventura.Helpers;

namespace Demo.Pages
{
    public class InputControlsViewmodel : ViewmodelBase
    {

        public InputControlsViewmodel()
        {
            this.FieldString = "One Giant Leap For Mankind";

            this.FieldDateTime = new DateTime(1969, 7, 20);
            this.FieldDateTimeNullable = this.FieldDateTime;

            this.FieldInt64 = 11;
            this.FieldInt64Nullable = this.FieldInt64;

            this.FieldDecimal = 9876543.21m;
            this.FieldDecimalNullable = this.FieldDecimal;

            this.FieldSingle = 12.34f;
            this.FieldSingleNullable = this.FieldSingle;

            this.FieldDouble = 33.44d;
            this.FieldDoubleNullable = this.FieldDouble;

        }



        public string FieldString
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime FieldDateTime
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public DateTime? FieldDateTimeNullable
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public long FieldInt64
        {
            get { return GetValue<long>(); }
            set { SetValue(value); }
        }

        public long? FieldInt64Nullable
        {
            get { return GetValue<long?>(); }
            set { SetValue(value); }
        }

        public decimal FieldDecimal
        {
            get { return GetValue<decimal>(); }
            set { SetValue(value); }
        }

        public decimal? FieldDecimalNullable
        {
            get { return GetValue<decimal?>(); }
            set { SetValue(value); }
        }

        public Single FieldSingle
        {
            get { return GetValue<Single>(); }
            set { SetValue(value); }
        }

        public Single? FieldSingleNullable
        {
            get { return GetValue<Single?>(); }
            set { SetValue(value); }
        }

        public Double FieldDouble
        {
            get { return GetValue<Double>(); }
            set { SetValue(value); }
        }

        public Double? FieldDoubleNullable
        {
            get { return GetValue<Double?>(); }
            set { SetValue(value); }
        }
    }
}
