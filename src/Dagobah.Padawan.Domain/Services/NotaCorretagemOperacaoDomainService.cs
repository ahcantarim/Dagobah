using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class NotaCorretagemOperacaoDomainService :
        BaseDomainService<NotaCorretagemOperacaoEntity, int>,
        INotaCorretagemOperacaoDomainService
    {
        #region Constructors

        public NotaCorretagemOperacaoDomainService(INotaCorretagemOperacaoRepository repository) :
            base(repository)
        {
        }

        #endregion
    }
}
