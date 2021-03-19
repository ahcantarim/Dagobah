using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceRead<out TEntity, in TId>
        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
        TEntity GetById(TId id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(int take, int skip);
    }
}
