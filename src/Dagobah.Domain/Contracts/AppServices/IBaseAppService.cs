using Dagobah.Domain.Contracts.AppServices.Core;

namespace Dagobah.Domain.Contracts.AppServices
{
    public interface IBaseAppService<TEntity, TId> :

       IAppServiceCreate<TEntity, TId>,
       IAppServiceRead<TEntity, TId>,
       IAppServiceUpdate<TEntity, TId>,
       IAppServiceDelete<TId>

       where TEntity : Entities.Core.BaseEntity<TId>
       where TId : struct
    {
    }
}
