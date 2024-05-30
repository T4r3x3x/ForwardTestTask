using Autofac;

using Avalonia.Controls;

using ForwardTestTask.Core.Services.Implementations;
using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;
using ForwardTestTask.Domain.Repositories.Implementation;
using ForwardTestTask.Presentation.Factories.ViewModelFactories.Implementations;
using ForwardTestTask.Presentation.Factories.ViewModelFactories.Interfaces;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

namespace ForwardTestTask.Presentation.Setup.DI
{
    internal static class DependencyResolver
    {
        internal static ContainerBuilder RegisterDepedencies(this ContainerBuilder builder, Window window)
            => builder.RegisterServices()
            .RegisterRepositories()
            .RegisterViewModels()
            .RegisterFactories()
            .RegisterWindow(window);

        internal static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteService>()
                .As<INoteService>();
            return builder;
        }

        internal static ContainerBuilder RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteRepository>()
                .As<INoteRepository>()
                .SingleInstance();
            return builder;
        }

        internal static ContainerBuilder RegisterWindow(this ContainerBuilder builder, Window window)
        {
            builder.RegisterInstance(window)
                .As<Window>();
            return builder;
        }

        internal static ContainerBuilder RegisterFactories(this ContainerBuilder builder)
        {
            builder.RegisterType<AddNoteViewModelFactory>()
                .As<IViewModelFactory<AddNoteViewModel>>();
            builder.RegisterType<EditNoteViewModelFactory>()
                .As<IViewModelFactory<EditNoteViewModel>>();
            builder.RegisterType<NoteViewModelFactory>()
                .As<IViewModelFactory<NoteViewModel>>();
            return builder;
        }

        internal static ContainerBuilder RegisterViewModels(this ContainerBuilder builder)
        {
            builder.RegisterType<NoteViewModel>();
            return builder;
        }
    }
}
