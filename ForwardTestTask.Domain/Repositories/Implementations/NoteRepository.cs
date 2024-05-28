using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
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