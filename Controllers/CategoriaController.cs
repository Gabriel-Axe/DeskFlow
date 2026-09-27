using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.Controllers;

// WARN: Ha prov incosistencias e redundancias neste arquivo e ICategoriaRepository (e no outro repositorio)

[ApiController]
[Route("api/categorias")]
// WARN: nao sei se eh assim que determina a rota
public class CategoriaController : ControllerBase
{
  //WARN: Substitutir isto por um repositorio
  private ICategoriaRepository _repository;
  public CategoriaController(ICategoriaRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public IActionResult CriarNovaCategoria([FromBody] Categoria categoria)
  {
    _repository.RegistrarCategoria(categoria); // WARN: Talvez lista nao de pra adicionar async,
                          // ou to fazendo errado
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public IActionResult ObterDetalhesPorId([FromRoute] int id) {
    var categoria = _repository.ObterCategoriaPorIdAsync(id);
    if (categoria == null) return NotFound();
    // categoria.Status = ChamadoStatus.EM_ANDAMENTO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok(categoria);
  }

  [HttpGet]
  // WARN: Possivelmente retorno incorreto
  public async Task<List<Categoria>> ListarCategorias()
  {
    return await _repository.ListarCategorias();
  }
}
