using System.ComponentModel.DataAnnotations;
using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public class Interacao
{
    [Key]
    public int Id { get; set; }
    public string Autor { get; set; }
    public DateTime DataRegistro { get; set; }
    public string Mensagem { get; set; }
    public int ChamadoId { get; set; }
    public Chamado Chamado { get; set; }

    public Interacao() {}
    public Interacao(InteracaoDto dto)
    {
      Autor = dto.Autor;
      DataRegistro = dto.DataRegistro.Equals(null) ? DateTime.Now : (DateTime) dto.DataRegistro;
    }
    public Interacao(int chamadoId, string autor, string mensagem)
    {
      ChamadoId = chamadoId;
      Autor = autor;
      Mensagem = mensagem;
    }
}
