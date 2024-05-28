using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;

namespace ForwardTestTask.Core.Services.Implementations
{
    public class NoteService : INoteService
    {
        public IObservable<IEnumerable<Note>> Notes => throw new NotImplementedException();

        public Task<bool> AddAsync(Note entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Note entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(EditNoteModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
