namespace DeskFlow.Services.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface IChamadoService
{
  // NOTE: Ha espaco para criar um "ICrudService", no entanto nao
  // seria inteligente no momento e seria otimizacao prematura
  public Task<Chamado?> ObterPorIdAsync(int id);
  public Task<ChamadoDetalhesDto?> ObterDetalhesAsync(int id);
  public Task<Chamado> RegistrarChamadoAsync(ChamadoDto dto);
  public Task<Chamado?> IniciarChamadoComIdAsync(int id);
  public Task<Interacao?> AdicionarInteracaoAsync(int chamadoId, InteracaoDto dto);
  public Task<Chamado?> EncerrarChamadoAsync(int id, EncerrarChamadoDto dto);
  public Task<List<Chamado?>> ListarAsync();
  public Task<List<Chamado?>> ListarComFiltrosAsync(ChamadoFiltroDto dto);
  public Task<Chamado?> AtualizarPorIdAsync(int id, ChamadoDto dto);
}
