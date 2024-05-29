using Autofac;

using Avalonia;
using Avalonia.Markup.Xaml;

using ForwardTestTask.Core.Services.Interfaces;
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
        var a = new MainWindow { };
        //var wm = container.Resolve<NoteViewModel>();
        var vm = new NoteViewModel(container.Resolve<INoteService>(), a);
        a.DataContext = vm;
        a.Show();
        base.OnFrameworkInitializationCompleted();
    }
}
