namespace DeskFlow.Repositories.Interfaces;

public interface IRepository
{
  // NOTE: Vale a pena?
  // public Task<T> Listar();
  public Task SalvarMudancasAsync();
}
// WARN: Desnecessario?
