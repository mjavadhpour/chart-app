namespace ChartApp.Actors;
using System;
using System.Threading;
using Akka.Actor;
using ChartApp.Models;

using SeriesType = Dictionary<string, LiveChartsCore.ISeries<double>>;

public class ChartingActor : ReceiveActor
{
    #region Messages

    public record InitializeChart(SeriesType InitialSeries);
    public record AddSeries(SeriesType Series);

    #endregion

    #region Setup

    private SeriesType seriesIndex = null!;
    private readonly Chart chart;

    public ChartingActor(Chart chart)
    {
        this.chart = chart;
        this.Receive<InitializeChart>(this.HandleInitialize);
        this.Receive<AddSeries>(this.HandleAddSeries);
    }

    #endregion

    #region Individual Message Type Handlers

    private void HandleInitialize(InitializeChart ic)
    {
        this.seriesIndex = ic.InitialSeries;

        //attempt to render the initial chart
        if (0 < this.seriesIndex.Count)
        {
            foreach (var series in this.seriesIndex)
            {
                this.chart.Series.Add(series.Value);
                //force both the chart and the internal index to use the same names
                Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            }
        }
    }

    private void HandleAddSeries(AddSeries s)
    {
        foreach (var series in s.Series)
        {
            if (!string.IsNullOrEmpty(series.Value.Name) && !this.seriesIndex.ContainsKey(series.Value.Name))
            {
                this.seriesIndex.Add(series.Value.Name, series.Value);
                this.chart.Series.Add(series.Value);
            }
        }
    }

    #endregion
}
