namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IBaseRepository<TEntity, TId> :
        
        IRepositoryCreate<TEntity, TId>,
        IRepositoryRead<TEntity, TId>,
        IRepositoryUpdate<TEntity, TId>,
        IRepositoryDelete<TId>

        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
    }
}
