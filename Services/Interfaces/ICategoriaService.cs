namespace DeskFlow.Services.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface ICategoriaService
{
  public Task<Categoria> ObterPorIdAsync(int id);
  public Task<Categoria> RegistrarCategoria(CategoriaDto dto);
  public Task<Categoria?> AtualizarCategoria(int id, CategoriaDto dto);
  public Task DeletarCategoria(int id);
  public Task<List<Categoria>> ListarCategorias();
}
