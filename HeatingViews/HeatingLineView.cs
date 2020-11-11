using System;
using System.Drawing;
using System.Globalization;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.Common;
using HeatingElements.HeatingViews.Interfaces;
using HeatingElements.Models;
using HeatingElements.Presenters;

namespace HeatingElements.HeatingViews
{
    public class HeatingLineView : IHeatingElementView
    {
        private readonly HeatingLinePresenter _presenter;
        private Color _backColor;

        public DiagramItem Shape { get; }

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

        public HeatingLineView(HeatingLinePresenter presenter)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

            Shape = Create();

            Shape.DataContext = _presenter;
            Shape.Bindings.Add(new DiagramBinding("Position", nameof(_presenter.Location)));
            Shape.Bindings.Add(new DiagramBinding("Content", nameof(_presenter.Temperature)));
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
                Size = new SizeF(120F, 75F),
                StrokeId = DiagramThemeColorId.Black
            };
        }
    }
}
