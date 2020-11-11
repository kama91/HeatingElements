using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeatingElements.Common;
using HeatingElements.Models;
using HeatingElements.ViewModels;

namespace HeatingElements
{
    public partial class MainForm : Form
    {
        private const string Filter = "(*.xml) | *.xml";
        private HeatingLineViewModel _viewModel;

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
                
                var viewModels = new List<ViewModelBase>(items.Count);

                foreach (var item in items)
                {
                    switch (item)
                    {
                        case HeatingPanel heatingPanel:
                            viewModels.Add(new HeatingPanelViewModel(heatingPanel));
                            break;
                        case HeatingLine heatingLine:
                            viewModels.Add(new HeatingLineViewModel(heatingLine));
                            break;
                        case HeatingSensor heatingSensor:
                            viewModels.Add(new HeatingSensorViewModel(heatingSensor));
                            break;
                    }
                }

                AddElementsToControl(viewModels);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddElementsToControl(IReadOnlyCollection<ViewModelBase> viewModels)
        {
            HeatingLineViewModel viewModel = null;

            foreach (var item in viewModels)
            {
                if (item is HeatingLineViewModel heatingLineViewModel)
                {
                    if (heatingLineViewModel.Model.Name == "JB1")
                    {
                        viewModel = heatingLineViewModel;
                        break;
                    }
                }
            }

            if (viewModel == null)
            {
                return;
            }

            _viewModel = viewModel;

            _diagramControl.Items.Add(viewModel.View.Shape);

            _diagramControl.FitToDrawing();

        }

        private async Task ModelValuesChangeAsync(HeatingLineViewModel heatingLineViewModel)
        {
            for (var i = 0; i < 100; i++)
            {
                heatingLineViewModel.Model.Temperature += i;

                if (i % 10 == 0)
                {
                    heatingLineViewModel.Model.State = State.Alarm;
                    Trace.WriteLine("Alarm");
                }
                else if (i % 2 == 0)
                {
                    heatingLineViewModel.Model.State = State.Warning;
                    Trace.WriteLine("Warning");
                }
                else
                {
                    heatingLineViewModel.Model.State = State.GoodOrOff;
                    Trace.WriteLine("Good");
                }

                await Task.Delay(100);
            }
        }

        private async void _btnRun_Click(object sender, EventArgs e)
        {
            await ModelValuesChangeAsync(_viewModel);
        }
    }
}