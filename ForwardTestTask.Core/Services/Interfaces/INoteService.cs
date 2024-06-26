﻿using ForwardTestTask.Domain.Dto;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Common;
using ForwardTestTask.Presentation.Models;

namespace ForwardTestTask.Core.Services.Interfaces
{
    public interface INoteService : IEditable<NoteDto>, IDeletable<Guid>, IAddable<AddNoteModel>
    {
        IObservable<IEnumerable<Note>> Notes { get; }
    }
}