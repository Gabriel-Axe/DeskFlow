namespace DeskFlow.Controllers;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// WARN: Ha prov incosistencias e redundancias neste arquivo e ICategoriaRepository (e no outro repositorio)

[ApiController]
[Route("api/[controller]")]
// WARN: nao sei se eh assim que determina a rota
public class CategoriaController : ControllerBase
{
  // WARN: Substituir isto por um servico
  private ICategoriaService _service;
  public CategoriaController(ICategoriaService service)
  {
    _service = service;
  }

  [HttpPost]
  public IActionResult CriarNovaCategoria([FromBody] CategoriaDto dto)
  {
    _service.RegistrarCategoria(dto);
    // _repository.RegistrarCategoria(categoria); // WARN: Talvez lista nao de pra adicionar async,
                          // ou to fazendo errado
    return Ok();
  [HttpPut("{id}")]
  public async Task<ActionResult<Categoria>> AtualizarCategoria([FromRoute] int id, [FromBody] CategoriaDto dto)
  {
    var categoria = _service.AtualizarCategoria(id, dto);
    if (categoria is null) return NotFound(); // WARN: Eh possivel que outros erros acontecam nesse metodo
    return Ok(categoria);
  }

  [HttpPost("{id}/iniciar")]
  public IActionResult ObterDetalhesPorId([FromRoute] int id) {
    var categoria = _service.ObterPorId(id);;
    if (categoria == null) return NotFound();
    // categoria.Status = ChamadoStatus.EM_ANDAMENTO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok(categoria);
  }

  [HttpGet]
  // WARN: Possivelmente retorno incorreto
  public async Task<List<Categoria>> ListarCategorias()
  {
    return await _service.ListarCategorias();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletarCategoria([FromRoute] int id)
  {
    await _service.DeletarCategoria(id);
    return Ok();
  }
}
