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
  public async Task<ActionResult<Categoria>> CriarNovaCategoria([FromBody] CategoriaDto dto)
  {
    var categoria = await _service.RegistrarCategoria(dto);
    // _repository.RegistrarCategoria(categoria); // WARN: Talvez lista nao de pra adicionar async,
                          // ou to fazendo errado
    return Ok(categoria);
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
  // WARN: Possivelmente retorno incorreto
  public async Task<List<Categoria>> ListarCategorias()
  {
    return await _service.ListarCategorias();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletarCategoria([FromRoute] int id)
  {
    // WARN: Verificar se a categoria possui chamados antes de deletar
    var sucesso = await _service.DeletarCategoria(id);
    if (!sucesso) return BadRequest(); 
    // WARN: Seria mais adequado saber que erro foi causado,
    // e retornar o codigo apropriado, principalmente porque
    // o erro pode ser ou que a categoria nao existe ou
    // possui dados chamados associados a ela
    return NoContent();
  }
}
