using Dagobah.Domain.Services.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class UsuarioService :
        BaseService<UsuarioEntity, int>,
        IUsuarioService
    {
        #region Constructors

        public UsuarioService(IUsuarioRepository repository) : 
            base(repository)
        {
        }

        #endregion
    }
}
