using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;
using System;

namespace Dagobah.Padawan.Domain.Services
{
    public class NotaCorretagemDetalheDomainService :
        BaseDomainService<NotaCorretagemDetalheEntity, Guid>,
        INotaCorretagemDetalheDomainService
    {
        #region Constructors

        public NotaCorretagemDetalheDomainService(INotaCorretagemDetalheRepository repository) :
            base(repository)
        {
        }

        #endregion
    }
}
