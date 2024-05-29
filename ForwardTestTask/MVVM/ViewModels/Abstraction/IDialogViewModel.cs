using System;

namespace ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction
{
    public interface IDialogViewModel<T>
    {
        IObservable<T?> DialogEnded { get; }
    }
}