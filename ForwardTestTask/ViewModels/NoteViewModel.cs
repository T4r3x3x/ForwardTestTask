using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Presentation.Models;

using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;

namespace ForwardTestTask.ViewModels;

public class NoteViewModel : ViewModelBase
{
    private readonly INoteService _noteService;

    public NoteViewModel(INoteService noteService)
    {
        _noteService = noteService;
        Notes = _noteService.Notes;
        AddNoteCommand = ReactiveCommand.Create<AddNoteModel>(async (_) => await AddNote(_));
        DeleteNoteCommand = ReactiveCommand.Create<Guid>(async (_) => await DeleteNote(_));
        EditNoteCommand = ReactiveCommand.Create<EditNoteModel>(async (_) => await EditNote(_));
    }

    public IObservable<IEnumerable<Note>> Notes { get; }
    public ReactiveCommand<AddNoteModel, Unit> AddNoteCommand { get; }
    public ReactiveCommand<Guid, Unit> DeleteNoteCommand { get; }
    public ReactiveCommand<EditNoteModel, Unit> EditNoteCommand { get; }


    private async Task AddNote(AddNoteModel addNoteModel) => await _noteService.AddAsync(addNoteModel);

    private async Task DeleteNote(Guid guid) => await _noteService.DeleteAsync(guid);

    private async Task EditNote(EditNoteModel editNoteModel) => await _noteService.EditAsync(editNoteModel);
}