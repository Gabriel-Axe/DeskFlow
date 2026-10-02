namespace DeskFlow.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DeskFlow.Models.DTOs;

// NOTE: Configurado em AppDbContext
public class Chamado
{
  public int Id { get; set; }
  public string Titulo { get; set; }
  public string Descricao { get; set; }
  public ChamadoPrioridade Prioridade { get; set; }
  public ChamadoStatus Status { get; set; }
  public string SolicitanteNome { get; set; }
  public DateTime DataAbertura { get; set; }
  public DateTime? DataFechamento { get; set; }
  public ICollection<Interacao> Interacoes { get; set; } = new List<Interacao>(); // NOTE: aka comentarios de suporte
  // WARN: Todo lugar que eu tocar na Solucao deve
  // reconhecer que eh nulavel agora
  public string? Solucao { get; set; }

  public int CategoriaId { get; set; }
  public Categoria Categoria { get; set; } = null!; // NOTE: Necessario apenas pra remover avisos

  public Chamado(ChamadoDto dto)
  {
    Titulo = dto.Titulo;
    Descricao = dto.Descricao;
    Prioridade = dto.Prioridade;
    SolicitanteNome = dto.SolicitanteNome;
    CategoriaId = dto.CategoriaId;

    DataAbertura = DateTime.Now;
    Status = ChamadoStatus.ABERTO;
  }

  // NOTE: Isto eh necessario para remover avisos do compilador desta linha ate o fim do arquivo, necessario pois o que eh avisado
  // ou faz parte do EF Core ou nao eh estabelecido nas regras de negocio
  // Para delimitar ate onde os avisos sao ignorados use
  // #pragma warning restore 8618, 8524

  #pragma warning disable 8618, 8524 
  public Chamado() {}
  public void Atualizar(Chamado chamado) 
  {
    Titulo = chamado.Titulo;
    Descricao = chamado.Descricao;
    SolicitanteNome = chamado.SolicitanteNome;
  }

  public ChamadoDetalhesDto ObterDetalhes()
  {
    return new ChamadoDetalhesDto(
			Titulo,
			 Descricao,
			 SolicitanteNome,
			 DataAbertura,
             PrioridadeParaString(Prioridade),
             StatusParaString(Status),
       CategoriaId,
       Categoria.ParaDto(),
       Interacoes.ToList());
  }

  private static string PrioridadeParaString(ChamadoPrioridade prioridade)
  {
    return prioridade switch
    {
      ChamadoPrioridade.BAIXA => "baixa",
      ChamadoPrioridade.MEDIA => "media",
      ChamadoPrioridade.ALTA => "alta",
    };
  }

  private static string StatusParaString(ChamadoStatus status)
  {
    return status switch
    {
      ChamadoStatus.ABERTO => "aberto",
      ChamadoStatus.EM_ANDAMENTO => "em andamento",
      ChamadoStatus.FECHADO => "fechado",
    };
  }
  #pragma warning restore 8618, 8524
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
