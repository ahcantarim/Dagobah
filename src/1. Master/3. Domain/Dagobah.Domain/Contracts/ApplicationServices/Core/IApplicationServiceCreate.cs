using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.ApplicationServices.Core
{
    public interface IApplicationServiceCreate<in TEntity, TId>

       where TEntity : Entities.Core.BaseEntity<TId>
       where TId : struct
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
    }
}
