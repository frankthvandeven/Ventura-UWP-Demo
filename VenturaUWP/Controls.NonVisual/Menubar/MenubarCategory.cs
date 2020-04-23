using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Ventura.Controls
{

    [ContentProperty(Name = "MenuItems")]
    public class MenubarCategory : DependencyObject
    {
        // Statics

        public static DependencyProperty MenuItemsProperty { private set; get; }

        static MenubarCategory()
        {
            MenuItemsProperty = DependencyProperty.Register(nameof(MenuItems),
                typeof(List<MenuItem>), typeof(MenubarCategory),
                new PropertyMetadata(null));
        }

        public MenubarCategory()
        {
            SetValue(MenuItemsProperty, new List<MenuItem>());
        }

        public List<MenuItem> MenuItems
        {
            get { return (List<MenuItem>)GetValue(MenuItemsProperty); }
        }

        // the rest
        public string Caption { get; set; }

    }
}
