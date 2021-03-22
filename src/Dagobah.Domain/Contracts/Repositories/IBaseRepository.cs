using Dagobah.Domain.Contracts.Repositories.Core;

namespace Dagobah.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TId> : 
        
        IRepositoryCreate<TEntity, TId>,
        IRepositoryRead<TEntity, TId>,
        IRepositoryUpdate<TEntity, TId>,
        IRepositoryDelete<TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
    }
}
