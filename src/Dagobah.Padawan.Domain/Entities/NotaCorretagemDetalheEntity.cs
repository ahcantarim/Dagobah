using Dagobah.Domain.Entities.Core;
using Dagobah.Padawan.Domain.Enumerations;
using System;

namespace Dagobah.Padawan.Domain.Entities
{
    public class NotaCorretagemDetalheEntity :
        BaseEntity<Guid>
    {
        #region States

        public Guid NotaCorretagemId { get; private set; }

        public NotaCorretagemEntity NotaCorretagem { get; private set; }

        public TipoOperacaoCorretagem TipoOperacao { get; private set; }

        public string Titulo { get; private set; }

        public int Quantidade { get; private set; }

        public decimal PrecoLiquidacao { get; private set; }

        public decimal PrecoTotal => Quantidade * PrecoLiquidacao;

        #endregion

        #region Behaviors

        #endregion

        #region Constructors

        public NotaCorretagemDetalheEntity(NotaCorretagemEntity notaCorretagem ,TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, decimal precoLiquidacao)
        {
            NotaCorretagem = notaCorretagem;
            NotaCorretagemId = notaCorretagem.Id;

            TipoOperacao = tipoOperacao;
            Titulo = titulo;
            Quantidade = quantidade;
            PrecoLiquidacao = precoLiquidacao;
        }

        #endregion
    }
}
