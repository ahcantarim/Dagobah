using Dagobah.Domain.Contracts.Repositories;
using Dagobah.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dagobah.Domain.Services.Core
{
    public class BaseService<TEntity, TId> :
        IBaseService<TEntity, TId>

        where TEntity : Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        #region Attributes

        private readonly IBaseRepository<TEntity, TId> _repository;

        #endregion

        #region Constructors

        public BaseService(IBaseRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        #endregion

        #region IBaseService

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                _repository.Add(entity);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _repository.Count(predicate);
        }

        public void DeleteById(TId id)
        {
            _repository.DeleteById(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(int take, int skip, Expression<Func<TEntity, bool>> predicate = null)
        {
            return _repository.GetAll(take, skip);
        }

        public TEntity GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public void SetAsActiveById(TId id)
        {
            _repository.SetAsActiveById(id);
        }

        public void SetAsInactiveById(TId id)
        {
            _repository.SetAsActiveById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                _repository.Update(entity);
        }

        #endregion
    }
}
