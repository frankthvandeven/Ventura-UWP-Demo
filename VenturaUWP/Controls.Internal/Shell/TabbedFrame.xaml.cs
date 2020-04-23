using Ventura.Navigation;
using Ventura.Shell;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Ventura.Controls
{
    
    public sealed partial class TabbedFrame : UserControl
    {
        // Statics for fast resource data access
        public static Color VenturaOrangeColor = (Color)Application.Current.Resources["VenturaOrangeColor"];
        public static Color VenturaGrayDark1Color = (Color)Application.Current.Resources["VenturaGrayDark1Color"];

        public static DependencyProperty ViewModelProperty { private set; get; }

        static TabbedFrame()
        {
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(FrameData), typeof(TabbedFrame), new PropertyMetadata(null, OnViewModelPropertyChanged));
        }

        private static void OnViewModelPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as TabbedFrame).OnViewModelPropertyChanged(args);
        }

        private void OnViewModelPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            var old_viewmodel = args.OldValue as FrameData;
            var new_viewmodel = args.NewValue as FrameData;

            if (old_viewmodel != null)
            {
                old_viewmodel.ShelvePageEvent -= FrameData_ShelvePageEvent;
                old_viewmodel.DisplayAnotherPageEvent -= FrameData_DisplayAnotherPageEvent;
                old_viewmodel.FrameActivatedEvent -= FrameData_FrameActivatedEvent;
                old_viewmodel.FrameDeActivatedEvent -= FrameData_FrameDeActivatedEvent;
            }

            if (new_viewmodel != null)
            {
                new_viewmodel.ShelvePageEvent += FrameData_ShelvePageEvent;
                new_viewmodel.DisplayAnotherPageEvent += FrameData_DisplayAnotherPageEvent;
                new_viewmodel.FrameActivatedEvent += FrameData_FrameActivatedEvent;
                new_viewmodel.FrameDeActivatedEvent += FrameData_FrameDeActivatedEvent;
            }
        }

        // Property to GetValue/SetValue 

        /// <summary>
        /// The Viewmodel is of type FrameData.
        /// </summary>
        public FrameData ViewModel
        {
            get { return (FrameData)this.GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // The rest...

        public TabbedFrame()
        {
            this.InitializeComponent();

            this.RootGrid.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(RootGrid_PointerPressed), true);
            this.TabStrip.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(TabStrip_PointerPressed), true);

            // Note, VisualStateManager.GoToState() has no effect when called from constructor. Use Loaded event instead.
        }


        private void FrameData_FrameActivatedEvent()
        {
            Update_ActivationRectangle_Color();

            if (ViewModel.SelectedTab != null)
            {
                SmartPage topmost_page = ViewModel.SelectedTab.TopMost();

                if (topmost_page != null)
                    topmost_page.InternalActivate();
            }
        }

        private void FrameData_FrameDeActivatedEvent()
        {
            Update_ActivationRectangle_Color();

            if (ViewModel.SelectedTab != null)
            {
                SmartPage topmost_page = ViewModel.SelectedTab.TopMost();

                if (topmost_page != null)
                    topmost_page.InternalDeActivate();
            }
        }

        private void FrameData_ShelvePageEvent(SmartPage page)
        {
            page.InternalDeActivate();

            if (Presenter.Content != null && Presenter.Content.Equals(page))
                Presenter.Content = null;
        }


        private void FrameData_DisplayAnotherPageEvent(FrameData.PageDisplayReason reason, SmartPage page)
        {
            if (Presenter.Content != null && Presenter.Content.Equals(page))
                return; // content already set. nothing to do.

            if (reason == FrameData.PageDisplayReason.TabSelect)
                Update_ActivationRectangle_Color();

            // Page can be null.

            if (page != null)
                page.Loaded += ChainInto_Page_Loaded;

            Presenter.Content = page; // This will cause the page.Loaded event to be fired. 
        }

        // This event is called and then unhooked.
        private void ChainInto_Page_Loaded(object sender, RoutedEventArgs e)
        {
            SmartPage page = (SmartPage)sender;

            page.Loaded -= ChainInto_Page_Loaded;

            page.InternalPageOpened();

            if (ViewModel.IsActivated)
                page.InternalActivate();
        }

        //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => topmost_page.InternalActivate());

        public void Update_ActivationRectangle_Color()
        {
            Color color_target = TabbedFrame.VenturaGrayDark1Color;

            if (ViewModel.IsActivated == true)
            {
                // The default active color is VenturaOrange
                color_target = TabbedFrame.VenturaOrangeColor;

                if (ViewModel.SelectedTab != null)
                    color_target = ViewModel.SelectedTab.ColorInfo.BackgroundColor;
            }

            if (ColorAnimation.To != color_target)
            {
                ColorAnimation.To = color_target;
                ColorStoryBoard.Begin();
            }
        }

        private void RootGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Navigator.ShellData.ActiveFrameIndex = ViewModel.Index;
        }

        /// <summary>
        /// We want to select a TabItem as soon as the mouse button goes down.
        /// </summary>
        private void TabStrip_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement element = e.OriginalSource as FrameworkElement;

            if (element == null) return;

            TabData tabdata = element.DataContext as TabData;

            if (tabdata == null) return;

            ViewModel.SelectedTab = tabdata;
        }


    }
}

