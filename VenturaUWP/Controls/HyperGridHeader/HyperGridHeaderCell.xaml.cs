using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class HyperGridHeaderCell : UserControl
    {
        public HyperGridHeaderCell()
        {
            this.InitializeComponent();

            this.DataContextChanged += UserControl_DataContextChanged;
        }

        private void UserControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            HeaderDefinition def = args.NewValue as HeaderDefinition;

            if (def == null)
                return;

            RectangleControl.Visibility = def.LeftLineVisibility;
            TextBlockControl.FontSize = HyperGrid.GridFontSize;
            TextBlockControl.Text = def.Caption;
            TextBlockControl.Width = def.Width;


        }
    }
}
