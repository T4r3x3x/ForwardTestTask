using Autofac;

using ForwardTestTask.ViewModels;

using Splat;

namespace ForwardTestTask.Presentation.Setup.DI
{
    internal static class LocatorRegister
    {
        internal static void RegisterViewModelFactories(IContainer container)
        {
            Locator.CurrentMutable.Register(container.Resolve<NoteViewModel>);
        }
    }
}
