namespace ForwardTestTask.Domain.Entities
{
    public class NoteDto
    {
        public Guid Guid { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }

        public NoteDto(Guid guid, string title, string? description)
        {
            Guid = guid;
            Title = title;
            Description = description;
        }

        public NoteDto(Note note)
        {
            Guid = note.Guid;
            Title = note.Title;
            Description = note.Description;
        }
    }
}