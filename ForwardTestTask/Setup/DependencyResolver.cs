using Autofac;

using ForwardTestTask.Core.Services.Implementations;
using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;
using ForwardTestTask.Domain.Repositories.Implementation;
using ForwardTestTask.ViewModels;

namespace ForwardTestTask.Presentation.Setup
{
    internal static class DependencyResolver
    {
        internal static ContainerBuilder RegisterDepedencies(this ContainerBuilder builder)
            => builder.RegisterServices()
                .RegisterRepositories()
                .RegisterViewModels();

        internal static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteService>()
                .As<INoteService>();
            return builder;
        }

        internal static ContainerBuilder RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteRepository>()
                .As<INoteRepository>();
            return builder;
        }

        internal static ContainerBuilder RegisterViewModels(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteViewModel>();
            return builder;
        }
    }
}
