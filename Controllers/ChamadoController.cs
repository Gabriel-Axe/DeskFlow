using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.Controllers;

[ApiController]
[Route("api/chamados")]
// WARN: nao sei se eh assim que determina a rota
public class ChamadoController : ControllerBase
{
  //WARN: Substitutir isto por um repositorio
  // private List<Chamado> chamados => new();
  private IChamadoRepository _chamadoRepository;
  public ChamadoController(IChamadoRepository repository)
  {
    _chamadoRepository = repository;
  }

  [HttpPost]
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  {
    await _chamadoRepository.RegistrarChamado(chamado);
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public IActionResult IniciarAtendimento([FromRoute] int id) {
    // WARN: Muito curto?
    return _chamadoRepository.IniciarAtendimento(id);
  }

  [HttpPost("{id}/encerrar")]
  public IActionResult EncerrarAtendimento([FromRoute] int id) {
    // WARN: Denovo, muito curto...
    _chamadoRepository.EncerrarChamado(id);
  }
}
