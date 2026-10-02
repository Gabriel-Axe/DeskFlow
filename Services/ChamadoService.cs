namespace DeskFlow.Services;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

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

    public async Task<Chamado?> EncerrarChamadoAsync(int id, EncerrarChamadoDto dto)
    {
      var chamado = await _repository.ObterPorIdAsync(id);
      if (chamado is null 
          // || chamado.Status != ChamadoStatus.EM_ANDAMENTO NOTE: Nao ha nada escrito que isso eh possivel ou impossivel
          || string.IsNullOrWhiteSpace(dto.Solucao)) return null;
      chamado.Solucao = dto.Solucao;
      chamado.Status = ChamadoStatus.FECHADO;
      chamado.DataFechamento = DateTime.Now;
      await _repository.SalvarMudancasAsync();
      return chamado;
    }

  // NOTE: Eh retornado o chamado nullavel para garantir que a operacao
  // teve sucesso
  // Era isso ou true e false
	 public async Task<Chamado?> IniciarChamadoComIdAsync(int id)
	{
    var chamado = await _repository.ObterPorIdAsync(id);
    if (chamado is null || chamado.Status != ChamadoStatus.ABERTO) return null;

    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    await _repository.SalvarMudancasAsync();
    return chamado;
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
      var chamado = await _repository.ObterDetalhesPorIdAsync(id);
      if (chamado is null) return null;
      var detalhes = chamado.ObterDetalhes();
      return detalhes;
    }

    public Task<Chamado> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);

    public async Task<Chamado> RegistrarChamadoAsync(ChamadoDto dto) 
    {
      // NOTE: Tambem seria interessante uma fabrica aqui
      var chamado = new Chamado(dto);
      await _repository.RegistrarChamado(chamado);
      return chamado;
    }

    public async Task SalvarMudancas() => await _repository.SalvarMudancasAsync();
}
