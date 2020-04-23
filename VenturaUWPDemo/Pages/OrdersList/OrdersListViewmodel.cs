using Demo.VenturaRecordsets;
using Ventura;

namespace Demo.Pages
{
    public class OrdersListViewmodel : ViewmodelBase
    {
        public enum ModeKind
        {
            List,
            Lookup
        }

        public ModeKind ModelMode { get; }

        public OrdersListViewmodel(ModeKind mode)
        {
            ModelMode = mode;
        }


    }
}
