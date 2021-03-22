using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceRead<TEntity, in TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        TEntity GetById(TId id);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        IEnumerable<TEntity> GetAll(int take, int skip, Expression<Func<TEntity, bool>> predicate = null);

        int Count(Expression<Func<TEntity, bool>> predicate = null);
    }
}
