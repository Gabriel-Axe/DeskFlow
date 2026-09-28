namespace DeskFlow.Services.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;

public interface IChamadoService
{
  // NOTE: Ha espaco para criar um "ICrudService", no entanto nao
  // seria inteligente no momento e seria otimizacao prematura
  public Task<Chamado?> ObterPorId(int id);
  public Task<Chamado> RegistrarChamado(ChamadoDto dto);
  public Task IniciarChamadoComId(int id);
  public Task AdicionarInteracao(int id, string comentario);
  public Task EncerrarChamadoComId(int id);
  public Task<List<Chamado?>> Listar();
  public Task<List<Chamado?>> ListarComFiltros(ChamadoFiltroDto dto);
  public Task<Chamado?> AtualizarPorId(int id, ChamadoDto dto);
}
