using DeskFlow.Models.Entities;

public interface IChamadoService
{
  public Task<Chamado> ObterPorId(int id);
  public Task<Chamado> RegistrarChamado(Chamado chamado);
  public Task IniciarChamadoComId(int id);
  public Task EncerrarChamadoComId(int id);
}
