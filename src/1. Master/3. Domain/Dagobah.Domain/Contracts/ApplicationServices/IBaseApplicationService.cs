using Dagobah.Domain.Contracts.ApplicationServices.Core;

namespace Dagobah.Domain.Contracts.ApplicationServices
{
    public interface IBaseApplicationService<TEntity, TId> :

       IApplicationServiceCreate<TEntity, TId>,
       IApplicationServiceRead<TEntity, TId>,
       IApplicationServiceUpdate<TEntity, TId>,
       IApplicationServiceDelete<TId>

       where TEntity : Entities.Core.BaseEntity<TId>
       where TId : struct
    {
    }
}
