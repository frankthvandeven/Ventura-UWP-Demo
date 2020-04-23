using Windows.Foundation;

namespace Ventura.Controls
{

    public class MenuItem
    {
        public event TypedEventHandler<object, MenuItem> Click;

        public string Caption { get; set; }

        internal void RaiseClickEvent(object sender)
        {
            Click?.Invoke(sender, this);
        }

    }
}
