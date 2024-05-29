using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Common;

namespace ForwardTestTask.Domain.Repositories.Abstraction.Interfaces
{
    public interface INoteRepository : IAddable<Note>, IDeletable<Guid>, IEditable<EditNoteModel>
    {
        IObservable<IEnumerable<Note>> Notes { get; }
    }
}