using ForwardTestTask.Domain.Dto;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

using System.Reactive.Subjects;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly Dictionary<Guid, Note> _notes = new();
        private readonly BehaviorSubject<IEnumerable<Note>> _notesSubject = new([]);

        public IObservable<IEnumerable<Note>> Notes => _notesSubject;

        public Task<bool> AddAsync(Note note)
        {
            var addResult = _notes.TryAdd(note.Guid, note);
            _notesSubject.OnNext(_notes.Values);
            return Task.FromResult(addResult);
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            var removeResult = _notes.Remove(guid);
            _notesSubject.OnNext(_notes.Values);
            return Task.FromResult(removeResult);
        }

        public Task<bool> EditAsync(NoteDto editNoteModel)
        {
            var getResult = _notes.TryGetValue(editNoteModel.Guid, out var note);
            if (!getResult)
                return Task.FromResult(false);
            note!.Edit(editNoteModel);
            _notesSubject.OnNext(_notes.Values);
            return Task.FromResult(true);
        }
    }
}