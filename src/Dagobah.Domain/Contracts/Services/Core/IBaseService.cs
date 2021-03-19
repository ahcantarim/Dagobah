namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IBaseService<TEntity, TId> :

        IServiceCreate<TEntity, TId>,
        IServiceRead<TEntity, TId>,
        IServiceUpdate<TEntity, TId>,
        IServiceDelete<TId>

        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
    }
}
