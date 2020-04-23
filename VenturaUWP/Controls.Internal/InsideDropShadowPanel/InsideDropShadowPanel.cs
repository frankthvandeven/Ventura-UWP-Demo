using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Ventura.Controls
{
    
    public class InsideDropShadowPanel : Grid
    {
        // Statics

        public static DependencyProperty ShadowSideProperty { private set; get; }

        static InsideDropShadowPanel()
        {
            ShadowSideProperty = DependencyProperty.Register(nameof(ShadowSide),
                typeof(bool), typeof(InsideDropShadowPanel),
                new PropertyMetadata(ShadowSide.Left));
        }

        private Visual _hostVisual;
        private Compositor _compositor;
        private DropShadow _dropShadow;
        private SpriteVisual _shadowVisual;

        public InsideDropShadowPanel()
        {
            _hostVisual = ElementCompositionPreview.GetElementVisual(this);
            _compositor = _hostVisual.Compositor;

            // Create a drop shadow
            _dropShadow = _compositor.CreateDropShadow();
            _dropShadow.Color = Color.FromArgb(255, 75, 75, 80);
            _dropShadow.BlurRadius = 15.0f; // was 15.0f
            
            //if (shadowTarget != null)
            //{
            //    // Associate the shape of the shadow with the shape of the target element
            //    dropShadow.Mask = shadowTarget.GetAlphaMask();
            //}

            // Create a Visual to hold the shadow
            _shadowVisual = _compositor.CreateSpriteVisual();
            _shadowVisual.Shadow = _dropShadow;

            // Add the shadow as a child of the host in the visual tree
            ElementCompositionPreview.SetElementChildVisual(this, _shadowVisual);

            this.SizeChanged += PanelSizeChanged;
        }

        private void PanelSizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            UIElement element = sender as UIElement;

            element.Clip = new RectangleGeometry()
            {
                Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height)
            };

            ShadowSide side = this.ShadowSide;

            float width = (float)this.ActualWidth;
            float height = (float)this.ActualHeight;

            if (side == ShadowSide.Left)
                _dropShadow.Offset = new Vector3(2.5f - width, 0, 0);
            else if (side == ShadowSide.Right)
                _dropShadow.Offset = new Vector3(width - 2.5f, 0, 0); // 2.5f
            else if (side == ShadowSide.Top)
                _dropShadow.Offset = new Vector3(0, 2.5f - height, 0);
            else if (side == ShadowSide.Bottom)
                _dropShadow.Offset = new Vector3(0, height - 2.5f, 0);

            _shadowVisual.Size = new Vector2((float)this.ActualWidth, (float)this.ActualHeight);
        }

        public ShadowSide ShadowSide
        {
            set { SetValue(ShadowSideProperty, value); }
            get { return (ShadowSide)GetValue(ShadowSideProperty); }
        }

    }

    public enum ShadowSide
    {
        Left,
        Right,
        Top,
        Bottom
    }

}
