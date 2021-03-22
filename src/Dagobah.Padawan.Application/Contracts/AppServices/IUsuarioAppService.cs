using Dagobah.Domain.Contracts.AppServices;

namespace Dagobah.Padawan.Application.Contracts.AppServices
{
    public interface IUsuarioAppService :
        IBaseAppService<Domain.Entities.UsuarioEntity, int>
    {
    }
}
