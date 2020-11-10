using System;
using System.Drawing;
using System.Globalization;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.HeatingViews.Base;
using HeatingElements.ViewModels;

namespace HeatingElements.HeatingViews
{
    public class HeatingSensorView : HeatingViewBase
    {
        public sealed override DiagramItem Shape { get; set; }

        public HeatingSensorView(HeatingSensorViewModel heatingSensorViewModel)
        {
            if (heatingSensorViewModel == null)
            {
                throw new ArgumentNullException(nameof(heatingSensorViewModel));
            }

            Shape = Create(heatingSensorViewModel);
            Shape.DataContext = heatingSensorViewModel;
        }

        private DiagramItem Create(HeatingSensorViewModel heatingSensorViewModel)
        {
            return new DiagramShape
            {
                Appearance =
                {
                    BackColor = heatingSensorViewModel.StateColor,
                    Font = new Font("Tahoma", 24F)
                },
                Content = Convert.ToString(heatingSensorViewModel.Temperature, CultureInfo.InvariantCulture),
                ForegroundId = DiagramThemeColorId.Black,
                Position = new PointFloat(heatingSensorViewModel.Location.X, heatingSensorViewModel.Location.Y),
                Shape = BasicShapes.RoundCornerRectangle,
                Size = new SizeF(120F, 75F),
                StrokeId = DiagramThemeColorId.Black
            };
        }
    }
}
