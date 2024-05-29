using ForwardTestTask.Domain.Entities;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Reactive;

namespace ForwardTestTask.Presentation.ViewModels
{
    public class EditNoteViewModel
    {
        private readonly NoteDto _noteDto;

        public EditNoteViewModel(NoteDto noteDto)
        {
            _noteDto = noteDto;
            Title = noteDto.Title;
            Description = noteDto.Description;

            SaveChangesCommand = ReactiveCommand.Create(SaveChanges, CanSaveChanges);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public event Action<NoteDto?>? DialogEnded;

        [Reactive] public string? Title { get; set; }
        [Reactive] public string? Description { get; set; }

        public ReactiveCommand<Unit, Unit> SaveChangesCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        private IObservable<bool> CanSaveChanges => this.WhenAnyValue(
            x => x.Title,
            x => !string.IsNullOrEmpty(x));

        private void SaveChanges() => DialogEnded?.Invoke(new(_noteDto.Guid, Title!, Description!));
        private void Cancel() => DialogEnded?.Invoke(null!);
    }
}