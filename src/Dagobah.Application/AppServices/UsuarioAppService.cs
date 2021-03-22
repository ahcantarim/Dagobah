using Dagobah.Application.AppServices.Core;
using Dagobah.Padawan.Application.Contracts.AppServices;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Application.AppServices
{
    public class UsuarioAppService :
        BaseAppService<UsuarioEntity, int>,
        IUsuarioAppService
    {
        #region Constructors

        public UsuarioAppService(IUsuarioService domainService) :
            base(domainService)
        {
        }

        #endregion
    }
}
