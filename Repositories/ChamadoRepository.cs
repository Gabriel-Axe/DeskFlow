using DeskFlow;
using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class ChamadoRepository : IChamadoRepository
{
  // WARN: Repositorios nao servem para realizar operacoes,
  // apenas procurar dados no banco
  private AppDbContext _context;
  public ChamadoRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task RegistrarChamado(Chamado chamado)
	{
    await _context.AddAsync(chamado);
    await _context.SaveChangesAsync();
	}

	//  public Task<List<Chamado>> ListarChamados()
	// {
	// }
  public async Task<Chamado?> ObterPorId(int id)
  {
    var chamado = await _context.Chamados.FindAsync(id); // WARN: Nao sei se retorna a entidade
    // com o id especificado
    return chamado;
  }

	 public async Task<IActionResult> IniciarAtendimento(int id)
	{
    var chamado = await ObterPorId(id);
    if (chamado is null)
    {
      return NotFound();
    }

    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    await _context.SaveChangesAsync();
	}

	 public async Task<IActionResult> EncerrarChamado(int id)
	 {
      var chamado = await ObterPorId(id);
      if (chamado is null) return NotFound();
      chamado.Status = ChamadoStatus.FECHADO;
      _context.SaveChangesAsync();
      return Ok();
	 }
}
