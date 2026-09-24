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
  private List<Chamado> chamados => new();

  [HttpPost]
  // public Task<IActionResult> CriarNovoChamado([FromBody] Chamado chamado)
  public IActionResult CriarNovoChamado([FromBody] Chamado chamado)
  {
    chamados.Add(chamado); // WARN: Talvez lista nao de pra adicionar async,
                          // ou to fazendo errado
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public IActionResult IniciarAtendimento([FromRoute] int id) {
    var chamado = chamados.Find(c => c.Id == id);
    if (chamado == null) return Ok();
    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok();
  }

  [HttpPost("{id}/encerrar")]
  public IActionResult EncerrarAtendimento([FromRoute] int id) {
    var chamado = chamados.Find(c => c.Id == id);
    if (chamado == null) return Ok();
    chamado.Status = ChamadoStatus.FECHADO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok();
  }

  // WARN: Temporario
  // NOTE: Pesquisar como retornar lista de coisas
  // [HttpGet]
  // public Task<IActionResult> EncerrarAtendimento([FromRoute] int id) {
  //   // return Ok(chamados);
  // }
}
