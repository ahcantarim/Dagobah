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

        #endregion

        #region Constructors

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region IBaseRepository

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Add(entity);
            }
        }

        public void DeleteById(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
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

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(int take, int skip)
        {
            //TODO: GetAllPaged(take, skip)
            throw new NotImplementedException();
        }

        public TEntity GetById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.SetUpdated();

            _context.Update(entity);
        }

        #endregion
    }
}
