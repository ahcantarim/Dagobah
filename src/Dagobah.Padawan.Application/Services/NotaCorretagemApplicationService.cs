using Dagobah.Application.Services.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;
using System;

namespace Dagobah.Padawan.Application.Services
{
    public class NotaCorretagemApplicationService :
        BaseApplicationService<NotaCorretagemEntity, Guid>,
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
