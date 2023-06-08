namespace Domain.Interfaces.IRepository
{
    public interface IRepositoryGenerico<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> PegarTodos();
        Task<TEntity> PegarPeloId(int id);
        Task<TEntity> PegarPeloId(string id);
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Excluir(TEntity entity);
        Task Excluir(int id);
        Task Excluir(string id);
    }
}
