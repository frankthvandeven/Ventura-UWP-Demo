using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Ventura.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ventura.Controls
{
    public sealed partial class HyperGridHeader : UserControl
    {
        // Statics

        public static DependencyProperty ItemsSourceProperty { private set; get; }

        static HyperGridHeader()
        {
            ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource),
                typeof(object), typeof(HyperGridHeader),
                new PropertyMetadata(null, OnItemsSourcePropertyChanged));
        }

        private static void OnItemsSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as HyperGridHeader).OnItemsSourcePropertyChanged(args);
        }



        private void OnItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            List<HeaderDefinition> columndefinitions = args.NewValue as List<HeaderDefinition>;

            if (columndefinitions == null)
                throw new Exception("ItemsSource must be of type List<HeaderDefinition>");

            if (columndefinitions.Count > 0)
                columndefinitions[0].LeftLineVisibility = Visibility.Collapsed;
        }


        // DP <-> Property

        public object ItemsSource
        {
            set { SetValue(ItemsSourceProperty, value); }
            get { return (object)GetValue(ItemsSourceProperty); }
        }

        // The rest...

        public HyperGridHeader()
        {
            this.InitializeComponent();
        }

    }
}
