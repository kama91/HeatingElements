using System;
using System.Drawing;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews.Base;
using HeatingElements.ViewModels;

namespace HeatingElements.HeatingViews
{
    public class HeatingPanelView : HeatingViewBase
    {
        public sealed override DiagramItem Shape { get; set; }

        public HeatingPanelView(HeatingPanelViewModel heatingPanelViewModel)
        {
            if (heatingPanelViewModel == null)
            {
                throw new ArgumentNullException(nameof(heatingPanelViewModel));
            }

            Shape = Create(heatingPanelViewModel);
            Shape.DataContext = heatingPanelViewModel;
        }

        private DiagramItem Create(HeatingPanelViewModel heatingPanelViewModel)
        {
           var diagramContainer = new DiagramContainer(heatingPanelViewModel.Location.X, heatingPanelViewModel.Location.Y, 0, 0);

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
                Content = $"      {heatingPanelViewModel.Model.Name}\r\n{Properties.Resources.EntryAutomate}\r\n{Properties.Resources.Connection}\r\n{Properties.Resources.OnUps}\r\n{Properties.Resources.Connection}\r\n{Properties.Resources.Temperature} {heatingPanelViewModel.Temperature} °С    \r\n\r\n\r\n",
                ForegroundId = DiagramThemeColorId.Black,
                Position = new PointFloat(0F, 0F),
                Shape = BasicShapes.RoundCornerRectangle,
                Size = new SizeF(250F, 350F),
                StrokeId = DiagramThemeColorId.Black
            };

            var entryAutomate = CreateLamp(heatingPanelViewModel.IsEntryAutomateOn, 210F, 50F);
            var network = CreateLamp(heatingPanelViewModel.IsNetworkOn, 210F, 90F);
            var powerOn = CreateLamp(heatingPanelViewModel.IsPowerOn, 210F, 130F);
            var ups = CreateLamp(heatingPanelViewModel.IsOnUps, 210F, 165F);

            diagramContainer.Items.AddRange(text, entryAutomate, network, powerOn, ups);

            if (heatingPanelViewModel.IsAlarm)
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
