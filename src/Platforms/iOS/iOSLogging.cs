using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace GuitarTheory;

public static class iOSLogging
{
    public static void Init()
    {
        SelfLog.Enable(message => Console.WriteLine($"[Serilog] {message}"));

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Sink(new Sink())
            .CreateLogger();
    }

    private class Sink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            var output = logEvent.Level >= LogEventLevel.Error ? Console.Error : Console.Out;
            logEvent.RenderMessage(output);
            if (logEvent.Exception is { } ex)
            {
                output.WriteLine(" --> " + ex);
            }
            else
            {
                output.WriteLine();
            }
        }
    }
}