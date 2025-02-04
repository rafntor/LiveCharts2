﻿using System.Threading.Tasks;
using Eto.Forms;
using LiveChartsCore.SkiaSharpView.Eto;
using ViewModelsSamples.StepLines.AutoUpdate;

namespace EtoFormsSample.StepLines.AutoUpdate;

public class View : Panel
{
    private readonly CartesianChart cartesianChart;
    private readonly ViewModel viewModel;
    private bool? isStreaming = false;

    public View()
    {
        viewModel = new ViewModel();

        cartesianChart = new CartesianChart
        {
            Series = viewModel.Series,
        };

        var b1 = new Button { Text = "Add item" };
        b1.Click += (object sender, System.EventArgs e) => viewModel.AddItem();

        var b2 = new Button { Text = "Replace item" };
        b2.Click += (object sender, System.EventArgs e) => viewModel.ReplaceRandomItem();

        var b3 = new Button { Text = "Remove item" };
        b3.Click += (object sender, System.EventArgs e) => viewModel.RemoveFirstItem();

        var b4 = new Button { Text = "Add series" };
        b4.Click += (object sender, System.EventArgs e) => viewModel.AddSeries();

        var b5 = new Button { Text = "Remove series" };
        b5.Click += (object sender, System.EventArgs e) => viewModel.RemoveLastSeries();

        var b6 = new Button { Text = "Constant changes" };
        b6.Click += OnConstantChangesClick;

        var buttons = new StackLayout(b1, b2, b3, b4, b5, b6) { Orientation = Orientation.Horizontal, Padding = 2, Spacing = 4 };

        Content = new DynamicLayout(buttons, cartesianChart);
    }

    private async void OnConstantChangesClick(object sender, System.EventArgs e)
    {
        isStreaming = isStreaming is null ? true : !isStreaming;

        while (isStreaming.Value)
        {
            viewModel.RemoveFirstItem();
            viewModel.AddItem();
            await Task.Delay(1000);
        }
    }

    private void B1_Click(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
