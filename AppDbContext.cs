using DeskFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Chamado> Chamados => Set<Chamado>();
  public DbSet<Categoria> Categorias => Set<Categoria>();
}
