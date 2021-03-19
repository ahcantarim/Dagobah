using System.Collections.Generic;

namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IRepositoryRead<out TEntity, in TId>
        where TEntity : Entities.Core.Entity<TId>
        where TId : struct
    {
        TEntity GetById(TId id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(int take, int skip);

        int Count();

        //TODO: Permitir "predicate" nos métodos GetAll() e Count() => Expression<Func<TEntity, bool>> predicate = null
    }
}
