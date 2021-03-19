using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IRepositoryCreate<in TEntity, TId>
        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
    }
}
