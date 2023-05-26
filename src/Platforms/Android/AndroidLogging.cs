using Android.Util;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;
using AndroidLog = Android.Util.Log;
using Log = Serilog.Log;

namespace GuitarTheory;

public static class AndroidLogging
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
        private const string Tag = nameof(GuitarTheory);

        public void Emit(LogEvent logEvent)
        {
            var writer = new StringWriter();
            logEvent.RenderMessage(writer);
            var message = writer.ToString();

            switch (logEvent.Level)
            {
                case LogEventLevel.Verbose:
                    AndroidLog.Verbose(Tag, message);
                    break;

                case LogEventLevel.Debug:
                    AndroidLog.Debug(Tag, message);
                    break;

                case LogEventLevel.Information:
                    AndroidLog.Info(Tag, message);
                    break;

                case LogEventLevel.Warning:
                    AndroidLog.Warn(Tag, message);
                    break;

                case LogEventLevel.Error:
                    AndroidLog.Error(Tag, message);
                    break;

                case LogEventLevel.Fatal:
                    AndroidLog.Wtf(Tag, message);
                    break;

                default:
                    AndroidLog.WriteLine(LogPriority.Assert, Tag, message);
                    break;
            }
        }
    }
}