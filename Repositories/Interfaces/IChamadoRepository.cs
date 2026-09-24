using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow;
// WARN: Colocar namespace em todos os arquivos?

public interface IChamadoRepository
{
  public async Task RegistrarChamado(Chamado chamado);
  public async Task<Chamado> ObterPorId(int id);
  // WARN: IActionResult pode, talvez n sei, gerar
  // acoplamento com ASP.NET?
  public Task<IActionResult> IniciarAtendimento(int id);
  public Task<IActionResult> EncerrarChamado(int id);
  // public Task<List<Chamado>> ListarChamados();
}
