using System;
using System.Linq.Expressions;

namespace Dagobah.Domain.Queries.Core
{
    public static class BaseEntityQueries<TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        public static Expression<Func<TEntity, bool>> ObterEntidade(TId id)
        {
            return x => x.Id.Equals(id);
        }
    }
}
