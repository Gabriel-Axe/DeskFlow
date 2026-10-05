namespace DeskFlow.Repositories;

using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CategoriaRepository : ICategoriaRepository
{
  private AppDbContext _context;
  public CategoriaRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Chamado>> ObterChamadosDaCategoriaAsync(int categoriaId)
  {
    // WARN: Isso ta funfando?
    return await _context.Chamados
      .Where(ch => ch.CategoriaId == categoriaId)
      .ToListAsync();
  }

  public async Task RegistrarCategoria(Categoria categoria)
	{
    await _context.Categorias.AddAsync(categoria);
	}

  public async Task<List<Categoria>> ListarCategorias()
	{
    var lista = _context.Categorias.ToListAsync();
    return await lista;
	}
  public async Task DeletarCategoria(int id)
	{
    var categoria = await ObterCategoriaPorIdAsync(id);
    if (categoria is null) return;
    _context.Categorias.Remove(categoria);
	}
  public async Task<Categoria?> ObterCategoriaPorIdAsync(int id)
	{
    // WARN: Nao sei se isto funciona
    var categoria = await _context.Categorias.FindAsync(id);
    return categoria;
	}

  public async Task SalvarMudancasAsync() => await _context.SaveChangesAsync();
}
