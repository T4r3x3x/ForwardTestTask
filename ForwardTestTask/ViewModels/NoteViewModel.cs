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
        Notes.Subscribe(x =>
        {
        });
        AddNoteCommand = ReactiveCommand.CreateFromTask<AddNoteModel>(AddNote);
        DeleteNoteCommand = ReactiveCommand.Create<Guid>(async (guid) => await DeleteNote(guid));
        EditNoteCommand = ReactiveCommand.Create<EditNoteModel>(async (_) => await EditNote(_));
    }

    #region Commands
    public IObservable<IList<Note>> Notes { get; }
    public ReactiveCommand<AddNoteModel, Unit> AddNoteCommand { get; }
    public ReactiveCommand<Guid, Unit> DeleteNoteCommand { get; set; }
    public ReactiveCommand<EditNoteModel, Unit> EditNoteCommand { get; }
    #endregion

    #region Methods
    private async Task AddNote(AddNoteModel addNoteModel) => await _noteService.AddAsync(addNoteModel);

    private async Task DeleteNote(Guid guid)
    {
        //Message
        await _noteService.DeleteAsync(guid);
    }

    private async Task EditNote(EditNoteModel editNoteModel) => await _noteService.EditAsync(editNoteModel);
    #endregion
}