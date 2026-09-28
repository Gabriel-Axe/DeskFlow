namespace DeskFlow.Repositories;

using DeskFlow;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
  // Alem disso, preciso mesmo retornar o chamado?
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

    public async Task<List<Chamado?>> Listar()
    {
      return await _context.Chamados.ToListAsync();
    }


    public async Task<List<Chamado?>> ListarComFiltros(ChamadoFiltroDto dto)
    {
      return await _context.Chamados
        .Where(c => c.Titulo == dto.Titulo)
        .Where(c => c.Descricao == dto.Descricao)
        .Where( c=> dto.SolicitanteNome == c.SolicitanteNome)
        .Where(c => dto.Status == c.Status)
        // .Where(c => dto.DataAbertura == c.DataAbertura)
        // .Where(c => dto.DataFechamento == c.DataFechamento);
        .ToListAsync();
    }

    public async Task<Chamado?> AtualizarPorId(int id, Chamado chamado)
    {
      var old = await _context.Chamados.FindAsync(id);
      old.Atualizar(chamado);
      SalvarMudancas();
      return old;
    }
}
