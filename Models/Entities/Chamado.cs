namespace DeskFlow.Models.Entities;

public class Chamado
{
  public int Id { get; set; }
  public string Titulo { get; set; }
  public string Descricao { get; set; }
  public ChamadoPrioridade Prioridade { get; set; }
  public ChamadoStatus Status { get; set; }
  public string SolicitanteNome { get; set; }
  public DateTime DataAbertura { get; set; }
  public DateTime DataFechamento { get; set; }
  public string Solucao { get; set; }
  public int CategoriaId { get; set; }

  public Chamado(int id, string nome)
  {
    Id = id;
    Titulo = nome;
  }
}

enum ChamadoStatus
{
  ABERTO,
  EM_ANDAMENTO,
  FECHADO
}
enum ChamadoPrioridade
{
  BAIXA,
  MEDIA,
  ALTA
}
