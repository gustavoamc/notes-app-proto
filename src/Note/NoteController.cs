using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using napp.note.model;

namespace napp.note.controller;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
  private readonly DataContext _context;

  public NoteController(DataContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<NoteModel>> Get()
  {
    var notes = await _context.Notes.ToListAsync();
    return Ok(notes);
  }

  [HttpGet("{Id}")]
  public async Task<ActionResult<NoteModel>> GetById(int Id)
  {
    var note = await _context.Notes.FindAsync(Id);

    if (note is null)
    {
      return BadRequest("Nota não encontrada");
    }

    return Ok(note);
  }

  [HttpPost]
  public async Task<ActionResult<NoteModel>> AddNote([FromBody] NoteModel note)
  {
    _context.Notes.Add(note);

    await _context.SaveChangesAsync();
    return Ok(note);
  }

  [HttpPut]
  public async Task<ActionResult<NoteModel>> UpdateNote(NoteModel note)
  {
    var dbNote = _context.Notes.Find(note.Id);

    if (dbNote is null)
    {
      return BadRequest("Nota não encontrada");
    }

    dbNote.Content = note.Content;

    await _context.SaveChangesAsync();
    return Ok(note);
  }

  [HttpDelete("{Id}")]
  public async Task<ActionResult<NoteModel>> Delete(int Id)
  {
    var note = await _context.Notes.FindAsync(Id);

    if (note is null)
    {
      return BadRequest("Nota não encontrada");
    }

    _context.Notes.Remove(note);

    await _context.SaveChangesAsync();
    return Ok("Nota removida");
  }
}