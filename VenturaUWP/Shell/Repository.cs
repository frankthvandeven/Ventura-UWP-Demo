using System.Collections.ObjectModel;
using Ventura.Controls;

namespace Ventura.Shell
{
    public static class Repository
    {
        private static ObservableCollection<MenubarItem> _menu_bar_items; 

        static Repository()
        {
            _menu_bar_items = new ObservableCollection<MenubarItem>();
        }

        public static ObservableCollection<MenubarItem> MenuBarItems
        {
            get { return _menu_bar_items; }
        }


    }
}
