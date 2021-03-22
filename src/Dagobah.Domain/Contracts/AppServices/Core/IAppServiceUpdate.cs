using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.AppServices.Core
{
    public interface IAppServiceUpdate<in TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
