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

    public async Task<Categoria?> AtualizarCategoria(int id, CategoriaDto dto)
    {
      var categoria = await _repository.ObterCategoriaPorIdAsync(id);
      if (categoria is null) return null;
      categoria.Atualizar(dto);
      return categoria;
    }

    public async Task DeletarCategoria(int id)
    {
      // WARN: Nao deveria salvas automaticamente
      await _repository.DeletarCategoria(id);
      await _repository.SalvarMudancasAsync();
    }

    public async Task<List<Categoria>> ListarCategorias()
    {
      return await _repository.ListarCategorias();
    }

    public async Task<Categoria> ObterPorIdAsync(int id)
    {
      return await _repository.ObterCategoriaPorIdAsync(id);
    }


    public async Task<Categoria> RegistrarCategoria(CategoriaDto dto)
    {
      var categoria = new Categoria(dto);
      await _repository.RegistrarCategoria(categoria);
      await _repository.SalvarMudancasAsync();
      return categoria;
    }
}
