namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IRepositoryUpdate<in TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        void Update(TEntity entity);
    }
}
