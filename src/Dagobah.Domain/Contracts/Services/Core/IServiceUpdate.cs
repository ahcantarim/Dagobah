namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceUpdate<in TEntity, TId>
        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
        void Update(TEntity entity);
    }
}
