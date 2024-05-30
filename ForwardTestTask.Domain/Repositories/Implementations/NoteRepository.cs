using ForwardTestTask.Domain.Dto;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        //можно и обычный лист использовать, но в целом такой будет поприкольнее: быстрее добавление и удаление
        private readonly BehaviorSubject<LinkedList<Note>> _notesSubject = new([]);

        public IObservable<IEnumerable<Note>> Notes => _notesSubject;

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
                .FirstOrDefault(x => x.Guid == editNoteModel.Guid);

            if (note is null)
                return Task.FromResult(false);

            note.Edit(editNoteModel);
            _notesSubject.OnNext(_notesSubject.Value);
            return Task.FromResult(true);
        }
    }
}