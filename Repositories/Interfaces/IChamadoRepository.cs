using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow;
// WARN: Colocar namespace em todos os arquivos?

public interface IChamadoRepository : IRepository
{
  public Task<Chamado> RegistrarChamado(Chamado chamado);
  public Task<Chamado> ObterPorId(int id);
  // WARN: IActionResult pode, talvez n sei, gerar
  // acoplamento com ASP.NET?
  // public Task<List<Chamado>> ListarChamados();
}
