﻿using ForwardTestTask.Domain.Dto;
using ForwardTestTask.Presentation.MVVM.ViewModels.Abstraction;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace ForwardTestTask.Presentation.MVVM.ViewModels.Implementation
{
    public class EditNoteViewModel : ViewModelBase, IDialogViewModel<NoteDto>
    {
        private Guid _guid;
        private readonly Subject<NoteDto> _noteSubject = new();

        public EditNoteViewModel()
        {
            SaveChangesCommand = ReactiveCommand.Create(SaveChanges, CanSaveChanges);
            CancelCommand = ReactiveCommand.Create(Cancel);
            DialogEnded = _noteSubject;
        }

        public IObservable<NoteDto?> DialogEnded { get; }

        [Reactive]
        public string? Title { get; set; }
        [Reactive]
        public string? Description { get; set; }

        public ReactiveCommand<Unit, Unit> SaveChangesCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        private IObservable<bool> CanSaveChanges => this.WhenAnyValue(
            x => x.Title,
            x => !string.IsNullOrEmpty(x));

        public void SetNoteDto(NoteDto noteDto)
        {
            _guid = noteDto.Guid;
            Title = noteDto.Title;
            Description = noteDto.Description;
        }

        private void SaveChanges() => _noteSubject.OnNext(new(_guid, Title!, Description!));
        private void Cancel() => _noteSubject.OnNext(null!);
    }
}