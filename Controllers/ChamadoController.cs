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
  private IChamadoService _service;
  public ChamadoController(IChamadoService service)
  {
    _service = service;
  }

  [HttpGet("{id}")]
  // WARN: Avaliar se eh interessante retirar esse oneliner monstruoso
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<IActionResult> ObterPorId(int id) => Ok(await _service.ObterPorId(id));

  [HttpPost]
  // NOTE: Criar DTOs assim que possivel
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  {
    await _service.RegistrarChamado(chamado);
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public async Task<IActionResult> IniciarAtendimento([FromRoute] int id) {
    // WARN: Muito curto?
    // WARN: Pera, o que eu to retornando aqui? Acho que confundi com o repository
    // return await _chamadoRepository.IniciarAtendimento(id);
    await _service.IniciarChamadoComId(id);
    // WARN: Seria interessante retornar 404 se nao existe?
    // if (chamado is null) return NotFound();
    return Ok();
  }

  [HttpPost("{id}/encerrar")]
  public async Task<IActionResult> EncerrarAtendimento([FromRoute] int id) {
    // WARN: Denovo, muito curto...
    await _service.EncerrarChamadoComId(id);
    // WARN: Seria interessante retornar 404 se nao existe?
    // if (chamado is null) return NotFound();
    return Ok();
  }
}
