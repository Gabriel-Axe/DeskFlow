namespace DeskFlow.Services.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface IChamadoService
{
  // NOTE: Ha espaco para criar um "ICrudService", no entanto nao
  // seria inteligente no momento e seria otimizacao prematura
  public Task<Chamado?> ObterPorIdAsync(int id);
  public Task<ChamadoDetalhesDto?> ObterDetalhesAsync(int id);
  public Task<Chamado> RegistrarChamado(ChamadoDto dto);
  public Task IniciarChamadoComId(int id);
  public Task AdicionarInteracao(int id, string comentario);
  public Task EncerrarChamadoComId(int id);
  public Task<List<Chamado?>> Listar();
  public Task<Chamado?> AtualizarPorId(int id, ChamadoDto dto);
  public Task<List<Chamado?>> ListarComFiltrosAsync(ChamadoFiltroDto dto);
}
