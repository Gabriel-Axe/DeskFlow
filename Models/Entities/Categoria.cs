namespace DeskFlow.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Table("tb_categorias")]
public class Categoria
{
  [Key]
  [Column("id")]
  public int Id { get; set; }

  [Column("nome", TypeName ="varchar(64)")]
  [Required]
  public string Nome { get; set; }

  public ICollection<Chamado> Chamados { get; set; } // NOTE: Pelo que entendi, 1 categoria tem 
  // varios chamados

  // WARN: Nao faco ideia se isso eh correto, e btw colocar ! eh meio errado
  // public ICollection<Chamado> Chamados { get; set; } = null!;

  public Categoria(CategoriaDto dto)
  {
    Nome = dto.Nome;
  }

  public Categoria(int id, string nome)
  {
    Id = id;
    Nome = nome;
  }
}
