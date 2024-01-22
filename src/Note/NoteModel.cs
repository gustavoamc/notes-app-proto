namespace napp.note.model;

public class NoteModel
{
  public required int Id { get; init; }
  public required DateTime CreatedAt { get; init; }
  public required DateTime LastEdited { get; set; }
  public required string Content { get; set; }

}