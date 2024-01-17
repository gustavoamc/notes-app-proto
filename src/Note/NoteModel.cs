namespace napp.note.model;

public class NoteModel
{
  public int Id { get; init; }
  public DateTime CreatedAt { get; init; } = DateTime.Now;
  public DateTime LastEdited { get; set; } = DateTime.Now;
  public string Content { get; set; } = "";
  
}