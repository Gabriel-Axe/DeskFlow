namespace DeskFlow.Controllers;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using DeskFlow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categorias")]
public class CategoriaController : ControllerBase
{
  private ICategoriaService _service;
  public CategoriaController(ICategoriaService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<ActionResult<Categoria>> CriarNovaCategoria([FromBody] CategoriaDto dto)
  {
    var categoria = await _service.RegistrarCategoria(dto);
    // NOTE: Preferiria retornar Ok(categoria), mas... ta no documento
    return Created();
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Categoria>> AtualizarCategoria([FromRoute] int id, [FromBody] CategoriaDto dto)
  {
    var categoria = _service.AtualizarCategoria(id, dto);
    if (categoria is null) return NotFound(); // WARN: Eh possivel que outros erros acontecam nesse metodo
    return Ok(categoria);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> ObterPorIdAsync([FromRoute] int id) {
    var categoria = await _service.ObterPorIdAsync(id);;
    if (categoria == null) return NotFound();
    // categoria.Status = ChamadoStatus.EM_ANDAMENTO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok(categoria);
  }

  [HttpGet]
  public async Task<ActionResult<List<Categoria>>> ListarCategorias()
  {
    var categorias = await _service.ListarCategorias();
    return Ok(categorias);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletarCategoria([FromRoute] int id)
  {
    var sucesso = await _service.DeletarCategoriaPorIdAsync(id);
    if (!sucesso) return BadRequest(); 
    // NOTE: Atualmente, apenas verifica se um erro aconteceu, e nao
    // qual erro em especifico, tal porque porque o erro pode ser ou
    // que a categoria nao existe ou possui dados chamados associados a ela
     
    return NoContent();
  }
}
