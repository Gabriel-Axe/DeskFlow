namespace DeskFlow.Repositories.Interfaces;

using DeskFlow.Models.DTOs;
using DeskFlow.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// WARN: Colocar namespace em todos os arquivos?

public interface IChamadoRepository : IRepository
{
  // public Task<Chamado> RegistrarChamado(Chamado chamado);
  public Task RegistrarChamado(Chamado chamado);
  public Task<List<Chamado?>> Listar();
  public Task<List<Chamado>> ListarComFiltros(ChamadoFiltroDto dto);
  public Task<Chamado?> ObterPorIdAsync(int id);
  public Task<Chamado?> AtualizarPorId(int id, Chamado chamado);
  // WARN: IActionResult pode, talvez n sei, gerar
  // acoplamento com ASP.NET?
  // public Task<List<Chamado>> ListarChamados();
}
