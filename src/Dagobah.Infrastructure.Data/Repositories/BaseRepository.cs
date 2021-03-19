using Dagobah.Domain.Contracts.Repositories.Core;
using Dagobah.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dagobah.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TId> :
        IBaseRepository<TEntity, TId>
        where TEntity : Domain.Entities.Core.Entity<TId>
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

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Add(entity);
            }
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public void DeleteById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            //if (predicate != null)
            //{
            //    return _dbSet.Where(predicate);
            //}

            return _dbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(int take, int skip)
        {
            //TODO: GetAll(take, skip)
            throw new NotImplementedException();
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
                entity.SetActive(true);
                _context.Update(entity);
            }
        }

        public void SetAsInactiveById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                entity.SetActive(false);
                _context.Update(entity);
            }
        }

        public void Update(TEntity entity)
        {
            entity.SetUpdated();

            _context.Update(entity);
        }

        #endregion
    }
}
