namespace napp.note.dto;

public class ResponseNoteDto
{
  public int Id { get; init; }
  public DateTime CreatedAt { get; set; }
  public DateTime LastEdited { get; set; }
  public string Content { get; set; } = "";
}