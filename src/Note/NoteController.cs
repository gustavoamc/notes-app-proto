using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using napp.note.dto;
using napp.note.model;
using napp.note.service;

namespace napp.note.controller;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{

  private readonly INoteService _noteService;

  public NoteController(
      INoteService noteService
  )
  {
    _noteService = noteService;
  }


  /// <summary> //this type of swagger comment is not working, TODO fix
  /// Fetches all notes in the db.
  /// </summary>
  [HttpGet]
  public async Task<ActionResult<IEnumerable<NoteModel>>> Get()
  {
    IEnumerable<ResponseNoteDto> notes = await _noteService.GetAsync();

    return Ok(notes);
  }


  /// <summary>
  /// Fetches one note.
  /// </summary>
  [HttpGet("{id}")]
  public async Task<ActionResult<ResponseNoteDto>> GetById(int id)
  {
    ResponseNoteDto? note = await _noteService.FindAsync(id);

    if (note is null)
    {
      return BadRequest("Nota não encontrada");
    }

    return Ok(note);
  }

  [HttpPost]
  public async Task<ActionResult<ResponseNoteDto>> AddNote([FromBody] CreateNoteDto noteDto)
  {
    try
    {
      await _noteService.PostAsync(noteDto);

      return Ok(noteDto);
    }
    catch (Exception)
    {
      return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
    }
  }

  [HttpPut]
  public async Task<ActionResult> UpdateNote([FromBody] ResponseNoteDto noteDto)
  {
    bool isSuccessful = await _noteService.PutAsync(noteDto);

    if (isSuccessful is false)
    {
      return BadRequest("Nota não atualizada");
    }

    return Ok("Nota atualizada");
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(int id)
  {
    bool isSuccessful = await _noteService.DeleteAsync(id);

    if (isSuccessful is false)
    {
      return BadRequest("Nota não encontrada");
    }

    return Ok("Nota removida");
  }
}