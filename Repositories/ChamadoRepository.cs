namespace DeskFlow.Repositories;

using DeskFlow;
using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
    var chamado = await _context.Chamados.FindAsync(id);
    // WARN: ! Nao sei se retorna a entidade com o id especificado
    return chamado;
  }



  public async Task SalvarMudancasAsync() => await _context.SaveChangesAsync();

    public async Task<List<Chamado?>> Listar()
    {
      return await _context.Chamados.ToListAsync();
    }

    public async Task<List<Chamado>> ListarComFiltros(ChamadoFiltroDto dto)
    {
      var query = _context.Chamados.AsQueryable();
      if (dto.Status != null) query = query.Where(c => c.Status == dto.Status);
      if (dto.Prioridade != null) query = query.Where(c => c.Prioridade == dto.Prioridade);

      return await query.ToListAsync();
    }

    public async Task<Chamado?> AtualizarPorId(int id, Chamado chamado)
    {
      var old = await _context.Chamados.FindAsync(id);
      old.Atualizar(chamado);
      return old;
    }

    public async Task<Chamado?> ObterDetalhesPorIdAsync(int id)
    {
      return await _context.Chamados
        .Include(c => c.Categoria)
        .Include(c => c.Interacoes)
        .FirstOrDefaultAsync(c => c.Id == id);
    }
}
