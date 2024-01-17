using napp.note.dto;

namespace napp.note.service;

public interface INoteService
{
  public Task<IEnumerable<ResponseNoteDto>> GetAsync();
  public Task<ResponseNoteDto?> FindAsync(int Id);
  public Task<ResponseNoteDto> PostAsync(CreateNoteDto noteDto);
  public Task<bool> PutAsync(ResponseNoteDto noteDto);
  public Task<bool> DeleteAsync(int Id);
}