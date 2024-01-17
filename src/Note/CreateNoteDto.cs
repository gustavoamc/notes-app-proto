using System.ComponentModel.DataAnnotations;

namespace napp.note.dto;

public class CreateNoteDto
{
  // <summary>weekday of reference</summary>
  /// <example>Monday</example>
  [Required]
  public required DateTime CreatedAt;

  // <summary>Amount of minutes of tolerance</summary>
  /// <example>30</example>
  [Required]
  public required DateTime LastEdited;

  // <summary>any notes of this tolerance record</summary>
  /// <example>only active while someone is in vacation</example>
  [Required]
  public required string Content;
}