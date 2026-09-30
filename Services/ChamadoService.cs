namespace DeskFlow.Services;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;

public class ChamadoService : IChamadoService
{

  private IChamadoRepository _repository;

  public ChamadoService(IChamadoRepository repository)
  {
    _repository = repository;
  }



    public async Task<Interacao?> AdicionarInteracaoAsync(int chamadoId, InteracaoDto dto)
    {
      var chamado = await _repository.ObterPorIdAsync(chamadoId);
      if (chamado is null || chamado.Status == ChamadoStatus.FECHADO) return null;
      var interacao = new Interacao(dto);
      chamado.Interacoes.Add(interacao);
      return interacao;
    }

    public async Task<Chamado?> AtualizarPorIdAsync(int id, ChamadoDto dto)
    {
      var chamado = new Chamado(dto);
      await _repository.AtualizarPorId(id, chamado);
      return chamado;
    }

    public async Task EncerrarChamadoComIdAsync(int id)
    {
      var chamado = await _repository.ObterPorIdAsync(id);
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
	 public async Task IniciarChamadoComIdAsync(int id)
	{
    var chamado = await _repository.ObterPorIdAsync(id);
    if (chamado is null) return;

    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    _repository.SalvarMudancas();
    // await _context.SaveChangesAsync();
	}

    public async Task<List<Chamado?>> ListarAsync()
    {
      return await _repository.Listar();
    }

    public async Task<List<Chamado?>> ListarComFiltrosAsync(ChamadoFiltroDto dto)
    {
      return await _repository.ListarComFiltros(dto);
    }

    public async Task<ChamadoDetalhesDto?> ObterDetalhesAsync(int id)
    {
      var chamado = await _repository.ObterPorIdAsync(id);
      if (chamado is null) return null;
      var detalhes = chamado.ObterDetalhes();
      return detalhes;
    }

    public Task<Chamado> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);

    public async Task<Chamado> RegistrarChamadoAsync(ChamadoDto dto) 
    {
      var chamado = new Chamado(dto);
      await _repository.RegistrarChamado(chamado);
      return chamado;
    }

    public async Task SalvarMudancas() => await _repository.SalvarMudancas();
}
