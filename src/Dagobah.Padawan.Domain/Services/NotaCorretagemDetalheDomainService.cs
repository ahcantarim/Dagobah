using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class NotaCorretagemDetalheDomainService :
        BaseDomainService<NotaCorretagemDetalheEntity, int>,
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
