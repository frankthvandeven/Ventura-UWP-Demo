using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{

    
    public class MenuPanel : Control
    {
        public MenuPanel()
        {
            DefaultStyleKey = typeof(MenuPanel);

            this.RenderTransform = new TranslateTransform { X = 0, Y = -5000 };
        }

        bool _initialized = false;

        ItemsControl _itemscontrol;

        private enum PanelStatus
        {
            Closed,
            Open
        }

        private PanelStatus _panelstatus = PanelStatus.Closed;

        protected override void OnApplyTemplate()
        {
            if (_initialized) throw new System.Exception("only call once");

            base.OnApplyTemplate();

            _itemscontrol = (ItemsControl)GetTemplateChild("MenuItemsControl");

            _initialized = true;
        }

        public void HideMenuPanel()
        {
            if (_panelstatus == PanelStatus.Closed)
                return;

            ClosingAnimation();

            _panelstatus = PanelStatus.Closed;
        }

        public void ShowMenuPanel(MenubarItem invoked)
        {
            // This is needed
            this.RenderTransform = null; //.Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 0);

            _itemscontrol.ItemsSource = invoked.Categories;

            // This is needed to, otherwise the first-time-open height is incorrect.
            this.UpdateLayout();

            if (_panelstatus == PanelStatus.Open)
                return;

            OpeningAnimation();

            _panelstatus = PanelStatus.Open;
        }

        private void OpeningAnimation()
        {
            // https://docs.microsoft.com/en-us/windows/uwp/composition/spring-animations

            var visual = ElementCompositionPreview.GetElementVisual(this);
            var compositor = visual.Compositor;

            var anim = compositor.CreateSpringScalarAnimation();

            anim.Period = TimeSpan.FromMilliseconds(50); // was 50
            anim.DampingRatio = 0.60f; // 1f; //  0.75f;

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
            anim.DampingRatio = 0.75f; //1; // 0.75f; // 0.2f

            anim.InitialValue = 0f;
            anim.FinalValue = -(float)this.ActualHeight;

            //var scopedBatch = bcv.Compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
            //scopedBatch.Completed += ScopedBatch_Completed;

            //var scopedBatch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);

            //scopedBatch.Completed += ClosingAnimation_ScopedBatch_Completed;

            visual.StartAnimation("Offset.Y", anim);

            //scopedBatch.End();
        }

    }
}




//private void InitializeDropShadow(UIElement shadowHost, Shape shadowTarget)
//{
//    Visual hostVisual = ElementCompositionPreview.GetElementVisual(shadowHost);
//    Compositor compositor = hostVisual.Compositor;

//    // Create a drop shadow
//    var dropShadow = compositor.CreateDropShadow();
//    dropShadow.Color = Color.FromArgb(255, 75, 75, 80);
//    dropShadow.BlurRadius = 15.0f;
//    dropShadow.Offset = new Vector3(2.5f, 2.5f, 0.0f);

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

#if ddddd
#region DP - ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(MenuBarItemData), typeof(MenuPanel), new PropertyMetadata(null, OnViewModelChanged));

        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MenuPanel;
            var old_viewmodel = e.OldValue as MenuBarItemData;
            var new_viewmodel = e.NewValue as MenuBarItemData;

            control.OnViewModelChanged(e);

            //if (old_viewmodel != null) old_viewmodel.Tabs.CollectionChanged -= control.Tabs_CollectionChanged;
            //if (new_viewmodel != null) new_viewmodel.Tabs.CollectionChanged += control.Tabs_CollectionChanged;
        }

        public void OnViewModelChanged(DependencyPropertyChangedEventArgs e)
        {
            //MenuItemsControl.
        }

        public MenuBarItemData ViewModel
        {
            get { return (MenuBarItemData)this.GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
#endregion DP-ViewModel
#endif