namespace ChartApp.Models;
using System.Collections.ObjectModel;
using LiveChartsCore;

public class Chart
{
    public ObservableCollection<ISeries<double>> Series { get; set; } = [];
}

public enum SeriesChartType
{
    Line
}
