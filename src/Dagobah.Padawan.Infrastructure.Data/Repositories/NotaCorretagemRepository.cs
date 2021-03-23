using Dagobah.Infrastructure.Data.Repositories.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Entities;
using System;
using System.Data.Entity;

namespace Dagobah.Padawan.Infrastructure.Data.Repositories
{
    public class NotaCorretagemRepository :
        BaseRepository<NotaCorretagemEntity, Guid>,
        INotaCorretagemRepository
    {
        public NotaCorretagemRepository(DbContext context) :
            base(context)
        {
        }
    }
}
