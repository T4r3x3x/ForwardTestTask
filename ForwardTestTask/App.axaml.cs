using Autofac;

using Avalonia;
using Avalonia.Markup.Xaml;

using ForwardTestTask.Presentation.Setup;
using ForwardTestTask.ViewModels;
using ForwardTestTask.Views;

namespace ForwardTestTask;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var container = new ContainerBuilder()
         .RegisterDepedencies()
         .Build();
        var wm = container.Resolve<NoteViewModel>();
        new MainWindow { DataContext = wm }.Show();
        base.OnFrameworkInitializationCompleted();
    }
}
