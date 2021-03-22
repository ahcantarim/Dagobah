namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IRepositoryCreate<in TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        void Add(TEntity entity);
    }
}
