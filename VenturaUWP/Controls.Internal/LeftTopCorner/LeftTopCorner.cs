using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

namespace Ventura.Controls
{
    
    public class LeftTopCorner : Control
    {
        public event RoutedEventHandler Click;

        public LeftTopCorner()
        {
            DefaultStyleKey = typeof(LeftTopCorner);
        }

        bool _initialized = false;

        protected override void OnApplyTemplate()
        {
            if (_initialized) throw new System.Exception("only call once");

            base.OnApplyTemplate();

            var ShadowHost = (UIElement)GetTemplateChild("ShadowHost");
            var CornerShape = (Shape)GetTemplateChild("CornerShape");

            InitializeDropShadow(ShadowHost, CornerShape);

            _initialized = true;
        }

        protected override void OnPointerReleased(PointerRoutedEventArgs e)
        {
            base.OnPointerReleased(e);

            // https://docs.microsoft.com/en-us/windows/uwp/design/input/handle-pointer-input

            //if(e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse
            //    {
            //    if( e.GetCurrentPoint().PoiPointer.Poi)
            //}
            //else

            Click?.Invoke(this, new RoutedEventArgs());
        }

        private void InitializeDropShadow(UIElement shadowHost, Shape shadowTarget)
        {
            Visual hostVisual = ElementCompositionPreview.GetElementVisual(shadowHost);
            Compositor compositor = hostVisual.Compositor;

            // Create a drop shadow
            var dropShadow = compositor.CreateDropShadow();
            dropShadow.Color = Color.FromArgb(255, 75, 75, 80);
            dropShadow.BlurRadius = 15.0f;
            dropShadow.Offset = new Vector3(2.5f, /*2.5f*/ 0f, 0.0f);

            // Associate the shape of the shadow with the shape of the target element
            dropShadow.Mask = shadowTarget.GetAlphaMask();

            // Create a Visual to hold the shadow
            var shadowVisual = compositor.CreateSpriteVisual();
            shadowVisual.Shadow = dropShadow;

            // Add the shadow as a child of the host in the visual tree
            ElementCompositionPreview.SetElementChildVisual(shadowHost, shadowVisual);

            // Make sure size of shadow host and shadow visual always stay in sync
            var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
            bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);

            shadowVisual.StartAnimation("Size", bindSizeAnimation);
        }


    }
}
