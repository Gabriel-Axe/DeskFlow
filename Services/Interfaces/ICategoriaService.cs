namespace DeskFlow.Services.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface ICategoriaService
{
  public Task<Categoria?> ObterPorIdAsync(int id);
  public Task<Categoria?> RegistrarCategoria(CategoriaDto dto);
  public Task<Categoria?> AtualizarCategoriaAsync(int id, CategoriaDto dto);
  public Task<bool> DeletarCategoriaPorIdAsync(int id);
  public Task<List<Categoria>> ListarCategorias();
}
