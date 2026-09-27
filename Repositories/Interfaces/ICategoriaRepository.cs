public interface ICategoriaRepository : IRepository
{
  public Task RegistrarCategoria(Categoria categoria);
  public Task<List<Categoria>> ListarCategorias();
  public Task DeletarCategoria(int id);
  public Task<Categoria> ObterCategoriaPorIdAsync(int id);
}
