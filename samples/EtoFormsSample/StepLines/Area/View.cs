﻿using Eto.Forms;
using LiveChartsCore.SkiaSharpView.Eto.Forms;
using ViewModelsSamples.StepLines.Area;

namespace EtoFormsSample.StepLines.Area;

public class View : Panel
{
    private readonly CartesianChart cartesianChart;

    public View()
    {
        var viewModel = new ViewModel();

        cartesianChart = new CartesianChart
        {
            Series = viewModel.Series,
            DrawMarginFrame = viewModel.DrawMarginFrame,
        };

        Content = cartesianChart;
    }
}
