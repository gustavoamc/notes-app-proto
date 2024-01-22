using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace napp.note.dto;

public class CreateNoteDto
{
  /// <summary>Date and Time of creation</summary>
  /// <example>2024-01-17T14:44:33.678Z</example>
  public required DateTime CreatedAt { get; init; } = DateTime.UtcNow;

  /// <summary>Date and time of last edit</summary>
  /// <example>2024-01-17T14:44:33.678Z</example>
  [Required]
  public required DateTime LastEdited { get; set; } = DateTime.UtcNow;
  

  /// <summary>content of the note</summary>
  /// <example>content</example>
  [Required]
  public required string Content { get; set; }
}