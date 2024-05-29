using ForwardTestTask.Presentation.Models;
using ForwardTestTask.ViewModels;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Reactive;

namespace ForwardTestTask.Presentation.ViewModels
{
    public class AddNoteViewModel : ViewModelBase
    {
        public AddNoteViewModel()
        {
            AddNoteCommand = ReactiveCommand.Create(AddNote, CanAddNote);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public event Action<AddNoteModel>? DialogEnded;
        [Reactive] public string? Title { get; set; }
        [Reactive] public string? Description { get; set; }

        public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        private IObservable<bool> CanAddNote => this.WhenAnyValue(
            x => x.Title,
            x => !string.IsNullOrEmpty(x));

        private void AddNote() => DialogEnded?.Invoke(new AddNoteModel(Title!, Description));

        private void Cancel() => DialogEnded?.Invoke(null!);
    }
}