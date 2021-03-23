using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class UsuarioDomainService :
        BaseDomainService<UsuarioEntity, int>,
        IUsuarioDomainService
    {
        #region Constructors

        public UsuarioDomainService(IUsuarioRepository repository) : 
            base(repository)
        {
        }

        #endregion
    }
}
