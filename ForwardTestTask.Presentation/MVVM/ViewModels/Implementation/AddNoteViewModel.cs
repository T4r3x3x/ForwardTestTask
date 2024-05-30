using ForwardTestTask.Presentation.Models;
using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace ForwardTestTask.Presentation.MVVM.ViewModels.Implementation
{
    public class AddNoteViewModel : ViewModelBase, IDialogViewModel<AddNoteModel>
    {
        private readonly Subject<AddNoteModel?> _noteSubject = new();

        public AddNoteViewModel()
        {
            DialogEnded = _noteSubject;

            AddNoteCommand = ReactiveCommand.Create(AddNote, CanAddNote);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public IObservable<AddNoteModel?> DialogEnded { get; }

        [Reactive]
        public string? Title { get; set; }
        [Reactive]
        public string? Description { get; set; }

        public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        private IObservable<bool> CanAddNote => this.WhenAnyValue(
            x => x.Title,
            x => !string.IsNullOrEmpty(x));

        private void AddNote() => _noteSubject.OnNext(new AddNoteModel(Title!, Description));

        private void Cancel() => _noteSubject.OnNext(null!);
    }
}