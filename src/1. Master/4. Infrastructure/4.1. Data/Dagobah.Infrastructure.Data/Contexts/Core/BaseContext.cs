using System;
using System.Data.Entity;
using System.Linq;
using Conventions = System.Data.Entity.ModelConfiguration.Conventions;

namespace Dagobah.Infrastructure.Data.Contexts.Core
{
    public class BaseContext :
        DbContext
    {
        #region Properties

        public bool LazyLoadingEnabled { get; set; }

        public bool ProxyCreationEnabled { get; set; }

        public bool AutoDetectChangesEnabled { get; set; }

        #endregion

        #region Constructors
        public BaseContext() :
            base("DefaultConnectionString")
        {
            ConfigureContext();
        }

        public BaseContext(string nameOrConnectionString) :
            base(nameOrConnectionString)
        {
            ConfigureContext();
        }

        #endregion

        #region Methods

        private void ConfigureContext()
        {
            Configuration.LazyLoadingEnabled = LazyLoadingEnabled;
            Configuration.ProxyCreationEnabled = ProxyCreationEnabled;
            Configuration.AutoDetectChangesEnabled = AutoDetectChangesEnabled;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Conventions

            //TODO: Permitir que classe derivada configure as Conventions.

            modelBuilder.Conventions.Remove<Conventions.PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<Conventions.OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<Conventions.ManyToManyCascadeDeleteConvention>();

            #endregion

            #region Properties

            //TODO: Permitir que classe derivada configure as Properties.

            //// Para configurar todas as propriedades que terminam com "Id" automaticamente como PK.
            //modelBuilder.Properties()
            //            .Where(p => p.Name == $"{p.ReflectedType.Name}Id")
            //            .Configure(p => p.IsKey());

            // Para configurar todas as propriedades do tipo "string" automaticamente como "varchar".
            modelBuilder.Properties<string>()
                        .Configure(p => p.HasColumnType("varchar"));

            // Para configurar todas as propriedades do tipo "string" automaticamente com tamanho máximo de 255 caso não seja informado.
            modelBuilder.Properties<string>()
                        .Configure(p => p.HasMaxLength(255));

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            // Verifica se o registro possui a propriedade "CreatedAt" antes de confirmar a alteração no banco de dados.
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    // Seta automaticamente o valor da propriedade "CreatedAt" no momento da adição de um registro.
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    // Não altera o valor da propriedade "CreatedAt" no momento da edição de um registro.
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        #endregion
    }
}
