using Foundation;

namespace GuitarTheory;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public AppDelegate()
    {
        iOSLogging.Init();
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}