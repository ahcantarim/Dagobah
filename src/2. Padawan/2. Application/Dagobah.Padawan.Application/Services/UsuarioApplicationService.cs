using Dagobah.Application.Services.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Application.Services
{
    public class UsuarioApplicationService :
       BaseApplicationService<UsuarioEntity, int>,
       IUsuarioApplicationService
    {
        #region Constructors

        public UsuarioApplicationService(IUsuarioDomainService domainService) :
            base(domainService)
        {
        }

        #endregion
    }
}
