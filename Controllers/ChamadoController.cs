namespace DeskFlow.Controllers;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
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
  public async Task<ActionResult<Chamado>> ObterDetalhes(int id) 
  {
    var detalhes = await _service.ObterDetalhesAsync(id);
    if (detalhes is null) return NotFound();
    return Ok(detalhes);
  }

  [HttpPost]
  // NOTE: Criar DTOs assim que possivel
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public async Task<ActionResult<Chamado>> CriarNovoChamado([FromBody] ChamadoDto dto)
  {
    var chamado = await _service.RegistrarChamadoAsync(dto);
    return Ok(chamado);
  }

  [HttpPut("{id}")]
  public async Task<Chamado?> AtualizarChamado([FromRoute] int id, [FromBody] ChamadoDto dto)
  {
    var novo = await _service.AtualizarPorIdAsync(id, dto);
    // WARN: Ok, eu nao consigo retornar codigos http e ao mesmo tempo um objeto?...
    return novo;
  }

  [HttpGet]
  public async Task<List<Chamado?>> ListarComFiltros([FromQuery] ChamadoFiltroDto dto)
  {
    return await _service.ListarComFiltrosAsync(dto);
  }

  [HttpPost("{id}/iniciar")]
  public async Task<IActionResult> IniciarAtendimento([FromRoute] int id) {
    // WARN: Muito curto?
    // WARN: Pera, o que eu to retornando aqui? Acho que confundi com o repository
    // return await _chamadoRepository.IniciarAtendimento(id);
    await _service.IniciarChamadoComIdAsync(id);
    // WARN: Seria interessante retornar 404 se nao existe?
    // if (chamado is null) return NotFound();
    return Ok();
  }

  [HttpPost("{id}/encerrar")]
  public async Task<IActionResult> EncerrarAtendimento([FromRoute] int id) {
    // WARN: Denovo, muito curto...
    await _service.EncerrarChamadoComIdAsync(id);
    // WARN: Seria interessante retornar 404 se nao existe?
    // if (chamado is null) return NotFound();
    return Ok();
  }
}
