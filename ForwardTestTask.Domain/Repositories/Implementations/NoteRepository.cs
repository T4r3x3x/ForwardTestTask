using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly BehaviorSubject<LinkedList<Note>> _notesSubject = new([]);

        public NoteRepository()
        {
            SetData();
        }

        public IObservable<IEnumerable<Note>> Notes => _notesSubject;

        private void SetData()
        {
            _notesSubject.Value.AddLast(new Note("Погулять", "Погулять вечером"));
            _notesSubject.Value.AddLast(new Note("Поспать", "Поспать после прогулки"));
            _notesSubject.Value.AddLast(new Note("Поесть", "Поесть творог вместе с бананами и арасиховой пастой"));
            _notesSubject.OnNext(_notesSubject.Value);
        }

        public Task<bool> AddAsync(Note note)
        {
            _notesSubject.Value.AddLast(note);
            _notesSubject.OnNext(_notesSubject.Value);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            var note = _notesSubject.Value
                .FirstOrDefault(x => x.Guid == guid);

            if (note is null)
                return Task.FromResult(false);

            _notesSubject.Value.Remove(note);
            _notesSubject.OnNext(_notesSubject.Value);
            return Task.FromResult(true);
        }

        public Task<bool> EditAsync(NoteDto editNoteModel)
        {
            var note = _notesSubject.Value
                .Single(x => x.Guid == editNoteModel.Guid);
            note.Edit(editNoteModel);
            _notesSubject.OnNext(_notesSubject.Value);
            return Task.FromResult(true);
        }
    }
}