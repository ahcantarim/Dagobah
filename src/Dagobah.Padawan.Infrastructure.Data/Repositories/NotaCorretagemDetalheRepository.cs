using Dagobah.Infrastructure.Data.Repositories.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Entities;
using System.Data.Entity;

namespace Dagobah.Padawan.Infrastructure.Data.Repositories
{
    public class NotaCorretagemDetalheRepository :
         BaseRepository<NotaCorretagemDetalheEntity, int>,
         INotaCorretagemDetalheRepository
    {
        public NotaCorretagemDetalheRepository(DbContext context) :
            base(context)
        {
        }
    }
}
