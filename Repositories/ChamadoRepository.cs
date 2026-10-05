namespace DeskFlow.Repositories;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ChamadoRepository : IChamadoRepository
{
  private AppDbContext _context;
  public ChamadoRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task RegistrarChamado(Chamado chamado)
	{
    await _context.AddAsync(chamado);
	}

  public async Task<Chamado?> ObterPorIdAsync(int id)
  {
      return await _context.Chamados
        .Include(c => c.Categoria)
        .Include(c => c.Interacoes)
        .FirstOrDefaultAsync(c => c.Id == id);
      // WARN: Isso pode trazer um certo... overhead, ao EF Core/Banco
      // Include faz uma subconsulta para incluir categorias
      // Fiz isso porque nao ha como prever, ate o momento
      // que metodo pode precisar de chamado junto de
      // sua categoria
  }

  public async Task SalvarMudancasAsync() => await _context.SaveChangesAsync();

    public async Task<List<Chamado>> Listar()
    {
      return await _context.Chamados.ToListAsync();
    }

    public async Task<List<Chamado>> ListarComFiltros(ChamadoFiltroDto dto)
    {
      Console.WriteLine($"status: {dto.Status}");
      Console.WriteLine($"prioridade: {dto.Prioridade}");
      Console.WriteLine($"categoriaId: {dto.CategoriaId}");
      var query = _context.Chamados.AsQueryable();
      if (!dto.Status.Equals(null)) query = query.Where(c => c.Status == dto.Status);
      if (!dto.Prioridade.Equals(null)) query = query.Where(c => c.Prioridade == dto.Prioridade);
      if (!dto.CategoriaId.Equals(null)) query = query.Where(c => c.CategoriaId == dto.CategoriaId);

      return await query.ToListAsync();
    }

    public async Task<Chamado?> AtualizarPorId(int id, Chamado chamado)
    {
      var old = await _context.Chamados.FindAsync(id);
      if (old is null) return null;
      old.Atualizar(chamado);
      return old;
    }



    public async Task<bool> ValidarChamado(ChamadoDto dto)
    {
      // WARN: Por enquanto, so valida que a categoria de id existe
      if (!await _context.Categorias.AnyAsync(cat => cat.Id == dto.CategoriaId)) return false;
      return true;
    }

    public async Task<ChamadoListaDto?> ObterShallowPorIdAsync(int id)
    {
      return await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
    }
}
