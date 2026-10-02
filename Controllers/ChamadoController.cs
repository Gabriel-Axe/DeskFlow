namespace DeskFlow.Controllers;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/chamados")]
public class ChamadoController : ControllerBase
{
  private IChamadoService _service;
  public ChamadoController(IChamadoService service)
  {
    _service = service;
  }

  [HttpGet("{id}")]
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
    // return Ok(chamado);
    return Created();
  }

  [HttpPost("{id}/interacoes")]
  public async Task<ActionResult<Interacao>> AdicionarInteracaoAoChamado([FromRoute] int id, [FromBody] InteracaoDto dto)
  {
    var interacao = await _service.AdicionarInteracaoAsync(id, dto);
    if (interacao is null) return BadRequest(); // NOTE: Ha multiplos motivos pelo qual esse metodo pode falhar
    return Ok(interacao);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Chamado?>> AtualizarChamado([FromRoute] int id, [FromBody] ChamadoDto dto)
  {
    var novo = await _service.AtualizarPorIdAsync(id, dto);
    if (novo is null) return NotFound();
    return Ok(novo);
  }

  [HttpGet]
  public async Task<ActionResult<List<Chamado>>> ListarComFiltros([FromQuery] ChamadoFiltroDto dto)
  {
    return Ok(await _service.ListarComFiltrosAsync(dto));
  }

  [HttpPost("{id}/iniciar")]
  public async Task<IActionResult> IniciarAtendimento([FromRoute] int id) {
    var chamado = await _service.IniciarChamadoComIdAsync(id);
    if (chamado is null) return NotFound();
    return Ok();
  }

  [HttpPost("{id}/encerrar")]
  public async Task<IActionResult> EncerrarAtendimento([FromRoute] int id, [FromBody] EncerrarChamadoDto dto) {
    var chamado = await _service.EncerrarChamadoAsync(id, dto);
    if (chamado is null) return NotFound();
    return Ok();
  }
}
