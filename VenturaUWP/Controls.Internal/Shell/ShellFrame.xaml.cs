using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Ventura.Helpers;
using Ventura.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Ventura.Shell;
using System.Collections.ObjectModel;

namespace Ventura.Controls
{
    public sealed partial class ShellFrame : UserControl
    {
        // statics

        private static ShellFrame _instance;

        public static ShellFrame Instance
        {
            get { return _instance; }
        }

        public static DependencyProperty MenuBarProperty { private set; get; }

        static ShellFrame()
        {
            MenuBarProperty = DependencyProperty.Register(nameof(MenuBar),
                typeof(ObservableCollection<MenubarItem>), typeof(ShellFrame),
                new PropertyMetadata(null));
        }

        // Property to GetValue/SetValue 

        public ObservableCollection<MenubarItem> MenuBar
        {
            get { return (ObservableCollection<MenubarItem>)this.GetValue(MenuBarProperty); }
        }

        // Regular control code

        private bool _splitscreen;
        private ShellData _shell_data;
        private ColumnDefinition[] _column_definitions;

        private FullScreenHelper _fullScreen;

        public ShellFrame()
        {
            SetValue(MenuBarProperty, Repository.MenuBarItems);

            _instance = this;

            _splitscreen = false;

            _shell_data = Navigator.ShellData;

            this.InitializeComponent();

            // The Main Window gets a custom title bar.
            InitializeCustomTitlebar();

            tabbed_frame0.DataContext = _shell_data.Frames[0];
            tabbed_frame1.DataContext = _shell_data.Frames[1];

            // Save column definitions
            _column_definitions = grid_with_a_split.ColumnDefinitions.ToArray();

            // Clear the column definitions
            grid_with_a_split.ColumnDefinitions.Clear();

            _fullScreen = new FullScreenHelper();

            NavigationBarControl.DisplayMenuPanel += NavigationBar_DisplayMenuPanel;
            NavigationBarControl.HideMenuPanel += NavigationBar_HideMenuPanel;

            WorkSpaceGrid.AddHandler(UIElement.TappedEvent, new TappedEventHandler(WorkSpaceGrid_Tapped), true);
            WorkSpaceGrid.SizeChanged += WorkSpaceGrid_SizeChanged;

            _shell_data.PropertyChanged += ShellData_PropertyChanged;

            this.Loaded += ShellFrame_Loaded;
        }

        private void ShellData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SplitScreen")
            {
                this.SplitScreen = _shell_data.SplitScreen;
            }

        }

        private void ShellFrame_Loaded(object sender, RoutedEventArgs e)
        {
            Navigator.ShellData.ActiveFrameIndex = 0;
        }

        private void WorkSpaceGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Close the MenuPanel when the size of grid changes.
            NavigationBarControl.CloseMenuPanel();

            ClipHelper.SizeChanged(sender, e);
        }

        public ShellData ShellData
        {
            get { return _shell_data; }
        }

        public bool SplitScreen
        {
            get { return _splitscreen; }
            internal set
            {
                if (_splitscreen == value) return;

                if (value == false && ShellData.Frames[1].Tabs.Count > 0)
                {
                    throw new Exception("Closing the right frame of a splitscreen that still has tabs open is not allowed.");
                }

                _splitscreen = value;

                grid_with_a_split.ColumnDefinitions.Clear();
                tabbed_frame0.ClearValue(Grid.ColumnProperty);
                grid_splitter.ClearValue(Grid.ColumnProperty);
                tabbed_frame1.ClearValue(Grid.ColumnProperty);

                grid_splitter.Visibility = Visibility.Collapsed;
                tabbed_frame1.Visibility = Visibility.Collapsed;

                if (_splitscreen == true)
                {
                    foreach (var col in _column_definitions)
                        grid_with_a_split.ColumnDefinitions.Add(col);

                    tabbed_frame0.SetValue(Grid.ColumnProperty, 0);
                    grid_splitter.SetValue(Grid.ColumnProperty, 1);
                    tabbed_frame1.SetValue(Grid.ColumnProperty, 2);

                    grid_splitter.Visibility = Visibility.Visible;
                    tabbed_frame1.Visibility = Visibility.Visible;
                }

                _shell_data.SplitScreen = value;
            }
        }

        public event RoutedEventHandler SettingsButtonClick;

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsButtonClick?.Invoke(sender, e);
        }

        private void BtnToggleFullscreen_Click(object sender, RoutedEventArgs e)
        {
            _fullScreen.ToggleFullscreen();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            //slidePanel.Visibility = Visibility.Visible;
        }

        private void SlidePanel_BackdropTapped(object sender, EventArgs e)
        {
            //slidePanel.Visibility = Visibility.Collapsed;
        }


    }
}
