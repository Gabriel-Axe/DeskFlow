using DeskFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Chamado> Chamados => Set<Chamado>();
  public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>(cat => {
            cat.ToTable("tb_categorias"); // WARN: To configurando o mesmo no modelo
            cat.HasKey(c => c.Id); // WARN: Pra que isso?
            cat.Property(c => c.Nome) // WARN: Isso eh permitido?
             .HasColumnName("nome")
             .HasColumnType("varchar(64)")
             .IsRequired();
            });
    }
}
