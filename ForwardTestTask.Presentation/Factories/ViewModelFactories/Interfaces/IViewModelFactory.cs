using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;

namespace ForwardTestTask.Presentation.Factories.ViewModelFactories.Interfaces
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T GetViewModel();
    }
}
