using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Implementation;

namespace ForwardTestTask.Core.Services.Implementations
{
    /// <summary>
    /// По сути получился антипаттерн полтергейст, но это из-за того, что в приложении по сути нет никакой бизнес логики 
    /// </summary>
    public class NoteService : INoteService
    {
        private readonly NoteRepository _noteRepository;

        public NoteService(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
            Notes = _noteRepository.Notes;
        }

        public IObservable<IEnumerable<Note>> Notes { get; }

        public async Task<bool> AddAsync(Note note) => await _noteRepository.AddAsync(note);

        public async Task<bool> DeleteAsync(Guid guid) => await _noteRepository.DeleteAsync(guid);

        public async Task<bool> EditAsync(EditNoteModel editNoteModel) => await _noteRepository.EditAsync(editNoteModel);
    }
}
