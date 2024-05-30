using Avalonia;
using Avalonia.Markup.Xaml;

using ForwardTestTask.Presentation.Setup;

namespace ForwardTestTask;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Setup.Start();
        base.OnFrameworkInitializationCompleted();
    }
}
