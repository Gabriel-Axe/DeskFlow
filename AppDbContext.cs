using DeskFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  // public AppDbContext(DbContextOptions options) : base(options)
  public AppDbContext() : base()
  {
  }

  public DbSet<Chamado> Chamados => Set<Chamado>();
}
