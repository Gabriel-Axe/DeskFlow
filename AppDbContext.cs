using DeskFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Chamado> Chamados => Set<Chamado>();
  public DbSet<Categoria> Categorias => Set<Categoria>();
  public DbSet<Interacao> Interacoes => Set<Interacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>(cat => {
            cat.ToTable("tb_categorias");
            cat.HasKey(c => c.Id);
            cat.Property(c => c.Nome)
             .HasColumnName("nome")
             .HasColumnType("varchar(64)")
             .IsRequired();

            cat
             .HasMany(ca => ca.Chamados)
             .WithOne(ch => ch.Categoria)
             .HasForeignKey(ch => ch.CategoriaId);
            });

        // NOTE: Aparentemente muito abaixo eh redundante,
        // como chm.HasKey(c => c.id) e alguns IsRequired

        modelBuilder.Entity<Interacao>(itr => {
            itr.ToTable("tb_interacoes");
            itr.HasKey(i => i.Id);

            itr.Property(i => i.Autor)
             .HasColumnName("autor")
             .HasColumnType("varchar")
             .HasMaxLength(128)
             .IsRequired();

            itr.Property(i => i.DataRegistro)
             .HasColumnName("data_registro")
             .IsRequired();

            itr.Property(i => i.Mensagem)
             .HasColumnName("mensagem")
             .HasColumnType("varchar")
             .HasMaxLength(128)
             .IsRequired();

             itr.HasOne(i => i.Chamado)
               .WithMany(c => c.Interacoes)
               .HasForeignKey(i => i.ChamadoId);

            });

        modelBuilder.Entity<Chamado>(chm => {
            chm.ToTable("tb_chamados"); 
            chm.HasKey(c => c.Id);

            chm.Property(c => c.Titulo)
             .HasColumnName("titulo")
             .HasColumnType("varchar(128)")
             .IsRequired();

            chm.Property(c => c.Descricao)
             .HasColumnName("descricao")
             .HasColumnType("varchar")
             .HasMaxLength(1024) // NOTE: Tmb eh possivel varchar(1024)
             .IsRequired();

            chm.Property(c => c.Solucao)
              .HasColumnName("solucao")
              .HasColumnType("varchar") // NOTE: Tamanho depende das regras de negocio
              .HasMaxLength(1024)
              .IsRequired(false);

            chm.Property(c => c.SolicitanteNome)
              .HasColumnName("solicitante_nome")
              .HasColumnType("varchar")
              .HasMaxLength(64)
              .IsRequired();

            chm.Property(c => c.DataFechamento)
              .HasColumnName("data_fechamento")
              .IsRequired(false);
            // NOTE: Teoricamente, mapeia para datetime2

            chm.Property(c => c.CategoriaId)
              .HasColumnName("categoria_id"); 
            // NOTE: Teoricamente, mapeia para int requerido automaticamente

            chm.Property(c => c.Prioridade)
              .HasColumnName("prioridade");

            chm
              .HasMany(c => c.Interacoes)
              .WithOne(i => i.Chamado)
              .HasForeignKey(i => i.ChamadoId);
            });

    }
}
