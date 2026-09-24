using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.Controllers;

[ApiController]
[Route("api/categorias")]
// WARN: nao sei se eh assim que determina a rota
public class CategoriaController : ControllerBase
{
  //WARN: Substitutir isto por um repositorio
  private List<Categoria> categorias => new();

  [HttpPost]
  public IActionResult CriarNovaCategoria([FromBody] Categoria categoria)
  {
    chamados.Add(categoria); // WARN: Talvez lista nao de pra adicionar async,
                          // ou to fazendo errado
    return Ok();
  }

  [HttpPost("{id}/iniciar")]
  public IActionResult ObterDetalhesPorId([FromRoute] int id) {
    var chamado = chamados.Find(c => c.Id == id);
    if (chamado == null) return NotFound();
    chamado.Status = ChamadoStatus.EM_ANDAMENTO;
    // NOTE: Pesquisar como atualizar no banco
    return Ok(chamado);
  }

  [HttpPost]
  // WARN: Possivelmente retorno incorreto
  public List<Categoria> ListarCategorias()
  {
    return categorias;
  }
}
