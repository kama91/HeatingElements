using System;
using System.Drawing;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews.Interfaces;
using HeatingElements.Presenters;

namespace HeatingElements.HeatingViews
{
    public class HeatingPanelView : IHeatingElementView
    {
        private readonly HeatingPanelPresenter _presenter;

        public DiagramItem Shape { get; }

        public HeatingLampPresenter IsOnUpsLampPresenter { get; private set; }

        public HeatingLampPresenter IsNetworkOnLampPresenter { get; private set; }

        public HeatingLampPresenter IsPowerOnLampPresenter { get; private set; }

        public HeatingLampPresenter IsEntryAutomateOnLampPresenter { get; private set; }

        public HeatingPanelView(HeatingPanelPresenter heatingPanelPresenter)
        {
            _presenter = heatingPanelPresenter ?? throw new ArgumentNullException(nameof(heatingPanelPresenter));

            IsEntryAutomateOnLampPresenter = new HeatingLampPresenter(_presenter.IsEntryAutomateOnLamp);
            IsOnUpsLampPresenter = new HeatingLampPresenter(_presenter.IsOnUpsLamp);
            IsNetworkOnLampPresenter = new HeatingLampPresenter(_presenter.IsNetworkOnLamp);
            IsPowerOnLampPresenter = new HeatingLampPresenter(_presenter.IsPowerOnLamp);

            Shape = Create();
            Shape.DataContext = _presenter;
        }

        private DiagramItem Create()
        {
           var diagramContainer = new DiagramContainer(_presenter.Location.X, _presenter.Location.Y, 0, 0);

            var text = new DiagramShape
            {
                Appearance =
                {
                    Font = new Font("Tahoma", 24F),
                    TextOptions =
                    {
                        HAlignment = HorzAlignment.Near,
                        VAlignment = VertAlignment.Top
                    }
                },
                Content = $"      {_presenter.Model.Name}\r\n{Properties.Resources.EntryAutomate}\r\n{Properties.Resources.Connection}\r\n{Properties.Resources.OnUps}\r\n{Properties.Resources.Connection}\r\n{Properties.Resources.Temperature} {_presenter.Temperature} °С    \r\n\r\n\r\n",
                ForegroundId = DiagramThemeColorId.Black,
                Position = new PointFloat(0F, 0F),
                Shape = BasicShapes.RoundCornerRectangle,
                Size = new SizeF(250F, 350F),
                StrokeId = DiagramThemeColorId.Black
            };


            diagramContainer.Items.AddRange(text,
                IsEntryAutomateOnLampPresenter.View.Shape,
                IsNetworkOnLampPresenter.View.Shape,
                IsPowerOnLampPresenter.View.Shape,
                IsOnUpsLampPresenter.View.Shape);

            if (_presenter.IsAlarm)
            {
                var alarm = new DiagramShape
                {
                    Appearance =
                    {
                        Font = new Font("Tahoma", 18F),
                        BackColor = Color.Red
                    },
                    Content = Properties.Resources.Alarm,
                    ForegroundId = DiagramThemeColorId.Black,
                    Position = new PointFloat(40F, 260F),
                    Size = new SizeF(170F, 75F),
                    StrokeId = DiagramThemeColorId.Black,
                    CanChangeParent = true,
                    CanMove = true
                };

                diagramContainer.Items.Add(alarm);
            }

            return diagramContainer;
        }

        private static DiagramShape CreateLamp(int state, float x, float y)
        {
            return new DiagramShape
            {
                Appearance =
                {
                    BorderColor = Color.Black,
                    BackColor = state.ToColor()
                },
                Position = new PointFloat(x, y),
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
