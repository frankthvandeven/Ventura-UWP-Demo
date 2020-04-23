using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Ventura.Navigation;
using Ventura.Shell;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {
        // statics

        public static DependencyProperty IsModalProperty { get; }
        public static DependencyProperty PageCaptionProperty { private set; get; }
        public static DependencyProperty CloseButtonCaptionProperty { private set; get; }
        public static DependencyProperty MenuBarProperty { private set; get; }
        public static DependencyProperty ButtonsProperty { private set; get; }

        static SmartPage()
        {
            // https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/dependency-properties-overview
            // Collection properties aren't typically implemented as dependency properties, 

            IsModalProperty = DependencyProperty.Register(nameof(IsModal),
                typeof(bool), typeof(SmartPage),
                new PropertyMetadata(false, OnIsModalPropertyChanged));

            PageCaptionProperty = DependencyProperty.Register(nameof(PageCaption),
                typeof(string), typeof(SmartPage),
                new PropertyMetadata("your caption here", OnPageCaptionPropertyChanged));

            CloseButtonCaptionProperty = DependencyProperty.Register(nameof(CloseButtonCaption),
                typeof(string), typeof(SmartPage),
                new PropertyMetadata("Close", OnCloseButtonCaptionPropertyChanged));

            MenuBarProperty = DependencyProperty.Register(nameof(MenuBar),
                typeof(ObservableCollection<MenubarItem>), typeof(SmartPage),
                new PropertyMetadata(null));

            ButtonsProperty = DependencyProperty.Register(nameof(Buttons),
                typeof(ObservableCollection<ISmartButton>), typeof(SmartPage),
                new PropertyMetadata(null));

        }

        private static void OnIsModalPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as SmartPage).OnIsModalPropertyChanged(args);
        }

        private void OnIsModalPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetCloseButton();
        }

        private static void OnPageCaptionPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as SmartPage).OnPageCaptionPropertyChanged(args);
        }

        private void OnPageCaptionPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ShellData shell_data = Navigator.ShellData;

            if (shell_data.ManagesSmartPage(this) == false)
                return;

            // Since the PageData was found, we are 100% sure the FrameData and TabData will also be found.

            TabData tabdata = shell_data.FindTabData(this);

            tabdata.RefreshBreadCrumb();
        }

        private static void OnCloseButtonCaptionPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as SmartPage).OnCloseButtonCaptionPropertyChanged(args);
        }

        private void OnCloseButtonCaptionPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            ResetCloseButton();
        }

        // Property to GetValue/SetValue 

        public bool IsModal
        {
            get { return (bool)this.GetValue(IsModalProperty); }
            set { SetValue(IsModalProperty, value); }
        }

        public string PageCaption
        {
            get { return (string)this.GetValue(PageCaptionProperty); }
            set { SetValue(PageCaptionProperty, value); }
        }

        public string CloseButtonCaption
        {
            get { return (string)this.GetValue(CloseButtonCaptionProperty); }
            set { SetValue(CloseButtonCaptionProperty, value); }
        }

        public ObservableCollection<MenubarItem> MenuBar
        {
            get { return (ObservableCollection<MenubarItem>)GetValue(MenuBarProperty); }
        }

        public ObservableCollection<ISmartButton> Buttons
        {
            get { return (ObservableCollection<ISmartButton>)GetValue(ButtonsProperty); }
        }

        // The rest......
        //public event RoutedEventHandler FirstTimeLoaded;
        public event RoutedEventHandler CloseButtonClick;

        // Properties for closing the page
        internal CloseActionKind CloseAction = CloseActionKind.CloseTab;
        internal TaskCompletionSource<object> TCS = null;
        internal string InstanceID = null;

        // Regular properties
        private bool _is_opened;
        private bool _is_activated;

        private bool _page_opened_was_called = false;

        public SmartPage()
        {
            DefaultStyleKey = typeof(SmartPage);

            _is_opened = false;
            _is_activated = false;

            SetValue(MenuBarProperty, new ObservableCollection<MenubarItem>());
            SetValue(ButtonsProperty, new ObservableCollection<ISmartButton>());

        }

        private bool _init = false;
        private ButtonBar _buttonbar;
        private SmartButton _integrated_closebutton;

        protected override void OnApplyTemplate()
        {
            if (_init)
                throw new Exception("re-templating not allowed");

            base.OnApplyTemplate();

            _buttonbar = (ButtonBar)GetTemplateChild("ButtonBar");

            // Create the integrated close button.
            _integrated_closebutton = new SmartButton();
            _integrated_closebutton.Label = "Close";
            _integrated_closebutton.PathData = ButtonCloseTab.IconString;
            _integrated_closebutton.Click += ButtonClose_Click;

            // Add the integrated close button to the buttonbar at the top of the page.
            this.Buttons.Add(_integrated_closebutton);

            // Hook up the top buttons collection to the ButtonBar.
            _buttonbar.ItemsSource = this.Buttons;


            _init = true;

            ResetCloseButton();

        }

        private void ResetCloseButton()
        {
            if (_init == false)
                return;

            _integrated_closebutton.Label = this.CloseButtonCaption;

            if (this.IsModal == true)
                _integrated_closebutton.PathData = ButtonClose.IconString;
            else
                _integrated_closebutton.PathData = ButtonCloseTab.IconString;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (CloseButtonClick == null)
            {
                this.ClosePage(null);
                return;
            }

            CloseButtonClick.Invoke(sender, e);
        }

        internal void InternalPageOpened()
        {
            if (_is_opened == true) return;

            _is_opened = true;

            Debug.WriteLine($"Opened page '{PageCaption}'");

            this.OnPageOpened();
        }

        internal void InternalActivate()
        {
            var title = this.PageCaption;

            if (_is_activated == true) return;

            _is_activated = true;

            ShellFrame.Instance.NavigationBarControl.CloseMenuPanel();

            foreach (MenubarItem item in this.MenuBar)
            {
                Repository.MenuBarItems.Add(item);
            }

            Debug.WriteLine($"Activated page '{PageCaption}'");

            this.OnActivated();
        }

        internal void InternalDeActivate()
        {
            if (_is_activated == false) return;

            _is_activated = false;

            ShellFrame.Instance.NavigationBarControl.CloseMenuPanel();

            var global_menubar = Repository.MenuBarItems;

            for (int x = global_menubar.Count - 1; x >= 0; x--)
            {
                MenubarItem item = global_menubar[x];

                if (IsLocalMenubarItem(item))
                    global_menubar.Remove(item);
            }

            Debug.WriteLine($"Deactivated page '{PageCaption}'");

            this.OnDeActivated();
        }

        private bool IsLocalMenubarItem(MenubarItem item)
        {
            foreach (var local_item in this.MenuBar)
                if (local_item.Equals(item))
                    return true;

            return false;
        }

        /// <summary>
        /// This is the virtual that sub-classes must override if they wish to get
        /// notified that the page was displayed for the first time.
        /// This is similar to a FrameworkElement.Loaded event. But it is only called once, and
        /// not every time the page is re-attached to the visual tree.
        /// </summary>
        protected virtual void OnPageOpened()
        {
        }

        /// <summary>
        /// This is the virtual that sub-classes must override if they wish to get
        /// notified when Page.Close() was called.
        /// </summary>
        //protected virtual void OnPageClosed()
        //{
        //}

        /// <summary>
        /// This is the virtual that sub-classes must override if they wish to get
        /// notified that the page was activated.
        /// </summary>
        protected virtual void OnActivated()
        {
        }

        /// <summary>
        /// This is the virtual that sub-classes must override if they wish to get
        /// notified that the page was deactivated.
        /// </summary>
        protected virtual void OnDeActivated()
        {
        }

        protected internal virtual void SatellitePageClosed(string instance_id, object retvar)
        {
        }

    }

    /// <summary>
    /// Give the contentpresenter its own type, so it can easily be found in the visual tree.
    /// </summary>
    public class SmartPagePresenter : ContentPresenter
    {
    }

}
