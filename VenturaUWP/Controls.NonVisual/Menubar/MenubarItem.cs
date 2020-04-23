using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Ventura.Controls
{

    [ContentProperty(Name = "Categories")]
    public class MenubarItem : DependencyObject
    {
        // Statics

        public static DependencyProperty CategoriesProperty { private set; get; }

        static MenubarItem()
        {
            CategoriesProperty = DependencyProperty.Register(nameof(Categories),
                typeof(List<MenubarCategory>), typeof(MenubarItem),
                new PropertyMetadata(null));

        }

        public MenubarItem()
        {
            SetValue(CategoriesProperty, new List<MenubarCategory>());
        }

        public List<MenubarCategory> Categories
        {
            get { return (List<MenubarCategory>)GetValue(CategoriesProperty); }
        }

        public string Caption { get; set; }

    }
}
