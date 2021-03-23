using Dagobah.Domain.Contracts.DomainServices;
using System;

namespace Dagobah.Padawan.Domain.Contracts.Services
{
    public interface INotaCorretagemDomainService :
        IBaseDomainService<Entities.NotaCorretagemEntity, Guid>
    {
    }
}
