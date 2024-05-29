namespace ForwardTestTask.Domain.Entities
{
    public class Note
    {
        public Guid Guid { get; init; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedDate { get; init; } = DateTime.Now;
        public DateTime? EditedDate { get; private set; } = null;

        public Note(string title, string? description)
        {
            Title = title;
            Description = description;
        }

        public Note(NoteDto dto)
        {
            Guid = dto.Guid;
            Title = dto.Title;
            Description = dto.Description;
            CreatedDate = DateTime.Now;
        }

        public void Edit(NoteDto editNoteModel)
        {
            Title = editNoteModel.Title;
            Description = editNoteModel.Description;
            EditedDate = DateTime.Now;
        }
    }
}