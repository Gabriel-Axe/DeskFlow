using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;

public class CategoriaService : ICategoriaService
{
  private ICategoriaRepository _repository;

  public CategoriaService(ICategoriaRepository repository)
  {
    _repository = repository;
  }

    public async Task DeletarCategoria(int id)
    {
      // WARN: Nao deveria salvas automaticamente
      await _repository.DeletarCategoria(id);
      await _repository.SalvarMudancas();
    }

    public async Task<List<Categoria>> ListarCategorias()
    {
      return await _repository.ListarCategorias();
    }

    public async Task<Categoria> ObterPorId(int id)
    {
      return await _repository.ObterCategoriaPorIdAsync(id);
    }


    public async Task<Categoria> RegistrarCategoria(CategoriaDto dto)
    {
      var categoria = new Categoria(dto);
      await _repository.RegistrarCategoria(categoria);
      return categoria;
    }

    Task<Categoria> ICategoriaService.ObterPorId(int id)
    {
        throw new NotImplementedException();
    }
}
