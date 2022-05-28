using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeatingElements.Common;
using HeatingElements.Models;
using HeatingElements.Presenters;

namespace HeatingElements
{
    public partial class MainForm : Form
    {
        private const string Filter = "(*.xml) | *.xml";
        private HeatingLinePresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
        }

        private void _btnShowHeatingElements_Click(object sender, EventArgs e)
        {
            try
            {
                _openFileDialog.Filter = Filter;

                if (_openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var items = HeatingDataParser.GetParsedItemsFromFile(_openFileDialog.FileName);
                
                var presenters = new List<PresenterBase>(items.Count);

                foreach (var item in items)
                {
                    switch (item)
                    {
                        case HeatingPanel heatingPanel:
                            presenters.Add(new HeatingPanelPresenter(heatingPanel));
                            break;
                        case HeatingLine heatingLine:
                            presenters.Add(new HeatingLinePresenter(heatingLine));
                            break;
                        case HeatingSensor heatingSensor:
                            presenters.Add(new HeatingSensorPresenter(heatingSensor));
                            break;
                    }
                }

                AddElementsToControl(presenters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddElementsToControl(IReadOnlyCollection<PresenterBase> presenters)
        {
            HeatingLinePresenter presenter = null;

            foreach (var item in presenters)
            {
                if (item is HeatingLinePresenter heatingLineViewModel)
                {
                    if (heatingLineViewModel.Model.Name == "JB1")
                    {
                        presenter = heatingLineViewModel;
                        break;
                    }
                }
            }

            if (presenter == null)
            {
                return;
            }

            _presenter = presenter;

            _diagramControl.Items.Add(presenter.View.Shape);

            _diagramControl.FitToDrawing();

        }

        private async Task ModelValuesChangeAsync(HeatingLinePresenter heatingLinePresenter)
        {
            for (var i = 0; i < 100; i++)
            {
                heatingLinePresenter.Model.Temperature += i;

                if (i % 10 == 0)
                {
                    heatingLinePresenter.Model.State = State.Alarm;
                    Trace.WriteLine("Alarm");
                }
                else if (i % 2 == 0)
                {
                    heatingLinePresenter.Model.State = State.Warning;
                    Trace.WriteLine("Warning");
                }
                else
                {
                    heatingLinePresenter.Model.State = State.GoodOrOff;
                    Trace.WriteLine("Good");
                }

                await Task.Delay(100);
            }
        }

        private async void _btnRun_Click(object sender, EventArgs e)
        {
            await ModelValuesChangeAsync(_presenter);
        }
    }
}