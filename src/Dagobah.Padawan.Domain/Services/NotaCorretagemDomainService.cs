using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class NotaCorretagemDomainService :
        BaseDomainService<NotaCorretagemEntity, int>,
        INotaCorretagemDomainService
    {
        #region Constructors

        public NotaCorretagemDomainService(INotaCorretagemRepository repository) :
            base(repository)
        {
        }

        #endregion
    }
}
