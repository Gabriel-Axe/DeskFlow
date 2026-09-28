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

            cat
             .HasMany(ca => ca.Chamados)
             .WithOne(ch => ch.Categoria)
             .HasForeignKey(ch => ch.CategoriaId);

            // NOTE: Ainda nao entendo o assunto abaixo...
            // cat
            // .HasMany(ct => ct.Chamados)
            // .WithOne(ch => ch.Categoria)
            // .HasForeignKey(c => c.CategoriaId)
            // .IsRequired();
            });

        modelBuilder.Entity<Chamado>(chm => {
            chm.ToTable("tb_chamados"); 
            chm.HasKey(c => c.Id);

            chm.Property(c => c.Titulo)
             .HasColumnName("titulo")
             .HasColumnType("varchar(128)")
             .IsRequired();

             chm
              .HasMany(c => c.Interacoes)
              .WithOne(i => i.Chamado)
             .HasForeignKey(i => i.ChamadoId);

             // chm.HasMany()
             //  .HasColumnName("interacoes")
            

            // chm.Property(c => c.) // WARN: Isso eh permitido?
            //  .HasColumnName("nome")
            //  .HasColumnType("Titulo(256)")
            //  .IsRequired();

             // chm.HasMany(c => c.a);
            });

    }
}
