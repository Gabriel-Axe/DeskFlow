using Microsoft.EntityFrameworkCore;

public class CategoriaRepository : ICategoriaRepository
{
  private AppDbContext _context;
  public CategoriaRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task RegistrarCategoria(Categoria categoria)
	{
    await _context.Categorias.AddAsync(categoria);
    _context.SaveChangesAsync();
	}
  public async Task<List<Categoria>> ListarCategorias()
	{
    var lista = _context.Categorias.ToListAsync();
    return await lista;
	}
  public async Task DeletarCategoria(int id)
	{
    var categoria = await ObterCategoriaPorIdAsync(id);
    _context.Categorias.Remove(categoria);
    await _context.SaveChangesAsync();
	}
  public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
	{
    // WARN: Nao sei se isto funciona
    var categoria = await _context.Categorias.FindAsync(id);
    return categoria;
	}
}
