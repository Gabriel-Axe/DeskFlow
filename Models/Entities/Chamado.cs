using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskFlow.Models.Entities;

public class Chamado
{
  // WARN: Assumo que eu apenas precise preencher os dadods
  // em AppDbContext.cs e aqui eh apenas para deixar mais
  // explicito...
  [Key]
  public int Id { get; set; }

  [Required]
  [Column("titulo", TypeName = "varchar(128)")]
  public string Titulo { get; set; }
  public string Descricao { get; set; }
  [Required]
  public ChamadoPrioridade Prioridade { get; set; }
  [Required]
  public ChamadoStatus Status { get; set; }
  [Required]
  public string SolicitanteNome { get; set; }
  [Required]
  public DateTime DataAbertura { get; set; }
  public DateTime DataFechamento { get; set; }
  public string Solucao { get; set; }

  public Categoria Categoria { get; set; } = null;
  [Required]
  public int CategoriaId { get; set; }

  public Chamado(int id, string titulo)
  {
    Id = id;
    Titulo = titulo;
  }
}

public enum ChamadoStatus
{
  ABERTO,
  EM_ANDAMENTO,
  FECHADO
}

public enum ChamadoPrioridade
{
  BAIXA,
  MEDIA,
  ALTA
}
