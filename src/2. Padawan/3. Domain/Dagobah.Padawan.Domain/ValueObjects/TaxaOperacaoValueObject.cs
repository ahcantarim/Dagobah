using Dagobah.Domain.ValueObjects.Core;
using System;
using System.Collections.Generic;

namespace Dagobah.Padawan.Domain.ValueObjects
{
    public class TaxaOperacaoValueObject : BaseValueObject
    {
        #region States

        public double? Corretagem { get; private set; }

        public double? Liquidacao { get; private set; }

        public double? Emolumentos { get; private set; }

        public double? Outros { get; private set; }

        public double Total => Math.Round(Corretagem.Value + Liquidacao.Value + Emolumentos.Value + Outros.Value, 2);

        #endregion

        #region Constructors

        public TaxaOperacaoValueObject(double corretagem, double liquidacao, double emolumentos, double outros)
        {
            Corretagem = corretagem;
            Liquidacao = liquidacao;
            Emolumentos = emolumentos;
            Outros = outros;
        }

        public TaxaOperacaoValueObject(double liquidacao, double emolumentos) :
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
