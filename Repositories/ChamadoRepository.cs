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

  // WARN: Isso atualmente faz 2 coisas, isso eh ok por agora
  // mas no futuro... eu nao sei, mas eh um behavior nao explicito
  // (enquanto nao documentar o metodo)
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

  public async Task SalvarMudancas() => await _context.SaveChangesAsync();
}
