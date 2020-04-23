using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.Foundation;

namespace Ventura.Controls
{
    internal class BreadCrumbVisual
    {
        private Visual _visual;
        private SingleCrumb _element;
        private Double _width;
        private float _calculated_offset;

        public BreadCrumbVisual(SingleCrumb control)
        {
            _element = control;

            //MeasureElementWidth();

            _visual = ElementCompositionPreview.GetElementVisual(control);
        }

        internal Visual Visual
        {
            get { return _visual; }
        }

        internal Compositor Compositor
        {
            get { return _visual.Compositor; }
        }

        /// <summary>
        /// The Offset relative to the Canvas. Can be negative.
        /// </summary>
        internal float CalculatedOffset
        {
            get { return _calculated_offset; }
            set
            {
                _calculated_offset = value;
            }
        }

        internal UIElement Element
        {
            get { return _element; }
        }

        internal float Offset
        {
            //get { return _visual.Offset.X; }
            set
            {
                _visual.Offset = new System.Numerics.Vector3(value, 0, 0);
            }
        }

        //private Action _completed_action;

        //private void ScopedBatch_Completed(object sender, CompositionBatchCompletedEventArgs args)
        //{
        //    if (_completed_action == null) return;

        //    _completed_action();
        //    _completed_action = null;
        //}

        /// <summary>
        /// Returns the Width of the UIElement.
        /// </summary>
        public double Width
        {
            get
            {
                MeasureElementWidth();
                return _width;
            }
        }

        /// <summary>
        /// Measure or remeasure the width of the SingleCrumb.
        /// </summary>
        private void MeasureElementWidth()
        {

            _element.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            _width = _element.DesiredSize.Width;

            if (_width == 0)
                throw new Exception("Measured width 0 in BreadCrumbItem.");

        }

    }
}
