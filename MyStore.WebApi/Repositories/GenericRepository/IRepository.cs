using MyStore.Models;

namespace MyStore.WebApi.Repositories.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetById(Guid id);
        Task<IReadOnlyList<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task DeleteById(Guid id);
    }
}
