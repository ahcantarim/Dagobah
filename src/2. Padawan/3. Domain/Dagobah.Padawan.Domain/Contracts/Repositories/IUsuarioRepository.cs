using Dagobah.Domain.Contracts.Repositories;

namespace Dagobah.Padawan.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository :
        IBaseRepository<Entities.UsuarioEntity, int>
    {
    }
}
