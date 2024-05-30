using Autofac;

using ForwardTestTask.Presentation.Factories.ViewModelFactories.Interfaces;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;
using ForwardTestTask.Presentation.Setup.DI;
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

            var factory = container.Resolve<IViewModelFactory<NoteViewModel>>();
            window.DataContext = factory.GetViewModel();
            window.Show();
        }
    }
}
