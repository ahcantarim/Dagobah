using Dagobah.Domain.Contracts.Repositories;
using System;

namespace Dagobah.Padawan.Domain.Contracts.Repositories
{
    public interface INotaCorretagemRepository :
        IBaseRepository<Entities.NotaCorretagemEntity, Guid>
    {
    }
}
