using AutoMapper;
using napp.note.dto;
using napp.note.model;

namespace napp.automapper;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<CreateNoteDto, NoteModel>();
    CreateMap<NoteModel,ResponseNoteDto>();
  }
}