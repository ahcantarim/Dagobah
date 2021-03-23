using Dagobah.Application.Services.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;
using System;

namespace Dagobah.Padawan.Application.Services
{
    public class NotaCorretagemDetalheApplicationService :
        BaseApplicationService<NotaCorretagemDetalheEntity, Guid>,
        INotaCorretagemDetalheApplicationService
    {
        #region Constructors

        public NotaCorretagemDetalheApplicationService(INotaCorretagemDetalheDomainService domainService) :
            base(domainService)
        {
        }

        #endregion
    }
}
