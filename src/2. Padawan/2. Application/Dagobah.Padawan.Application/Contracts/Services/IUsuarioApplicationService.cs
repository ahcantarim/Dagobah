using Dagobah.Domain.Contracts.ApplicationServices;

namespace Dagobah.Padawan.Application.Contracts.Services
{
    public interface IUsuarioApplicationService :
        IBaseApplicationService<Domain.Entities.UsuarioEntity, int>
    {
    }
}
