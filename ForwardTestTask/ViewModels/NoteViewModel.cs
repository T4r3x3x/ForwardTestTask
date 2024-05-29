using Avalonia.Controls;

using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Presentation.MessageBoxes;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;

namespace ForwardTestTask.ViewModels;

public class NoteViewModel : ViewModelBase
{
    private readonly INoteService _noteService;

    public NoteViewModel(INoteService noteService, Window window)
    {
        _noteService = noteService;
        _noteService.Notes.Subscribe(UpdateCollection);

        Window = window;

        AddNoteCommand = ReactiveCommand.CreateFromTask(AddNote);
        DeleteNoteCommand = ReactiveCommand.CreateFromTask<Guid>(DeleteNote);
        EditNoteCommand = ReactiveCommand.CreateFromTask<EditNoteModel>(EditNote);
    }

    #region Properties
    [Reactive] public IEnumerable<Note> Notes { get; private set; }
    public Window Window { get; }
    #endregion

    #region Commands
    public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }
    public ReactiveCommand<Guid, Unit> DeleteNoteCommand { get; set; }
    public ReactiveCommand<EditNoteModel, Unit> EditNoteCommand { get; }
    #endregion

    #region Methods
    private async Task AddNote() => await _noteService.AddAsync(null);

    private async Task DeleteNote(Guid guid)
    {
        var result = await MessageBoxHelper.ShowConfirmMessageBoxAsync(Window, "Вы уверены, что хотите удалить заметку?");
        if (result)
            await _noteService.DeleteAsync(guid);
    }

    private async Task EditNote(EditNoteModel editNoteModel) => await _noteService.EditAsync(editNoteModel);

    /// <summary>
    ///Костыль, который нужен чтобы нормально обновлялась вью: если не меняется ссылка у отображаемого объект,
    ///то ItemsControl (как и ListBox) не изменяются
    /// </summary>
    /// <param name="source"></param>
    private void UpdateCollection(IEnumerable<Note> source)
    {
        Notes = null!;
        Notes = source;
    }
    #endregion
}