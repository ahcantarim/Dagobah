using Dagobah.Domain.Contracts.Repositories.Core;
using Dagobah.Domain.Contracts.Services.Core;
using System.Collections.Generic;

namespace Dagobah.Domain.Services
{
    public class BaseService<TEntity, TId> :
        IBaseService<TEntity, TId>
        where TEntity : Entities.Core.Entity<TId>
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
            _repository.AddRange(entities);
        }

        public void DeleteFisicallyById(TId id)
        {
            _repository.DeleteById(id);
        }

        public void DeleteLogicallyById(TId id)
        {
            _repository.SetAsInactiveById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public TEntity GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        #endregion
    }
}
