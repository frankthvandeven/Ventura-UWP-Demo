using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{

    public class MiniButton : Button
    {
        // Statics

        public static DependencyProperty PathDataProperty { private set; get; }
        public static DependencyProperty OuterWidthAndHeightProperty { private set; get; }
        public static DependencyProperty InnerWidthAndHeightProperty { private set; get; }


        static MiniButton()
        {
            PathDataProperty = DependencyProperty.Register(nameof(PathData),
                typeof(string), typeof(MiniButton),
                new PropertyMetadata(null, OnPathDataPropertyChanged));

            OuterWidthAndHeightProperty = DependencyProperty.Register(nameof(OuterWidthAndHeight),
                typeof(double), typeof(MiniButton),
                new PropertyMetadata(22d));

            InnerWidthAndHeightProperty = DependencyProperty.Register(nameof(InnerWidthAndHeight),
                typeof(double), typeof(MiniButton),
                new PropertyMetadata(17d));

        }

        private static void OnPathDataPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as MiniButton).OnPathDataPropertyChanged(args);
        }

        private Geometry _geometry = null;

        private void OnPathDataPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            // A Geometry is not a shareable resource. That is why a path-data string is dynamically converted to Geometry for each button instance.

            string pathdata = args.NewValue as string;

            if (pathdata == null)
                _geometry = null;
            else
                _geometry = (Geometry)XamlBindingHelper.ConvertValue(typeof(Geometry), pathdata);

            ResetControls();
        }

        // DP <-> Property

        public string PathData
        {
            set { SetValue(PathDataProperty, value); }
            get { return (string)GetValue(PathDataProperty); }
        }

        /// <summary>
        /// The dimensions of the control itself. Must be larger than InnerWidthAndHeight.
        /// </summary>
        public double OuterWidthAndHeight
        {
            set { SetValue(OuterWidthAndHeightProperty, value); }
            get { return (double)GetValue(OuterWidthAndHeightProperty); }
        }

        /// <summary>
        /// The dimensions of the Icon. Must be smaller than OuterWidthAndHeight.
        /// </summary>
        public double InnerWidthAndHeight
        {
            set { SetValue(InnerWidthAndHeightProperty, value); }
            get { return (double)GetValue(InnerWidthAndHeightProperty); }
        }

        // The rest...

        public MiniButton()
        {
            DefaultStyleKey = typeof(MiniButton);
        }

        private bool _init = false;

        private Path _iconpath;

        protected override void OnApplyTemplate()
        {
            if (_init)
                throw new InvalidOperationException("cannot re-template");

            base.OnApplyTemplate();

            _iconpath = (Path)GetTemplateChild("IconPath");

            _init = true;

            ResetControls();
        }

        //Silly face: private const string QUESTIONMARK = "M13,14c1.65,0,3,1.35,3,3c0,0.55,0.45,1,1,1s1-0.45,1-1c0-2.76-2.24-5-5-5s-5,2.24-5,5c0,0.55,0.45,1,1,1s1-0.45,1-1 C10,15.35,11.35,14,13,14z M27,18c0.55,0,1-0.45,1-1c0-1.65,1.35-3,3-3s3,1.35,3,3c0,0.55,0.45,1,1,1s1-0.45,1-1c0-2.76-2.24-5-5-5s-5,2.24-5,5 C26,17.55,26.45,18,27,18z M44,22C44,9.87,34.13,0,22,0S0,9.87,0,22s9.87,22,22,22c2.94,0,5.8-0.59,8.52-1.74l0.28,0.28c0.94,0.94,2.2,1.46,3.54,1.46 c1.34,0,2.59-0.52,3.54-1.46l0.71-0.71c1.69-1.69,1.91-4.3,0.67-6.24C42.31,31.72,44,26.94,44,22z M22,42C10.97,42,2,33.03,2,22 S10.97,2,22,2s20,8.97,20,20c0,4.37-1.44,8.62-4.08,12.09l-4.48-4.48C33.8,28.47,34,27.26,34,26c0-0.55-0.45-1-1-1s-1,0.45-1,1 c0,5.51-4.49,10-10,10s-10-4.49-10-10c0-0.55-0.45-1-1-1s-1,0.45-1,1c0,6.62,5.38,12,12,12c1.29,0,2.52-0.21,3.68-0.58l3.31,3.31 C26.74,41.57,24.4,42,22,42z M37.17,40.42l-0.71,0.71c-1.13,1.13-3.12,1.13-4.24,0l-0.76-0.76c0,0,0,0,0,0l-3.75-3.75 c0.82-0.45,1.57-1.01,2.27-1.62c0.02,0,0.04,0.01,0.06,0.01c0.5,0.3,1.68,1.37,3.49,3.18l0.12,0.12c0.2,0.2,0.45,0.29,0.71,0.29 s0.51-0.1,0.71-0.29c0.39-0.39,0.39-1.02,0-1.41l-0.12-0.12c-0.64-0.64-1.6-1.6-2.48-2.38c-0.32-0.28-0.66-0.58-1.01-0.84 c0.46-0.52,0.92-1.1,1.33-1.76l4.37,4.37c0.03,0.04,0.08,0.1,0.1,0.13c0,0,0.01,0.01,0.01,0.01 C38.33,37.47,38.31,39.28,37.17,40.42z";
        private const string HINT = "M 23.25 18 C 20.379839 18 18 20.34859 18 23.21875 L 18 76.75 C 18 79.6202 20.379839 82 23.25 82 L 76.75 82 C 79.620161 82 82 79.6202 82 76.75 L 82 23.21875 C 82 20.34859 79.620161 18 76.75 18 L 23.25 18 z M 23.25 22 L 76.75 22 C 77.47335 22 78 22.4954 78 23.21875 L 78 76.75 C 78 77.4734 77.47335 78 76.75 78 L 23.25 78 C 22.52665 78 22 77.4734 22 76.75 L 22 23.21875 C 22 22.4954 22.52665 22 23.25 22 z M 50 30 C 48.343145 30 47 31.34319 47 33 C 47 34.65689 48.343145 36 50 36 C 51.656855 36 53 34.65689 53 33 C 53 31.34319 51.656855 30 50 30 z M 49.78125 39.96875 A 2.0001999 2.0001999 0 0 0 48 42 L 48 68 A 2.0001999 2.0001999 0 1 0 52 68 L 52 42 A 2.0001999 2.0001999 0 0 0 49.78125 39.96875 z";

        private void ResetControls()
        {
            // _geometry is the converted PathData.

            if (_init == false)
                return;

            // If there is no icon specified we display a hint, as to not confuse the developer.
            if (_geometry == null)
            {
                _iconpath.Data = (Geometry)XamlBindingHelper.ConvertValue(typeof(Geometry), HINT); 
                return;
            }


            _iconpath.Data = _geometry;



        }


    }
}
