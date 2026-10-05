namespace DeskFlow.Repositories.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface IChamadoRepository : IRepository
{
  // public Task<Chamado> RegistrarChamado(Chamado chamado);
  public Task RegistrarChamado(Chamado chamado);
  public Task<List<Chamado>> Listar();
  public Task<List<Chamado>> ListarComFiltros(ChamadoFiltroDto dto);
  public Task<bool> ValidarChamado(ChamadoDto dto);
  public Task<Chamado?> ObterPorIdAsync(int id);
  public Task<ChamadoListaDto?> ObterShallowPorIdAsync(int id);
  public Task<Chamado?> AtualizarPorId(int id, Chamado chamado);
}
