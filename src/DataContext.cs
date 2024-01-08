using Microsoft.EntityFrameworkCore;
using napp.note.model;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {

  }

  public DbSet<NoteModel> Notes { get; set; }
}