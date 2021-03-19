using Dagobah.Domain.Services;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Entities;

namespace Dagobah.Padawan.Domain.Services
{
    public class UsuarioService :
        BaseService<UsuarioEntity, int>,
        IUsuarioService
    {
        #region Attributes

        private readonly IUsuarioRepository _repository;

        #endregion

        #region Constructors

        public UsuarioService(IUsuarioRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        #endregion
    }
}
