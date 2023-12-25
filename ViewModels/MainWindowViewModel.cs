namespace ChartApp.ViewModels;
using System.Reactive;
using Akka.Actor;
using Akka.Util.Internal;
using ChartApp.Actors;
using ChartApp.Models;
using ChartApp.Utils;
using ReactiveUI;

public class MainWindowViewModel : ReactiveObject
{
    private readonly IActorRef chartActor;
    private static readonly AtomicCounter SeriesCounter = new(1);

    public Chart Chart { get; set; } = new();

    public ReactiveCommand<Unit, Unit> BtnCpuCommand { get; }
    public ReactiveCommand<Unit, Unit> BtnMemoryCommand { get; }
    public ReactiveCommand<Unit, Unit> BtnDiskCommand { get; }

    public MainWindowViewModel()
    {
        this.chartActor = Program.____RULE_VIOLATION____ChartActors____RULE_VIOLATION____.ActorOf(Props.Create<ChartingActor>(this.Chart));
        var series = ChartDataHelper.RandomSeries($"FakeSeries {SeriesCounter.GetAndIncrement()}");
        this.chartActor.Tell(new ChartingActor.InitializeChart(series));
        this.BtnCpuCommand = ReactiveCommand.Create(this.BtnCpuCommandClick);
        this.BtnMemoryCommand = ReactiveCommand.Create(this.BtnMemoryCommandClick);
        this.BtnDiskCommand = ReactiveCommand.Create(this.BtnDiskCommandClick);
    }

    private void BtnCpuCommandClick()
    {
    }

    private void BtnMemoryCommandClick()
    {
    }

    private void BtnDiskCommandClick()
    {
    }

}
