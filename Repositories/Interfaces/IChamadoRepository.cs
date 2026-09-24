using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow;
// WARN: Colocar namespace em todos os arquivos?

public interface IChamadoRepository
{
  public Task RegistrarChamado(Chamado chamado);
  public Task<Chamado> ObterPorId(int id);
  // WARN: IActionResult pode, talvez n sei, gerar
  // acoplamento com ASP.NET?
  public Task<Chamado?> IniciarAtendimento(int id);
  public Task<Chamado?> EncerrarChamado(int id);
  // public Task<List<Chamado>> ListarChamados();
}
