using ForwardTestTask.Presentation.Factories.ViewModelFactories.Interfaces;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

namespace ForwardTestTask.Presentation.Factories.ViewModelFactories.Implementations
{
    internal class AddNoteViewModelFactory : IViewModelFactory<AddNoteViewModel>
    {
        public AddNoteViewModel GetViewModel() => new AddNoteViewModel();
    }
}