using DeskFlow.Models.Entities;

namespace DeskFlow.Repositories.Interfaces;

public interface ICategoriaRepository : IRepository
{
  public Task RegistrarCategoria(Categoria categoria);
  public Task<List<Categoria>> ListarCategorias();
  public Task<List<Chamado>> ObterChamadosDaCategoriaAsync(int categoriaId);
  public Task DeletarCategoria(int id);
  public Task<Categoria?> ObterCategoriaPorIdAsync(int id);
}
