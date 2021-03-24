using Dagobah.Domain.Contracts.ApplicationServices;

namespace Dagobah.Padawan.Application.Contracts.Services
{
    public interface INotaCorretagemApplicationService :
        IBaseApplicationService<Domain.Entities.NotaCorretagemEntity, int>
    {
    }
}
