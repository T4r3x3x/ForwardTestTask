using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;

using System.Reactive.Subjects;

namespace ForwardTestTask.Domain.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        //можно выбрать и обычный list, но в связном списке будут быстрее производится операции удаления и добавления
        private readonly LinkedList<Note> _notes = new();
        private readonly BehaviorSubject<LinkedList<Note>> _notesBehaviorSubject = new([]);

        public IObservable<IEnumerable<Note>> Notes { get; }

        public NoteRepository() => Notes = _notesBehaviorSubject;

        public Task<bool> AddAsync(Note note)
        {
            _notesBehaviorSubject.Value.AddLast(note);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            var note = _notesBehaviorSubject.Value.
                Single(x => x.Guid == guid);
            _notesBehaviorSubject.Value.Remove(note);
            return Task.FromResult(true);
        }

        public Task<bool> EditAsync(EditNoteModel editNoteModel)
        {
            var note = _notesBehaviorSubject.Value
                .Single(x => x.Guid == editNoteModel.Guid);
            note.Edit(editNoteModel);
            return Task.FromResult(true);
        }
    }
}