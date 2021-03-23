using Dagobah.Infrastructure.Data.Contexts.Core;
using Dagobah.Padawan.Domain.Entities;
using System.Data.Entity;

namespace Dagobah.Padawan.Infrastructure.Data.Contexts
{
    public class PadawanContext : 
        BaseContext
    {
        #region Properties

        // REM: Declarar um DbSet para cada Entity do seu Domain.
        //      Cada DbSet<T> representa uma tabela do banco de dados.

        public DbSet<NotaCorretagemDetalheEntity> NotaCorretagemDetalheEntities { get; set; }

        public DbSet<NotaCorretagemEntity> NotaCorretagemEntities { get; set; }

        public DbSet<UsuarioEntity> UsuarioEntities { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Mappings

            // REM: Adicionar a configuração de mapeamento para cada Entity do seu Domain.
            //      Cada mapeamento deve herdar de EntityTypeConfiguration<T> e ser criado no diretório Mappings.

            modelBuilder.Configurations.Add(new Mappings.NotaCorretagemDetalheMap());

            modelBuilder.Configurations.Add(new Mappings.NotaCorretagemMap());

            modelBuilder.Configurations.Add(new Mappings.UsuarioMap());

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
