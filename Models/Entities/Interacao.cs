using System.ComponentModel.DataAnnotations;
using DeskFlow.Models.Entities;

public class Interacao
{
    [Key]
    public int Id { get; set; }
    public string Conteudo { get; set; }
    public int ChamadoId { get; set; }
    public Chamado Chamado { get; set; }
    public Interacao() {}
    public Interacao(int chamadoId, string conteudo)
    {
      ChamadoId = chamadoId;
      Conteudo = conteudo;
    }
}
