namespace ChartApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Util;
using ChartApp.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

public static class ChartDataHelper
{
    public static Dictionary<string, ISeries<double>> RandomSeries(string seriesName, SeriesChartType type = SeriesChartType.Line, int points = 100)
    {
        ISeries<double> series = type switch
        {
            SeriesChartType.Line => new LineSeries<double>()
            {
                Name = seriesName
            },
            _ => new LineSeries<double>()
        };

        IEnumerable<double> randomValues = Array.Empty<double>();
        foreach (var i in Enumerable.Range(0, points))
        {
            var rng = ThreadLocalRandom.Current.NextDouble();
            randomValues = randomValues.Append((2.0 * Math.Sin(rng)) + Math.Sin(rng / 4.5));
        }

        series.Values = randomValues;

        return new Dictionary<string, ISeries<double>>
        {
            {seriesName, series}
        };
    }
}
