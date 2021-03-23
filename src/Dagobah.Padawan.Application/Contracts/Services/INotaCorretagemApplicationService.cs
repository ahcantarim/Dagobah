using Dagobah.Domain.Contracts.ApplicationServices;
using System;

namespace Dagobah.Padawan.Application.Contracts.Services
{
    public interface INotaCorretagemApplicationService :
        IBaseApplicationService<Domain.Entities.NotaCorretagemEntity, Guid>
    {
    }
}
