using Dagobah.Infrastructure.Data.UnitsOfWork.Core;
using Dagobah.Padawan.Infrastructure.Data.Contexts;

namespace Dagobah.Padawan.Infrastructure.Data.UnitsOfWork
{
    public sealed class PadawanUnitOfWork : 
        BaseUnitOfWork<PadawanContext>
    {
        #region Constructors

        public PadawanUnitOfWork(PadawanContext context) : 
            base(context)
        {
        }

        #endregion
    }
}
