using Dagobah.Application.Services.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Application.Services
{
    public class NotaCorretagemApplicationService :
        BaseApplicationService<NotaCorretagemEntity, int>,
        INotaCorretagemApplicationService
    {
        #region Constructors

        public NotaCorretagemApplicationService(INotaCorretagemDomainService domainService) :
            base(domainService)
        {
        }

        #endregion
    }
}
