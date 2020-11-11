using System;
using System.Drawing;
using System.Globalization;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.HeatingViews.Interfaces;
using HeatingElements.Presenters;

namespace HeatingElements.HeatingViews
{
    public class HeatingSensorView : IHeatingElementView
    {
        private readonly HeatingSensorPresenter _presenter;

        public DiagramItem Shape { get; }

        public HeatingSensorView(HeatingSensorPresenter heatingSensorPresenter)
        {
            _presenter = heatingSensorPresenter ?? throw new ArgumentNullException(nameof(heatingSensorPresenter));

            Shape = Create();
            Shape.DataContext = _presenter;
        }

        private DiagramItem Create()
        {
            return new DiagramShape
            {
                Appearance =
                {
                    BackColor = _presenter.StateColor,
                    Font = new Font("Tahoma", 24F)
                },
                Content = Convert.ToString(_presenter.Temperature, CultureInfo.InvariantCulture),
                ForegroundId = DiagramThemeColorId.Black,
                Position = new PointFloat(_presenter.Location.X, _presenter.Location.Y),
                Shape = BasicShapes.RoundCornerRectangle,
                Size = new SizeF(120F, 75F),
                StrokeId = DiagramThemeColorId.Black
            };
        }
    }
}
