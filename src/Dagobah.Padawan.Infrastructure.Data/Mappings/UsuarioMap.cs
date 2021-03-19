using System.Data.Entity.ModelConfiguration;

namespace Dagobah.Padawan.Infrastructure.Data.Mappings
{
    public sealed class UsuarioMap : EntityTypeConfiguration<Domain.Entities.UsuarioEntity>
    {
        public UsuarioMap()
        {
            #region Table

            ToTable("usuario");

            #endregion

            #region Keys

            HasKey(c => c.Id);

            #endregion

            #region Properties

            Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired();

            Property(c => c.Senha)
                .HasColumnName("senha")
                .HasMaxLength(50)
                .IsRequired();
            
            Property(c => c.Confirmado)
                .HasColumnName("confirmado")
                .HasColumnType("bit")
                .IsRequired();

            Property(c => c.UltimoAcessoEm)
               .HasColumnName("dataUltimoAcesso")
               .HasColumnType("datetime");

            Property(c => c.CreatedAt)
              .HasColumnName("createdAt")
              .HasColumnType("datetime")
              .IsRequired();

            Property(c => c.UpdatedAt)
              .HasColumnName("updatedAt")
              .HasColumnType("datetime");

            Property(c => c.DeletedAt)
              .HasColumnName("deletedAt")
              .HasColumnType("datetime");

            #endregion

            #region References

            #endregion
        }
    }
}
