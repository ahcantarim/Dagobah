using Dagobah.Application.Services.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Application.Services
{
    public class NotaCorretagemOperacaoApplicationService :
        BaseApplicationService<NotaCorretagemOperacaoEntity, int>,
        INotaCorretagemOperacaoApplicationService
    {
        #region Constructors

        public NotaCorretagemOperacaoApplicationService(INotaCorretagemOperacaoDomainService domainService) :
            base(domainService)
        {
        }

        #endregion
    }
}
