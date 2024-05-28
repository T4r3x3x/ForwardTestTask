using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly BehaviorSubject<IList<Note>> _notes = new([]);

        public IObservable<IList<Note>> Notes { get; }

        public NoteRepository()
        {
            SetData();
            Notes = _notes;
        }

        private void SetData()
        {
            _notes.Value.Add(new Note("Погулять", "Погулять вечером"));
            _notes.Value.Add(new Note("Поспать", "Поспать после прогулки"));
            _notes.Value.Add(new Note("Поесть", "Поесть творог"));
        }

        public Task<bool> AddAsync(Note note)
        {
            _notes.Value.Add(note);
            _notes.OnNext(_notes.Value);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            var note = _notes.Value
                .Single(x => x.Guid == guid);
            _notes.Value.Remove(note);
            _notes.OnNext(_notes.Value);
            return Task.FromResult(true);
        }

        public Task<bool> EditAsync(EditNoteModel editNoteModel)
        {
            var note = _notes.Value
                .Single(x => x.Guid == editNoteModel.Guid);
            note.Edit(editNoteModel);
            _notes.OnNext(_notes.Value);
            return Task.FromResult(true);
        }
    }
}