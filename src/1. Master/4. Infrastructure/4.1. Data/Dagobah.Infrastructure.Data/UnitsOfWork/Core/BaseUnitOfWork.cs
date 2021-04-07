using CommonServiceLocator;
using Dagobah.Domain.Contracts.UnitsOfWork;
using System.Data.Entity;

namespace Dagobah.Infrastructure.Data.UnitsOfWork.Core
{
    public class BaseUnitOfWork<TDbContext> : 
        IBaseUnitOfWork

        where TDbContext : DbContext
    {
        #region Attributes

        private TDbContext _context;

        #endregion

        #region Constructors

        public BaseUnitOfWork(TDbContext context)
        {
            _context = context;
        }

        #endregion

        #region IBaseUnitOfWork

        public void Begin()
        {
            _context = ServiceLocator.Current.GetInstance<TDbContext>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
