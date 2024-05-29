using ForwardTestTask.Core.Services.Interfaces;
using ForwardTestTask.Domain.Entities;
using ForwardTestTask.Domain.Repositories.Abstraction.Interfaces;
using ForwardTestTask.Presentation.Models;

namespace ForwardTestTask.Core.Services.Implementations
{
    /// <summary>
    /// По сути получился антипаттерн полтергейст, но это из-за того, что в приложении по сути нет никакой бизнес логики 
    /// </summary>
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
            Notes = noteRepository.Notes;
        }

        public IObservable<IEnumerable<Note>> Notes { get; }

        public async Task<bool> AddAsync(AddNoteModel addNoteModel)
        {
            var note = new Note(addNoteModel.Title, addNoteModel.Description);
            return await _noteRepository.AddAsync(note);
        }

        public async Task<bool> DeleteAsync(Guid guid) => await _noteRepository.DeleteAsync(guid);

        public async Task<bool> EditAsync(NoteDto editNoteModel) => await _noteRepository.EditAsync(editNoteModel);
    }
}