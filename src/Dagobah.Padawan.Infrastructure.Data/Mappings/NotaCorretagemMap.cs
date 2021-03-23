using System.Data.Entity.ModelConfiguration;

namespace Dagobah.Padawan.Infrastructure.Data.Mappings
{
    public class NotaCorretagemMap :
        EntityTypeConfiguration<Domain.Entities.NotaCorretagemEntity>
    {
        public NotaCorretagemMap()
        {
            #region Table

            ToTable("notaCorretagem");

            #endregion

            #region Keys

            HasKey(c => c.Id);

            #endregion

            #region Properties

            Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            Property(c => c.Data)
                .HasColumnName("data")
                .HasColumnName("datetime")
                .IsRequired();

            Property(c => c.TaxaLiquidacao)
                .HasColumnName("taxaLiquidacao")
                .HasColumnType("decimal")
                .IsRequired();

            Property(c => c.TaxaEmolumentos)
                .HasColumnName("taxaEmolumentos")
                .HasColumnType("decimal")
                .IsRequired();

            #endregion

            #region References

            #endregion
        }
    }
}
