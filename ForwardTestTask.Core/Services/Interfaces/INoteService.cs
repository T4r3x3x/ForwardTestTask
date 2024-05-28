using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Common;

namespace ForwardTestTask.Core.Services.Interfaces
{
    public interface INoteService : IEditable<EditNoteModel>, IDeletable<Note>, IAddable<Note>
    {
        IObservable<IEnumerable<Note>> Notes { get; }
    }
}