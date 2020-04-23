using System;
using Ventura.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.Foundation;

namespace Ventura.Controls
{

    // Public Enum TNButtonRSLinkMode
    // tnBTLMRecordSelected = 1
    // tnBTLMRecordsToSave = 2
    // End Enum

    [ContentProperty(Name = "ItemTemplate")]
    public class HyperGrid : Control
    {
        // Statics for fast resource data access
        public static double GridFontSize = (double)Application.Current.Resources["GridFontSize"];
        public static Brush GridLineBrush = (Brush)Application.Current.Resources["GridLineBrush"];
        public static double GridLineWidth = (double)Application.Current.Resources["GridLineWidth"];

        // Statics

        public static DependencyProperty ItemsSourceProperty { private set; get; }
        public static DependencyProperty ItemTemplateProperty { private set; get; }
        public static DependencyProperty SelectedIndexProperty { private set; get; }
        public static DependencyProperty SelectedItemProperty { private set; get; }
        public static DependencyProperty SelectionModeProperty { private set; get; }
        public static DependencyProperty IsItemSelectedProperty { private set; get; }
        public static DependencyProperty HeaderProperty { private set; get; }

        static HyperGrid()
        {
            ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource),
                typeof(object), typeof(HyperGrid),
                new PropertyMetadata(null, OnItemsSourcePropertyChanged));

            ItemTemplateProperty = DependencyProperty.Register(nameof(ItemTemplate),
                typeof(DataTemplate), typeof(HyperGrid),
                new PropertyMetadata(null, OnItemTemplatePropertyChanged));

            SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem),
                typeof(object), typeof(HyperGrid),
                new PropertyMetadata(null, OnSelectedItemPropertyChanged));

            SelectedIndexProperty = DependencyProperty.Register(nameof(SelectedIndex),
                typeof(int), typeof(HyperGrid),
                new PropertyMetadata(-1, OnSelectedIndexPropertyChanged));

            SelectionModeProperty = DependencyProperty.Register(nameof(SelectionMode),
                typeof(ListViewSelectionMode), typeof(HyperGrid),
                new PropertyMetadata(ListViewSelectionMode.Single));

            IsItemSelectedProperty = DependencyProperty.Register(nameof(IsItemSelected),
                typeof(bool), typeof(HyperGrid),
                new PropertyMetadata(false));

            HeaderProperty = DependencyProperty.Register(nameof(Header),
                typeof(List<HeaderDefinition>), typeof(HyperGrid), 
                new PropertyMetadata(null));

            // Sample of CreateDefaultValueCallback:
            // HeaderProperty = DependencyProperty.Register(nameof(Header),
            // typeof(List<HeaderDefinition>), typeof(HyperGrid),
            // PropertyMetadata.Create(new CreateDefaultValueCallback(() =>
            // {
            //    return new List<HeaderDefinition>();
            // })));

        }

        private static void OnItemsSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as HyperGrid).OnItemsSourcePropertyChanged(args);
        }

        private void OnItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnItemTemplatePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as HyperGrid).OnItemTemplatePropertyChanged(args);
        }

        private void OnItemTemplatePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnSelectedItemPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as HyperGrid).OnSelectedItemPropertyChanged(args);
        }

        private void OnSelectedItemPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            if (_initialized == false)
                return;

            if (_inside_lv_propertychanged == true)
                return;

            _ListView.SelectedItem = args.NewValue;

            ScrollSelectedIntoView();
        }

        private static void OnSelectedIndexPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as HyperGrid).OnSelectedIndexPropertyChanged(args);
        }

        private void OnSelectedIndexPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            if (_initialized == false)
                return;

            if (_inside_lv_propertychanged == true)
                return;

            _ListView.SelectedIndex = (int)args.NewValue;

            ScrollSelectedIntoView();
        }

        #region DP <-> Property

        /// <summary>
        /// Gets or sets a collection that is used to generate the content of the control.
        /// </summary>
        public object ItemsSource
        {
            set { SetValue(ItemsSourceProperty, value); }
            get { return (object)GetValue(ItemsSourceProperty); }
        }

        public DataTemplate ItemTemplate
        {
            set { SetValue(ItemTemplateProperty, value); }
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        }

        /// <summary>
        /// Gets or sets the index of the current selection.
        /// </summary>
        /// <returns>The index of the current selection, or -1 if the selection is empty.</returns>
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        /// <summary>
        /// Gets or sets the data item corresponding to the selected row.
        /// </summary>
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty) as object; }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selection behavior of the ListView.
        /// </summary>
        public ListViewSelectionMode SelectionMode
        {
            get { return (ListViewSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        /// <summary>
        /// Returns true if one or multiple rows are selected.
        /// </summary>
        public bool IsItemSelected
        {
            get { return (bool)GetValue(IsItemSelectedProperty); }
            set { SetValue(IsItemSelectedProperty, value); }
        }

        public List<HeaderDefinition> Header
        {
            get { return (List<HeaderDefinition>)GetValue(HeaderProperty); }
        }

        #endregion

        // The rest...

        public event EventHandler<RowClickedEventArgs> RowClicked;
        //public event EventHandler<RowDoubleClickedEventArgs> RowDoubleClicked;
        public event EventHandler<RowRightClickedEventArgs> RowRightClicked;

        public event RoutedEventHandler RowDoubleClick;

        public HyperGrid()
        {
            DefaultStyleKey = typeof(HyperGrid);

            this.SetValue(HeaderProperty, new List<HeaderDefinition>());
        }

        bool _initialized = false;

        private ScrollViewer _HeaderScrollViewer;
        private HyperGridHeader _HyperGridHeader;
        private Grid _MainGrid;
        private ListView _ListView;
        private ScrollViewer _scrollviewer;
        //ContentPresenter _presenter;


        // https://stackoverflow.com/questions/1517743/in-wpf-how-can-i-determine-whether-a-control-is-visible-to-the-user

        protected override void OnApplyTemplate()
        {
            if (_initialized) throw new System.Exception("only call once");

            base.OnApplyTemplate();

            ScrutinizeItemTemplate();

            _HeaderScrollViewer = (ScrollViewer)GetTemplateChild("HeaderScrollViewer");

            _HyperGridHeader = (HyperGridHeader)GetTemplateChild("HeaderControl");
            _HyperGridHeader.ItemsSource = this.Header;

            _MainGrid = (Grid)GetTemplateChild("MainGrid");
            //_MainGrid.SizeChanged += MainGrid_SizeChanged;

            _ListView = (ListView)GetTemplateChild("ListView");

            // Force the ListView to load it's template, so we can get a reference to the scrollviewer.
            _ListView.ApplyTemplate();

            _scrollviewer = VenturaVisualTreeHelper.FindDescendant<ScrollViewer>(_ListView); ;
            _scrollviewer.ViewChanged += ScrollViewer_ViewChanged;
            _ListView.SelectionChanged += ListView_SelectionChanged;
            //_ListView.PointerPressed += ListView_PointerPressed;
            _ListView.DoubleTapped += ListView_DoubleTapped;

            _ListView.SelectedIndex = this.SelectedIndex;

            _ListView.RegisterPropertyChangedCallback(ListView.SelectedItemProperty, new DependencyPropertyChangedCallback(ListView_SelectedItem_PropertyChanged));

            //// Bind HyperGrid.SelectedIndex to _ListView.SelectedIndex etc...
            //Binding b1 = new Binding { Source = this, Path = new PropertyPath("SelectedIndex"), Mode = BindingMode.TwoWay };
            //Binding b2 = new Binding { Source = this, Path = new PropertyPath("SelectedItem"), Mode = BindingMode.TwoWay };
            //_ListView.SetBinding(ListView.SelectedIndexProperty, b1);
            //_ListView.SetBinding(ListView.SelectedItemProperty, b2);

            _initialized = true;
        }

        // Note by Frank on 19 March 2019:
        //
        // ListView.SelectedItem and ListView.SelectedIndex are guaranteed to be synchronized by UWP.
        // You can rely on that. 

        // The ListView.SelectedItem changes because of user-interaction (mouse, keyboard etc.)

        private bool _inside_lv_propertychanged = false;

        private void ListView_SelectedItem_PropertyChanged(DependencyObject obj, DependencyProperty pr)
        {
            _inside_lv_propertychanged = true;

            this.SelectedItem = _ListView.SelectedItem;
            this.SelectedIndex = _ListView.SelectedIndex;

            _inside_lv_propertychanged = false;
        }

        /// <summary>
        /// Makes the the selected item is scolled into view.
        /// </summary>
        public void ScrollSelectedIntoView()
        {
            object data = _ListView.SelectedItem;

            if (data == null)
                return;

            ListViewItem element = (ListViewItem)_ListView.ContainerFromItem(_ListView.SelectedItem);

            // ContainerFromItem can return null when the Layout pass was not completed yet.
            if (element == null)
            {
                // Force the layout pass.
                _ListView.UpdateLayout();
                element = (ListViewItem)_ListView.ContainerFromItem(_ListView.SelectedItem);
            }

            bool visible_to_user = false;

            if (element != null)
            {
                visible_to_user = IsVisibleToUser(element, _ListView);
            }

            if (visible_to_user == false)
            {
                _ListView.ScrollIntoView(data, ScrollIntoViewAlignment.Leading); // data was element
            }

        }

        private bool IsVisibleToUser(FrameworkElement element, FrameworkElement container)
        {
            //bool fully_visible = true;

            if (element == null || container == null)
                return false;

            if (element.Visibility != Visibility.Visible)
                return false;

            Rect elementBounds = element.TransformToVisual(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect containerBounds = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);

            //if (fully_visible == true)
            //    return containerBounds.Contains(elementBounds);

            return (elementBounds.Top < containerBounds.Bottom && elementBounds.Bottom > containerBounds.Top);
        }

        private void ScrutinizeItemTemplate()
        {
            if (ItemTemplate == null)
                throw new Exception("You need to set the ItemTemplate (DataTemplate) property.");

            var root = this.ItemTemplate.LoadContent() as HyperGridPanel;

            if (root == null)
                throw new Exception("The ItemTemplate (DataTemplate) root must be of type HyperGridPanel.");

            if (root.Children.Count == 0)
                throw new Exception("The HyperGridPanel should contain at least 1 child element.");

            if (root.Children.Count != this.Header.Count)
                throw new Exception($"The number of Header elements ({this.Header.Count}) must match the number of HyperGridPanel children ({root.Children.Count}).");

            for (int i = 0; i < this.Header.Count; i++)
            {
                FrameworkElement element = (FrameworkElement)root.Children[i];

                double element_width = element.Width;

                if (double.IsNaN(element_width) == true)
                    throw new Exception("It is obligated to set the Width property of each child in the root of HyperGridPanel.");

                this.Header[i].Width = element_width;
            }

        }

        //private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    ClipHelper.SizeChanged(sender, e);
        //}

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            _HeaderScrollViewer.ChangeView(_scrollviewer.HorizontalOffset, null, null, true);
            //_HyperGridHeader.RenderTransform = new TranslateTransform { X = -(_scrollviewer.HorizontalOffset), Y = 0 };
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var added = e.AddedItems.Count;
            var removed = e.RemovedItems.Count;

            //var sele = _ListView.SelectedItems.Count;
            //Debug.WriteLine($"added{added} removed{removed} totalselected{sele}.");

            //if (this.SelectedIndex != _ListView.SelectedIndex)
            //    this.SelectedIndex = _ListView.SelectedIndex;

            //if (this.SelectedItem != _ListView.SelectedItem)
            //    this.SelectedItem = _ListView.SelectedItem;

            bool is_selected = (_ListView.SelectedItems.Count > 0);

            // Used to enable buttons.
            if (this.IsItemSelected != is_selected)
                this.IsItemSelected = is_selected;

        }


        #region Properties
        /// <summary>
        /// Gets a list that contains the data items corresponding to the selected rows.
        /// </summary>
        public IList<object> SelectedItems
        {
            get
            {
                if (_ListView == null) // _DataGrid not initialized yet.
                    return null;

                return _ListView.SelectedItems;
            }
        }

        public ListView ListViewControl
        {
            get { return _ListView; }
        }

        #endregion

        #region EVENTS

        /* Ideas:
         * 
         * RowPressed : As discussed above. Indicates a row has been pressed so further processing or context menu's can occur.
         * RowDoublePressed : Same as RowPressed, just the double click version.
         * ColumnHeaderPressed : Occurs whenever a column header is pressed. 
             Must take priority over any sort direction internal updates.
             This will allow for custom filtering menus or right click options to turn on/off columns.
         * ColumnHeaderDoublePressed : Same as ColumnHeaderPressed, just the double click version.
         * ColumnHeaderWidthChanged : Occurs whenever the user resizes a column header width. 
             This will allow for saving this information in a clean way. This is commonly needed when restoring UI state.
         */

        private void ListView_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            /*
            PointerPoint point = e.GetCurrentPoint(_ListView);

            DataGridRow pressed_row = VenturaVisualTreeHelper.FindParent<DataGridRow>(e.OriginalSource as DependencyObject);

            if (pressed_row == null)
                return;

            var event_args = new RowClickedEventArgs();

            event_args.ItemIndex = pressed_row.GetIndex();
            event_args.Item = pressed_row.DataContext;

            //MenuFlyout flyout;

            if (point.Properties.IsRightButtonPressed)
            {
                var right_event_args = new RowRightClickedEventArgs();
                right_event_args.ItemIndex = event_args.ItemIndex;
                right_event_args.Item = event_args.Item;

                // Select the row
                try
                {
                    //_DataGrid.SelectedItems.Clear();
                    //_DataGrid.SelectedItems.Add(pressed_row.DataContext);
                }
                catch { }

                //    // Open the context menu flyout
                //    try
                //    {
                //        flyout = new MenuFlyout(); // Do other stuff here
                //        flyout.ShowAt(dataGrid, point.Position);
                //    }
                //    catch { }

                RowRightClicked?.Invoke(this, right_event_args);

                return;
            }

            RowClicked?.Invoke(this, event_args);
            */

        }

        private void ListView_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            //var aa = VenturaVisualTreeHelper.FindParent<HyperGridPanel>(e.OriginalSource as DependencyObject);

            ListViewItem pressed_row = VenturaVisualTreeHelper.FindParent<ListViewItem>(e.OriginalSource as DependencyObject);

            if (pressed_row == null)
                return;

            //var event_args = new RowDoubleClickedEventArgs
            //{
            //    ItemIndex = -1, // pressed_row.GetIndex();
            //    Item = pressed_row.Content // pressed_row.DataContext;
            //};

            //RowDoubleClicked?.Invoke(this, event_args);
            RowDoubleClick?.Invoke(this, new RoutedEventArgs());
        }

        #endregion EVENTS

    }

}
