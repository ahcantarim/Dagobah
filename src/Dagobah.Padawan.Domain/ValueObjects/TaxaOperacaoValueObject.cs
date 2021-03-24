using Dagobah.Domain.ValueObjects.Core;
using System.Collections.Generic;

namespace Dagobah.Padawan.Domain.ValueObjects
{
    public class TaxaOperacaoValueObject : BaseValueObject
    {
        #region States

        public decimal? Corretagem { get; private set; }

        public decimal? Liquidacao { get; private set; }

        public decimal? Emolumentos { get; private set; }

        public decimal? Outros { get; private set; }

        public decimal Total => Corretagem.Value + Liquidacao.Value + Emolumentos.Value + Outros.Value;

        #endregion

        #region Constructors

        public TaxaOperacaoValueObject(decimal corretagem, decimal liquidacao, decimal emolumentos, decimal outros)
        {
            Corretagem = corretagem;
            Liquidacao = liquidacao;
            Emolumentos = emolumentos;
            Outros = outros;
        }

        public TaxaOperacaoValueObject(decimal liquidacao, decimal emolumentos) :
            this(default, liquidacao, emolumentos, default)
        {
        }

        public TaxaOperacaoValueObject() :
            this(default, default, default, default)
        {
        }

        #endregion

        #region BaseValueObject

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Corretagem;
            yield return Liquidacao;
            yield return Emolumentos;
            yield return Outros;
            yield return Total;
        }

        #endregion
    }
}
