namespace ChartApp.Actors;
using Akka.Actor;

#region Reporting

/// <summary>
/// Signal used to indicate that it's time to sample all counters
/// </summary>
public record GatherMetrics;

/// <summary>
/// Metric data at the time of sample
/// </summary>
public record Metric(string Series, float CounterValue);

#endregion

#region Performance Counter Management

/// <summary>
/// All types of counters supported by this example
/// </summary>
public enum CounterType
{
    Cpu,
    Memory,
    Disk
}

/// <summary>
/// Enables a counter and begins publishing values to <see cref="Subscriber"/>.
/// </summary>
public record SubscribeCounter(CounterType Counter, IActorRef Subscriber);

/// <summary>
/// Unsubscribes <see cref="Subscriber"/> from receiving updates 
/// for a given counter
/// </summary>
public record UnsubscribeCounter(CounterType Counter, IActorRef Subscriber);

#endregion
