using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;
using System;

namespace Dagobah.Padawan.Domain.Services
{
    public class NotaCorretagemDomainService :
        BaseDomainService<NotaCorretagemEntity, Guid>,
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
