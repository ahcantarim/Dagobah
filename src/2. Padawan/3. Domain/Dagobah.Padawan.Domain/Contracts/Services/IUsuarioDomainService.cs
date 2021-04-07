using Dagobah.Domain.Contracts.DomainServices;

namespace Dagobah.Padawan.Domain.Contracts.Services
{
    public interface IUsuarioDomainService :
        IBaseDomainService<Entities.UsuarioEntity, int>
    {
    }
}
