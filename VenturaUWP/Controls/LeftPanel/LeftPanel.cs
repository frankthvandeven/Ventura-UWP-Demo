using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Ventura.Controls
{
    public class LeftPanel : ContentControl
    {
        private static double LEFTPANELWIDTH = (double)Application.Current.Resources["VenturaLeftPanelWidth"];

        public event RoutedEventHandler BeforeOpenAnimation;
        public event RoutedEventHandler AfterOpenAnimation;
        public event RoutedEventHandler AfterCloseAnimation;

        // Statics

        public static DependencyProperty IsOpenProperty { private set; get; }

        static LeftPanel()
        {
            IsOpenProperty = DependencyProperty.Register(nameof(IsOpen),
                typeof(bool), typeof(LeftPanel),
                new PropertyMetadata(true, OnIsOpenPropertyChanged));

        }

        private static void OnIsOpenPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as LeftPanel).OnIsOpenPropertyChanged(args);
        }

        private void OnIsOpenPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            //VisualTree.FindDescendantByName(Window.Current.Content, "");

            bool is_open = (bool)args.NewValue;

            if (is_open)
            {
                BeforeOpenAnimation?.Invoke(this, new RoutedEventArgs());
                RunOpenAnimation();
            }
            else
            {
                RunCloseAnimation();
                return;
            }

        }

        public LeftPanel()
        {
            DefaultStyleKey = typeof(LeftPanel);
        }

        public bool IsOpen
        {
            set { SetValue(IsOpenProperty, value); }
            get { return (bool)GetValue(IsOpenProperty); }
        }

        bool _initialized = false;

        protected override void OnApplyTemplate()
        {
            if (_initialized) throw new System.Exception("only call once");

            base.OnApplyTemplate();

            //_MainGrid = (Grid)GetTemplateChild("MainGrid");

            _initialized = true;
        }

        private void RunOpenAnimation()
        {
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = LEFTPANELWIDTH,
                Duration = new Duration(TimeSpan.FromMilliseconds(200)),
                EnableDependentAnimation = true
            };

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);
            //Storyboard.SetTargetProperty(animation, "(Grid.Width)");
            Storyboard.SetTargetProperty(animation, "Width");
            Storyboard.SetTarget(animation, this);

            sb.Completed += OpenAnimation_Completed;

            sb.Begin();
        }

        private void OpenAnimation_Completed(object sender, object e)
        {
            AfterOpenAnimation?.Invoke(this, new RoutedEventArgs());
        }

        private void RunCloseAnimation()
        {
            var animation = new DoubleAnimation()
            {
                From = this.ActualWidth,
                To = 0,
                Duration = new Duration(TimeSpan.FromMilliseconds(200)),
                EnableDependentAnimation = true
            };

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);
            //Storyboard.SetTargetProperty(animation, "(Grid.Width)");
            Storyboard.SetTargetProperty(animation, "Width");
            Storyboard.SetTarget(animation, this);

            sb.Completed += CloseAnimation_Completed;

            sb.Begin();
        }

        private void CloseAnimation_Completed(object sender, object e)
        {
            AfterCloseAnimation?.Invoke(this, new RoutedEventArgs());
        }

    }

}



/*
 * 
        private void OpeningAnimation()
        {
            // https://docs.microsoft.com/en-us/windows/uwp/composition/spring-animations

            var visual = ElementCompositionPreview.GetElementVisual(this);
            var compositor = visual.Compositor;

            var anim = compositor.CreateSpringScalarAnimation();

            anim.Period = TimeSpan.FromMilliseconds(50); // was 200
            anim.DampingRatio = 1f; //  0.75f;

            anim.InitialValue = -(float)this.ActualHeight;
            anim.FinalValue = 0f;

            visual.StartAnimation("Offset.Y", anim);
        }

        private void ClosingAnimation()
        {
            var visual = ElementCompositionPreview.GetElementVisual(this);
            var compositor = visual.Compositor;

            var anim = compositor.CreateSpringScalarAnimation();
            anim.Period = TimeSpan.FromMilliseconds(50); // was 50
            anim.DampingRatio = 1; // 0.75f; // 0.2f

            anim.InitialValue = 0f;
            anim.FinalValue = -(float)this.ActualHeight;

            //var scopedBatch = bcv.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            //scopedBatch.Completed += ScopedBatch_Completed;

            //var scopedBatch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);

            //scopedBatch.Completed += ClosingAnimation_ScopedBatch_Completed;

            visual.StartAnimation("Offset.Y", anim);

            //scopedBatch.End();
        }

    */