using System.Data.Entity.ModelConfiguration;

namespace Dagobah.Padawan.Infrastructure.Data.Mappings
{
    public class NotaCorretagemOperacaoMap :
        EntityTypeConfiguration<Domain.Entities.NotaCorretagemOperacaoEntity>
    {
        public NotaCorretagemOperacaoMap()
        {
            #region Table

            ToTable("notaCorretagemOperacao");

            #endregion

            #region Keys

            HasKey(c => c.Id);

            #endregion

            #region Properties

            Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.TipoOperacao)
                .HasColumnName("tipoOperacao")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.Titulo)
                .HasColumnName("titulo")
                .IsRequired();

            Property(c => c.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            Property(c => c.PrecoLiquidacao)
                .HasColumnName("precoLiquidacao")
                .HasColumnType("decimal")
                .IsRequired();

            #endregion

            #region References

            HasRequired(c => c.NotaCorretagem)
                .WithMany(c => c.NotaCorretagemOperacaoCollection)
                .HasForeignKey(c => c.NotaCorretagemId);

            #endregion
        }
    }
}
