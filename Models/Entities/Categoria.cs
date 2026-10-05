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
  public int Id { get; set; }
  public string Nome { get; set; }

  public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();// NOTE: Pelo que entendi, 1 categoria tem varios chamados

  public Categoria(CategoriaDto dto)
  {
    Nome = dto.Nome;
  }

  public Categoria(int id, string nome)
  {
    Id = id;
    Nome = nome;
  }

  public void Atualizar(CategoriaDto dto)
  {
    Nome = dto.Nome;
  }

  public CategoriaDto ParaDto()
  {
    return new CategoriaDto(Nome);
  }

  public CategoriaListaDto ParaListagemDto()
  {
    return new CategoriaListaDto(Id, Nome);
  }

  public CategoriaDetalhesDto ParaDetalhesDto()
  {
    return new CategoriaDetalhesDto(Id, Nome, Chamados.Select(c => c.ParaListaDto()).ToList());
  }
}
