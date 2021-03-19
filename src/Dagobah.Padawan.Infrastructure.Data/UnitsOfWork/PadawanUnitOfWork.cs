using CommonServiceLocator;
using Dagobah.Domain.Contracts.UnitsOfWork;
using Dagobah.Padawan.Infrastructure.Data.Contexts;

namespace Dagobah.Padawan.Infrastructure.Data.UnitsOfWork
{
    public sealed class PadawanUnitOfWork
        : IBaseUnitOfWork
    {
        #region Attributes

        private PadawanContext _context;

        #endregion

        #region Constructors

        public PadawanUnitOfWork(PadawanContext context)
        {
            _context = context;
        }

        #endregion

        #region IBaseUnitOfWork

        public void Begin()
        {
            _context = ServiceLocator.Current.GetInstance<PadawanContext>();
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
