using AutoMapper;
using Microsoft.EntityFrameworkCore;
using napp.note.dto;
using napp.note.model;

namespace napp.note.service;

public class NoteService : INoteService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public NoteService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        NoteModel? note = await _context.Notes.FindAsync(id);

        if (note == null)
        {
            return false;
        }

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ResponseNoteDto?> FindAsync(int id)
    {
        NoteModel? note = await _context.Notes.FindAsync(id);

        if (note == null)
        {
            return null;
        }

        return _mapper.Map<ResponseNoteDto?>(note);
    }

    public async Task<IEnumerable<ResponseNoteDto>> GetAsync()
    {
        List<NoteModel> notes = await _context.Notes.ToListAsync();

        return notes.Select(notes => _mapper.Map<ResponseNoteDto>(notes));
    }

    public async Task<ResponseNoteDto> PostAsync(CreateNoteDto noteDto)
    {
        NoteModel note = _mapper.Map<NoteModel>(noteDto);

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return _mapper.Map<ResponseNoteDto>(await _context.Notes.FindAsync(note.Id));
    }

    public async Task<bool> PutAsync(ResponseNoteDto noteDto)
    {
        NoteModel? note = await _context.Notes.FindAsync(noteDto.Id);

        if (note == null) {
            return false;
        }

        _context.Notes.Attach(note);

        //note.LastEdited = DateTime.UtcNow; doing it now in the front end, for testing //TODO change to do it here if goes to "production"
        note.Content = noteDto.Content;

        await _context.SaveChangesAsync();

        return true;
    }
}