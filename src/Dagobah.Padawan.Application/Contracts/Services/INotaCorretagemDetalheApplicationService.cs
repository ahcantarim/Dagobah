using Dagobah.Domain.Contracts.ApplicationServices;
using System;

namespace Dagobah.Padawan.Application.Contracts.Services
{
    public interface INotaCorretagemDetalheApplicationService :
        IBaseApplicationService<Domain.Entities.NotaCorretagemDetalheEntity, Guid>
    {
    }
}
