using Dagobah.Domain.Contracts.DomainServices.Core;

namespace Dagobah.Domain.Contracts.DomainServices
{
    public interface IBaseDomainService<TEntity, TId> :

        IDomainServiceCreate<TEntity, TId>,
        IDomainServiceRead<TEntity, TId>,
        IDomainServiceUpdate<TEntity, TId>,
        IDomainServiceDelete<TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
    }
}
