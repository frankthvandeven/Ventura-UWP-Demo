using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Ventura.Helpers;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Glow effect:
// CustomControl.cs
// C:\Bagger\Win2D-Samples-master\ExampleGallery


namespace Ventura.Controls
{
    internal sealed partial class BreadCrumb : Control
    {

        private List<BreadCrumbVisual> _list_of_visuals;

        public BreadCrumb() : base()
        {
            _list_of_visuals = new List<BreadCrumbVisual>();

            this.DefaultStyleKey = typeof(BreadCrumb);

        }

        public ObservableCollection<SmartPage> PageStack
        {
            get { return (ObservableCollection<SmartPage>)this.GetValue(PageStackProperty); }
            set { SetValue(PageStackProperty, value); }
        }

        private Canvas _canvas;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_canvas != null)
                _canvas.SizeChanged -= Canvas_SizeChanged;

            _canvas = (Canvas)GetTemplateChild("canvas");

            _canvas.SizeChanged += Canvas_SizeChanged;

            //RedrawCollection();

            //InitializeDropShadow(_shadowhost, _home_crumb_path);
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Sets the clipping so text does not display outside the canvas.
            ClipHelper.SizeChanged(sender, e);

            RedrawCollection();
        }

        public static readonly DependencyProperty PageStackProperty = DependencyProperty.Register(nameof(PageStack),
            typeof(ObservableCollection<SmartPage>), typeof(BreadCrumb), new PropertyMetadata(null, OnPageStackChanged));

        private static void OnPageStackChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BreadCrumb;
            var old_pages = e.OldValue as ObservableCollection<SmartPage>;
            var new_pages = e.NewValue as ObservableCollection<SmartPage>;

            if (old_pages != null) old_pages.CollectionChanged -= control.PageStack_CollectionChanged;
            if (new_pages != null) new_pages.CollectionChanged += control.PageStack_CollectionChanged;

            if (control != null) control.RedrawCollection();
        }

        /// <summary>
        /// Calculates the total with of the elements in _list_of_visuals
        /// </summary>
        private double CalcTotalWidth()
        {
            double total = 0.00;

            foreach (var bcv in _list_of_visuals)
                total += bcv.Width;

            return total;
        }

        /// <summary>
        /// The calculated offset for the first child element inside the Canvas.
        /// </summary>
        //private float _canvas_offset = 0.0f;

        private void PageStack_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems.Count != 1) return;

                SmartPage page = e.NewItems[0] as SmartPage;

                bool isfirst = (_canvas.Children.Count == 0);

                var control = new SingleCrumb { FirstItem = isfirst, Text = page.PageCaption };

                // First, add to the visual tree
                _canvas.Children.Add(control); // Add the Element to the visual tree

                // Second, create the visual
                BreadCrumbVisual bcv = new BreadCrumbVisual(control);

                float new_offset = CalculateOffset( (float)bcv.Width);

                ShiftAllElementsToOffset(new_offset, miliseconds_delay: 0); // was 0

                // The total width before adding the new element.
                double total_width = CalcTotalWidth();

                // Third, add to the visuals collection
                _list_of_visuals.Add(bcv);

                bcv.Offset = new_offset + (float)total_width;
                bcv.CalculatedOffset = new_offset + (float)total_width;

                var anim = bcv.Compositor.CreateSpringScalarAnimation();
                anim.Period = TimeSpan.FromMilliseconds(200); // was 50
                anim.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                anim.DelayTime = TimeSpan.FromMilliseconds(200);
                anim.DampingRatio = 0.88f; // 0.2f
                anim.StopBehavior = AnimationStopBehavior.SetToFinalValue;
                anim.InitialValue = (float)_canvas.ActualWidth;
                anim.FinalValue = new_offset + (float)total_width;


                //var scopedBatch = bcv.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                //scopedBatch.Completed += ScopedBatch_Completed;
                bcv.Visual.StartAnimation("Offset.X", anim);
                
                //scopedBatch.End();
                //bcv.Offset = (float)total_width - (overflow+(float)bcv.Width);

            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems.Count != 1) return;

                SmartPage page_data = e.OldItems[0] as SmartPage;

                BreadCrumbVisual bcv = _list_of_visuals[_list_of_visuals.Count - 1];

                var anim = bcv.Compositor.CreateSpringScalarAnimation();
                anim.Period = TimeSpan.FromSeconds(0.50); // was 0.05
                //anim.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                //anim.DelayTime = TimeSpan.FromMilliseconds(100);
                anim.DampingRatio = 0.88f; // 0.2f
                anim.StopBehavior = AnimationStopBehavior.SetToFinalValue;
                anim.InitialValue = bcv.CalculatedOffset;
                anim.FinalValue = (float)_canvas.ActualWidth;

                Action action = () =>
                {
                    _canvas.Children.Remove(bcv.Element); // remove from Visual Tree
                };

                _list_of_visuals.Remove(bcv);

                CompositionScopedBatch scopedBatch = bcv.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);

                scopedBatch.Comment = _counter.ToString(); _counter++;

                _dictionary.Add(scopedBatch.Comment, action);

                scopedBatch.Completed += ScopedBatch_Completed;
                bcv.Visual.StartAnimation("Offset.X", anim);
                scopedBatch.End();
                //bcv.Offset = (float)total_width - (overflow+(float)bcv.Width);

                float new_offset = CalculateOffset(); // The offset might have changed as we removed the last item.

                ShiftAllElementsToOffset(new_offset, miliseconds_delay: 1200); // was 300

            }
            else
            {
                RedrawCollection();
            }

        }

        private int _counter = 0;
        private Dictionary<string, Action> _dictionary = new Dictionary<string, Action>();

        private void ScopedBatch_Completed(object sender, CompositionBatchCompletedEventArgs args)
        {
            CompositionScopedBatch batch = sender as CompositionScopedBatch;

            Action action = _dictionary[batch.Comment];
            _dictionary.Remove(batch.Comment);

            action();
        }

        /// <summary>
        /// Calculate an offset for the Canvas. 
        /// The offset is based on the width of the elements in collection _list_of_visuals
        /// </summary>
        /// <param name="desired_additional_width">Extra or less (negative) width to reserve space for.</param>
        private float CalculateOffset(float desired_additional_width = 0.0f)
        {
            double total_width = CalcTotalWidth();

            float offset = 0.0f;

            if ((total_width + desired_additional_width) > _canvas.ActualWidth)
            {
                offset = ((float)_canvas.ActualWidth) - ((float)total_width + desired_additional_width);
            }

            return offset;

        }

        private void ShiftAllElementsToOffset(float offset, double miliseconds_delay = 0)
        {

            foreach (var bcv in _list_of_visuals)
            {
                if (bcv.CalculatedOffset != offset)
                {

                    var anim = bcv.Compositor.CreateSpringScalarAnimation();
                    anim.Period = TimeSpan.FromSeconds(0.05);

                    if (miliseconds_delay > 0)
                    {
                        anim.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
                        anim.DelayTime = TimeSpan.FromMilliseconds(miliseconds_delay);
                    }

                    anim.DampingRatio = 1.0f; // 2.0f
                    anim.StopBehavior = AnimationStopBehavior.SetToFinalValue;
                    anim.InitialValue = bcv.CalculatedOffset;
                    anim.FinalValue = offset;

                    bcv.Visual.StartAnimation("Offset.X", anim);

                    bcv.CalculatedOffset = offset;
                }
                else
                {

                }

                offset += (float)bcv.Width;

                //delay += 50;
            }

        }

        /// <summary>
        /// Start from scratch. This will repair any animation positioning errors.
        /// </summary>
        private void RedrawCollection()
        {
            if (_canvas == null) return;

            _list_of_visuals.Clear();
            _canvas.Children.Clear();

            if (this.PageStack == null) return;

            // Create the SingleCrumb classes
            for (int i = 0; i < this.PageStack.Count; i++)
            {
                SmartPage page = this.PageStack[i];
                bool isfirst = (i == 0);

                var control = new SingleCrumb { FirstItem = isfirst, Text = page.PageCaption };

                // First Add to the visual tree
                _canvas.Children.Add(control);

                // Second create the the Visual
                BreadCrumbVisual item = new BreadCrumbVisual(control);

                // Third, add to the collection of visuals
                _list_of_visuals.Add(item);
            }

            float offset = CalculateOffset();

            foreach (var bcv in _list_of_visuals)
            {
                bcv.Offset = (float)offset;
                bcv.CalculatedOffset = (float)offset;

                offset += (float)bcv.Width;
            }

        }

        //private void InitializeDropShadow(UIElement shadowHost, Shape shadowTarget)
        //{
        //    Visual hostVisual = ElementCompositionPreview.GetElementVisual(shadowHost);
        //    Compositor compositor = hostVisual.Compositor;

        //    // Create a drop shadow
        //    var dropShadow = compositor.CreateDropShadow();
        //    dropShadow.Color = ((SolidColorBrush)Application.Current.Resources["VenturaOrange"]).Color; // Color.FromArgb(255, 75, 75, 80);
        //    dropShadow.Opacity = 1;
        //    dropShadow.BlurRadius = 10.0f;
        //    //dropShadow.Offset = new Vector3(2.5f, 2.5f, 0.0f);

        //    // Associate the shape of the shadow with the shape of the target element
        //    dropShadow.Mask = shadowTarget.GetAlphaMask();

        //    // Create a Visual to hold the shadow
        //    var shadowVisual = compositor.CreateSpriteVisual();
        //    shadowVisual.Shadow = dropShadow;

        //    // Add the shadow as a child of the host in the visual tree
        //    ElementCompositionPreview.SetElementChildVisual(shadowHost, shadowVisual);

        //    // Make sure size of shadow host and shadow visual always stay in sync
        //    var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
        //    bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);

        //    shadowVisual.StartAnimation("Size", bindSizeAnimation);
        //}

    }
}



// Animation is only needed if 'SingleCrumb' is larger than canvas
//if (textblock.ActualWidth <= canvas.ActualWidth) return;

//var animation = new DoubleAnimation
//{
//    AutoReverse = false,
//    Duration = storyboard.Duration,
//    SpeedRatio = storyboard.SpeedRatio,
//    From = 0.0d,
//    To = -(textblock.ActualWidth - canvas.ActualWidth), // -textblock.ActualWidth
//    EasingFunction = new ExponentialEase() {EasingMode = EasingMode.EaseOut }
//};
//Storyboard.SetTarget(animation, textblock.RenderTransform);
//Storyboard.SetTargetProperty(animation, "(TranslateTransform.X)");
