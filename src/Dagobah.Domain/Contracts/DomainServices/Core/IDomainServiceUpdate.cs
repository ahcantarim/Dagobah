using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.DomainServices.Core
{
    public interface IDomainServiceUpdate<in TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
