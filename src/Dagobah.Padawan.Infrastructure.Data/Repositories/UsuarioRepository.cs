using Dagobah.Infrastructure.Data.Repositories.Core;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Entities;
using System.Data.Entity;

namespace Dagobah.Padawan.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : 
        BaseRepository<UsuarioEntity, int>, 
        IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : 
            base(context)
        {
        }
    }
}
