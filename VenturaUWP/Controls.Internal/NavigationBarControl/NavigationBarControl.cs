using System;
using Ventura.Helpers;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Ventura.Controls
{

    //[Bindable]
    public class NavigationBarControl : ItemsControl
    {
        public event TypedEventHandler<NavigationBarControl, MenubarItem> DisplayMenuPanel;
        public event Action HideMenuPanel;
        public NavigationBarControl()
        {
            DefaultStyleKey = typeof(NavigationBarControl);

        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new NavigationBarItem();
        }

        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            base.OnPointerPressed(e);

            NavigationBarItem element = VenturaVisualTreeHelper.FindParent<NavigationBarItem>(e.OriginalSource as DependencyObject);

            if (element != null)
            {
                MenubarItem item = (MenubarItem)element.DataContext;

                bool was_dropped = element.IsDroppedDown;

                SetAllChildrenAsNotDropped();

                if (was_dropped == false)
                {
                    element.IsDroppedDown = true;
                    DisplayMenuPanel?.Invoke(this, item);
                }
                else
                    HideMenuPanel?.Invoke();

            }
        }

        public void CloseMenuPanel()
        {
            SetAllChildrenAsNotDropped();
            HideMenuPanel?.Invoke();
        }

        private void SetAllChildrenAsNotDropped()
        {
            foreach (var listitem in this.Items)
            {
                MenubarItem item = (MenubarItem)listitem;
                NavigationBarItem element = (NavigationBarItem)ContainerFromItem(item);

                element.IsDroppedDown = false;
            }
        }

    }
}

