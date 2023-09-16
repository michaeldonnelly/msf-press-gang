using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Zola.Web;

public class Instrumentor : IDisposable
{
    public const string ServiceName = "Zola.Web";

    public Instrumentor()
    {
        var version = typeof(Instrumentor).Assembly.GetName().Version?.ToString();
        Tracer = new ActivitySource(ServiceName, version);
        Recorder = new Meter(ServiceName, version);
        OutgoingRequestCounter = Recorder.CreateCounter<long>("zola.web.requests");  
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