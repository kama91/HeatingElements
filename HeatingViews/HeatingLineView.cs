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
    public class HeatingLineView : HeatingViewBase 
    {
        private Color _backColor;
        
        public sealed override DiagramItem Shape { get; }

        public Color BackColor
        {
            get => _backColor;
            set
            {
                if (_backColor != value)
                {
                    _backColor = value;
                    Shape.Appearance.BackColor = _backColor;
                }
            }
        }

        public HeatingLineView(HeatingLineViewModel heatingLineViewModel)
        {
            if (heatingLineViewModel == null)
            {
                throw new ArgumentNullException(nameof(heatingLineViewModel));
            }

            Shape = Create(heatingLineViewModel);
            Shape.DataContext = heatingLineViewModel;
            Shape.Bindings.Add(new DiagramBinding("Position", nameof(heatingLineViewModel.Location)));
            Shape.Bindings.Add(new DiagramBinding("Content", nameof(heatingLineViewModel.Temperature)));
        }

        private DiagramItem Create(HeatingLineViewModel heatingLineViewModel)
        {
            return new DiagramShape
            {
                Appearance =
                {
                    BackColor = heatingLineViewModel.StateColor,
                    Font = new Font("Tahoma", 24F)
                },
                Content = Convert.ToString(heatingLineViewModel.Temperature, CultureInfo.InvariantCulture),
                ForegroundId = DiagramThemeColorId.Black,
                Position = new PointFloat(heatingLineViewModel.Location.X, heatingLineViewModel.Location.Y),
                Size = new SizeF(120F, 75F),
                StrokeId = DiagramThemeColorId.Black
            };
        }
    }
}
