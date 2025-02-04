﻿using System.Collections.Generic;
using System.Diagnostics;
using Eto.Forms;
using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Eto;
using ViewModelsSamples.Events.Polar;

namespace EtoFormsSample.Events.Polar;

public class View : Panel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="View"/> class.
    /// </summary>
    public View()
    {
        var viewModel = new ViewModel();

        var cartesianChart = new PolarChart
        {
            Series = viewModel.Series,
        };

        Content = cartesianChart;
    }
}
