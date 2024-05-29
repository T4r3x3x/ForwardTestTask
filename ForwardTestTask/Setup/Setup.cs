using Autofac;

using ForwardTestTask.Presentation.Setup.DI;
using ForwardTestTask.ViewModels;
using ForwardTestTask.Views;

namespace ForwardTestTask.Presentation.Setup
{
    internal static class Setup
    {
        internal static void Start()
        {
            var window = new MainWindow();
            var container = new ContainerBuilder()
             .RegisterDepedencies(window)
             .Build();

            var noteVM = container.Resolve<NoteViewModel>();
            window.DataContext = noteVM;
            window.Show();
        }
    }
}
