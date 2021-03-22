using Dagobah.Domain.Contracts.AppServices;
using Dagobah.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dagobah.Application.AppServices.Core
{
    public class BaseAppService<TEntity, TId> :
        IBaseAppService<TEntity, TId>

        where TEntity : Domain.Entities.Core.BaseEntity<TId>
        where TId : struct
    {
        #region Attributes

        private readonly IBaseService<TEntity, TId> _domainService;

        #endregion

        #region Constructors

        public BaseAppService(IBaseService<TEntity, TId> domainService)
        {
            _domainService = domainService;
        }

        #endregion

        #region IBaseAppService

        public void Add(TEntity entity)
        {
            _domainService.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _domainService.AddRange(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _domainService.Count(predicate);
        }

        public void DeleteById(TId id)
        {
            _domainService.DeleteById(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _domainService.GetAll(predicate);
        }

        public IEnumerable<TEntity> GetAll(int take, int skip, Expression<Func<TEntity, bool>> predicate = null)
        {
            return _domainService.GetAll(take, skip, predicate);
        }

        public TEntity GetById(TId id)
        {
            return _domainService.GetById(id);
        }

        public void SetAsActiveById(TId id)
        {
            _domainService.SetAsActiveById(id);
        }

        public void SetAsInactiveById(TId id)
        {
            _domainService.SetAsInactiveById(id);
        }

        public void Update(TEntity entity)
        {
            _domainService.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _domainService.UpdateRange(entities);
        }

        #endregion
    }
}
