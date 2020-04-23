using Demo.VenturaRecordsets;
using Ventura;

namespace Demo.Pages
{
    public class CustomersListViewmodel : ViewmodelBase
    {
        public enum ModeKind { List, Lookup }

        public ModeKind ModelMode { get; }

        public CustomersListViewmodel(ModeKind mode)
        {
            ModelMode = mode;
        }

        public long? Input_CustomerID { get; set; } = null;


    }
}
