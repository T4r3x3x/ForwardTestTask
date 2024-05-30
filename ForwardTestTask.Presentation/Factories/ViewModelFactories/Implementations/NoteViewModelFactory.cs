using Avalonia.Controls;

using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Presentation.Factories.ViewModelFactories.Interfaces;
using ForwardTestTask.Presentation.MVVM.ViewModels.Implementation;

namespace ForwardTestTask.Presentation.Factories.ViewModelFactories.Implementations
{
    internal class NoteViewModelFactory : IViewModelFactory<NoteViewModel>
    {
        private readonly INoteService _noteService;
        private readonly Window _window;
        private readonly IViewModelFactory<AddNoteViewModel> _addNoteViewModelFactory;
        private readonly IViewModelFactory<EditNoteViewModel> _editNoteViewModelFactory;

        public NoteViewModelFactory(INoteService noteService, Window window,
            IViewModelFactory<AddNoteViewModel> addNoteViewModelFactory, IViewModelFactory<EditNoteViewModel> editNoteViewModelFactory)
        {
            _noteService = noteService;
            _window = window;
            _addNoteViewModelFactory = addNoteViewModelFactory;
            _editNoteViewModelFactory = editNoteViewModelFactory;
        }

        public NoteViewModel GetViewModel() => new NoteViewModel(_noteService, _window, _addNoteViewModelFactory, _editNoteViewModelFactory);
    }
}