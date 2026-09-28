namespace DeskFlow.Services;

using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;

public class ChamadoService : IChamadoRepository
{

  private IChamadoRepository _repository;

  public ChamadoService(IChamadoRepository repository)
  {
    _repository = repository;
  }

    public async Task AdicionarInteracao(int id, string comentario)
    {
      var chamado = await _repository.ObterPorId(id);
      if (chamado is null || chamado.Status == ChamadoStatus.FECHADO) return;
      chamado.Interacoes.Add(comentario);
    }

    public async Task EncerrarChamadoComId(int id)
    {
      var chamado = await _repository.ObterPorId(id);
      if (chamado is null) return;
      chamado.Status = ChamadoStatus.FECHADO;
      // _repository.
      // return chamado;
      // _repository.ObterPorId();
      _repository.SalvarMudancas();
    }

  // NOTE: Eh retornado o chamado nullavel para garantir que a operacao
  // teve sucesso
  // Era isso ou true e false
	 public async Task IniciarChamadoComId(int id)
	{
    var chamado = await _repository.ObterPorId(id);
    if (chamado is null) return;

    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    _repository.SalvarMudancas();
    // await _context.SaveChangesAsync();
	}

    public Task<Chamado> ObterPorId(int id) => _repository.ObterPorId(id);

    public async Task<Chamado> RegistrarChamado(Chamado chamado) => await _repository.RegistrarChamado(chamado); 
}
