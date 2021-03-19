using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceCreate<in TEntity, TId>
        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
    }
}
