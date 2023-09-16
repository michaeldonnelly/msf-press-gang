using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Zola.Discord;

public class Instrumentor : IDisposable
{
    public const string ServiceName = "Zola.Discord";

    public Instrumentor()
    {
        var version = typeof(Instrumentor).Assembly.GetName().Version?.ToString();
        Tracer = new ActivitySource(ServiceName, version);
        Recorder = new Meter(ServiceName, version);
        OutgoingRequestCounter = Recorder.CreateCounter<long>("zola.discord.requests");
    }

    public ActivitySource Tracer { get; }
    public Meter Recorder { get; }
    public Counter<long> OutgoingRequestCounter { get; }

    public void Dispose()
    {
        Tracer.Dispose();
        Recorder.Dispose();
    }
}