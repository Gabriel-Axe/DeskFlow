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


    public async Task AdicionarInteracao(int id, string comentario)
    {
      var chamado = await _repository.ObterPorId(id);
      if (chamado is null || chamado.Status == ChamadoStatus.FECHADO) return;
      chamado.Interacoes.Add(comentario);
    }

    public async Task<Chamado?> AtualizarPorId(int id, ChamadoDto dto)
    {
      var chamado = new Chamado(dto);
      await _repository.AtualizarPorId(id, chamado);
      return chamado;
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

    public async Task<List<Chamado?>> Listar()
    {
      return await _repository.Listar();
    }

    public async Task<List<Chamado?>> ListarComFiltros(ChamadoFiltroDto dto)
    {
      return await _repository.ListarComFiltros(dto);
    }

    public Task<Chamado> ObterPorId(int id) => _repository.ObterPorId(id);

    public async Task<Chamado> RegistrarChamado(ChamadoDto dto) 
    {
      var chamado = new Chamado(dto);
      await _repository.RegistrarChamado(chamado);
      return chamado;
    }

    public async Task SalvarMudancas() => await _repository.SalvarMudancas();


}
