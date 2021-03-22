using Dagobah.Domain.Contracts.Repositories;
using Dagobah.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Dagobah.Infrastructure.Data.Repositories.Core
{
    public class BaseRepository<TEntity, TId> :
        IBaseRepository<TEntity, TId>

        where TEntity : Domain.Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        #region Attributes

        private readonly DbContext _context;
        private DbSet<TEntity> _dbSet;

        #endregion

        #region Constructors

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region IBaseRepository

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet.Count();
            else
                return _dbSet.Where(predicate).Count();

        }

        public void DeleteById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet.AsEnumerable();
            else
                return _dbSet.Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(int take, int skip, Expression<Func<TEntity, bool>> predicate = null)
        {
            var result = _dbSet.Take(take).Skip(skip);

            if (predicate == null)
                return result.AsEnumerable();
            else
                return result.Where(predicate).AsEnumerable();
        }

        public TEntity GetById(TId id)
        {
            return _dbSet.Find(id);
        }

        public void SetAsActiveById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                entity.SetAsActive();
                _context.Update(entity);
            }
        }

        public void SetAsInactiveById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                entity.SetAsInactive();
                _context.Update(entity);
            }
        }

        public void Update(TEntity entity)
        {
            entity.SetAsUpdated();

            _context.Update(entity);
        }

        #endregion
    }
}
