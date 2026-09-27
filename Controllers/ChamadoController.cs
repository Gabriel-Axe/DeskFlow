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

  [HttpGet("id")]
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<IActionResult> ObterPorId(int id)
  {
    var chamado = await _chamadoRepository.ObterPorId(id);
    return Ok(chamado);
  }

  [HttpPost]
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  {
    await _chamadoRepository.RegistrarChamado(chamado);
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public async Task<IActionResult> IniciarAtendimento([FromRoute] int id) {
    // WARN: Muito curto?
    // WARN: Pera, o que eu to retornando aqui? Acho que confundi com o repository
    // return await _chamadoRepository.IniciarAtendimento(id);
    var chamado = await _chamadoRepository.IniciarAtendimento(id);
    if (chamado is null) return NotFound();
    return Ok(chamado);
  }

  [HttpPost("{id}/encerrar")]
  public IActionResult EncerrarAtendimento([FromRoute] int id) {
    // WARN: Denovo, muito curto...
    var chamado = _chamadoRepository.EncerrarChamado(id);
    if (chamado is null) return NotFound();
    return Ok(chamado);
  }
}
