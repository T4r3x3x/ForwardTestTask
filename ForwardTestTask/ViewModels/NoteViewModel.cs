using Avalonia.Controls;

using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Presentation.MessageBoxes;
using ForwardTestTask.Presentation.Models;
using ForwardTestTask.Presentation.ViewModels;
using ForwardTestTask.Presentation.Views;

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
        EditNoteCommand = ReactiveCommand.CreateFromTask<Note>(EditNote);
    }

    #region Properties
    [Reactive] public IEnumerable<Note> Notes { get; private set; }
    public Window Window { get; }
    #endregion

    #region Commands
    public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }
    public ReactiveCommand<Guid, Unit> DeleteNoteCommand { get; }
    public ReactiveCommand<Note, Unit> EditNoteCommand { get; }
    #endregion

    #region Methods
    private async Task AddNote()
    {
        var vm = new AddNoteViewModel();
        var addNoteWindow = new AddNoteWindow() { DataContext = vm };
        var addNoteModel = await addNoteWindow.ShowDialog<AddNoteModel?>(Window);

        if (addNoteModel is null)
            return;

        var addingResult = await _noteService.AddAsync(addNoteModel);
        if (!addingResult)
            await MessageBoxHelper.ShowErrorMessageBoxAsync(Window, "Something went wrong, can't add the note :(");
    }

    private async Task DeleteNote(Guid guid)
    {
        var result = await MessageBoxHelper.ShowConfirmMessageBoxAsync(Window, "Are you sure you want to delete the note?");
        if (!result)
            return;

        var isDeleted = await _noteService.DeleteAsync(guid);
        if (!isDeleted)
            await MessageBoxHelper.ShowErrorMessageBoxAsync(Window, "Something went wrong, can't delete the note :(");
    }

    private async Task EditNote(Note note)
    {
        var vm = new EditNoteViewModel(new NoteDto(note.Guid, note.Title, note.Description));
        var addNoteWindow = new EditNoteWindow() { DataContext = vm };
        var editNoteModel = await addNoteWindow.ShowDialog<NoteDto?>(Window);

        if (editNoteModel is null)
            return;

        var isEdited = await _noteService.EditAsync(editNoteModel);
        if (!isEdited)
            await MessageBoxHelper.ShowErrorMessageBoxAsync(Window, "Something went wrong, can't edit the note :(");
    }

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