using Android.App;
using Android.Runtime;

namespace GuitarTheory;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
        AndroidLogging.Init();
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}