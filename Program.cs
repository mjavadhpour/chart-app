namespace ChartApp;
using System;
using Akka.Actor;
using Akka.Configuration;
using Avalonia;
using Avalonia.ReactiveUI;

internal static class Program
{
    /// <summary>
    /// ActorSystem we'll be using to publish data to charts
    /// and subscribe from performance counters
    /// </summary>
    public static ActorSystem ____RULE_VIOLATION____ChartActors____RULE_VIOLATION____ = null!;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        var config = ConfigurationFactory.ParseString(
            """
                    akka.remote.helios.tcp {
                          transport-class = "Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote"
                          transport-protocol = tcp
                          port = 8091
                          hostname = "127.0.0.1"
                      }
            """
        );

        ____RULE_VIOLATION____ChartActors____RULE_VIOLATION____ = ActorSystem.Create("ChartActors", config);
        _ = BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<Application>()
            .UsePlatformDetect()
            .UseSkia()
            .LogToTrace()
            .UseReactiveUI();
}
