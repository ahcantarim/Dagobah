using Dagobah.Infrastructure.Data.Repositories.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Entities;
using System.Data.Entity;

namespace Dagobah.Padawan.Infrastructure.Data.Repositories
{
    public class NotaCorretagemOperacaoRepository :
         BaseRepository<NotaCorretagemOperacaoEntity, int>,
         INotaCorretagemOperacaoRepository
    {
        public NotaCorretagemOperacaoRepository(DbContext context) :
            base(context)
        {
        }
    }
}
