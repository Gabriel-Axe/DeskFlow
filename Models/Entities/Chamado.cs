namespace DeskFlow.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DeskFlow.Models.DTOs;

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
  public DateTime? DataFechamento { get; set; }
  public ICollection<Interacao> Interacoes { get; set; } // NOTE: aka, comentarios de suporte
  public string Solucao { get; set; }

  public int CategoriaId { get; set; }
  public Categoria Categoria { get; set; }

  public Chamado(ChamadoDto dto)
  {
    // WARN: Colocar outras coisas a pegar dados, ambos do construtor
    // de dto e do metodo de atualizar
    Titulo = dto.Titulo;
    Descricao = dto.Descricao;
    SolicitanteNome = dto.SolicitanteNome;
    CategoriaId = dto.CategoriaId;
  }

  public Chamado() {}
  public void Atualizar(Chamado chamado) 
  {
    Titulo = chamado.Titulo;
    Descricao = chamado.Descricao;
    SolicitanteNome = chamado.SolicitanteNome;
  }

  public ChamadoDetalhesDto ObterDetalhes()
  {
    return new ChamadoDetalhesDto(Titulo, Descricao, SolicitanteNome, CategoriaId, DataAbertura, PrioridadeParaString(Prioridade), StatusParaString(Status));
  }

  private string PrioridadeParaString(ChamadoPrioridade prioridade)
  {
    return prioridade switch
    {
      ChamadoPrioridade.BAIXA => "baixa",
      ChamadoPrioridade.MEDIA => "media",
      ChamadoPrioridade.ALTA => "alta",
    };
  }

  private string StatusParaString(ChamadoStatus status)
  {
    return status switch
    {
      ChamadoStatus.ABERTO => "aberto",
      ChamadoStatus.EM_ANDAMENTO => "em andamento",
      ChamadoStatus.FECHADO => "fechado",
    };
  }
}

public enum ChamadoStatus
{
  ABERTO = 1,
  EM_ANDAMENTO = 2,
  FECHADO = 3
}

public enum ChamadoPrioridade
{
  BAIXA = 1,
  MEDIA = 2,
  ALTA = 3
}
