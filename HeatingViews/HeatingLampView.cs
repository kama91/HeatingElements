using System.Drawing;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews.Interfaces;
using HeatingElements.Presenters;

namespace HeatingElements.HeatingViews
{
    public class HeatingLampView : IHeatingElementView
    {
        private readonly HeatingLampPresenter _presenter;

        public DiagramItem Shape { get; }

        public Color StateColor
        {
            get => Shape.Appearance.BackColor;
            set
            {
                if (Shape.Appearance.BackColor != value)
                {
                    Shape.Appearance.BackColor = value;
                }
            }
        }

        public HeatingLampView(HeatingLampPresenter presenter)
        {
            _presenter = presenter;

            Shape = Create();
            Shape.DataContext = _presenter;
        }

        private DiagramShape Create()
        {
            return new DiagramShape
            {
                Appearance =
                {
                    BorderColor = Color.Black,
                    BackColor = _presenter.Model.State.ToColor()
                },
                Position = new PointFloat(_presenter.Model.Location.X, _presenter.Model.Location.Y),
                Shape = BasicShapes.Ellipse,
                Size = new SizeF(20F, 20F),
                CanChangeParent = true,
                CanCopyWithoutParent = true,
                CanDeleteWithoutParent = true,
                CanMove = true
            };
        }
    }
}
