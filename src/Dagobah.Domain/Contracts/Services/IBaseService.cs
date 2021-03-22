using Dagobah.Domain.Contracts.Services.Core;

namespace Dagobah.Domain.Contracts.Services
{
    public interface IBaseService<TEntity, TId> :

        IServiceCreate<TEntity, TId>,
        IServiceRead<TEntity, TId>,
        IServiceUpdate<TEntity, TId>,
        IServiceDelete<TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
    }
}
