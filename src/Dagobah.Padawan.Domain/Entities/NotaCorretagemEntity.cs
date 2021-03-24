using Dagobah.Domain.Entities.Core;
using Dagobah.Padawan.Domain.Collections;
using Dagobah.Padawan.Domain.Enumerations;
using Dagobah.Padawan.Domain.ValueObjects;
using System;
using System.Linq;

namespace Dagobah.Padawan.Domain.Entities
{
    public class NotaCorretagemEntity :
        BaseEntity<int>
    {
        #region States

        public DateTime Data { get; private set; }

        public TaxaOperacaoValueObject TaxaOperacao { get; private set; }

        public NotaCorretagemDetalheCollection NotaCorretagemDetalheCollection { get; set; }

        #endregion

        #region Behaviors

        public void AdicionarOperacao(TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, decimal precoLiquidacao)
        {
            var notaCorretagemDetalhe = new NotaCorretagemDetalheEntity(this, tipoOperacao, titulo, quantidade, precoLiquidacao);
            NotaCorretagemDetalheCollection.Add(notaCorretagemDetalhe);
        }

        public decimal CalcularPercentualProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var operacaoTitulo = NotaCorretagemDetalheCollection.Where(x => x.TipoOperacao == tipoOperacao && x.Titulo == titulo)
                                                                .FirstOrDefault();

            var operacaoNotaPrecoTotal = NotaCorretagemDetalheCollection.Sum(x => x.PrecoTotal);

            if (operacaoNotaPrecoTotal <= 0)
                return 0;

            return operacaoTitulo.PrecoTotal / operacaoNotaPrecoTotal;  //TODO: Math.Round
        }

        public decimal CalcularTaxaProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo, TipoTaxaOperacao tipoTaxa)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            decimal? valorTaxaConsiderar = 0;

            switch (tipoTaxa)
            {
                case TipoTaxaOperacao.Corretagem:
                    valorTaxaConsiderar = TaxaOperacao.Corretagem.Value;
                    break;

                case TipoTaxaOperacao.Liquidacao:
                    valorTaxaConsiderar = TaxaOperacao.Liquidacao.Value;
                    break;

                case TipoTaxaOperacao.Emolumentos:
                    valorTaxaConsiderar = TaxaOperacao.Emolumentos.Value;
                    break;

                case TipoTaxaOperacao.Outros:
                    valorTaxaConsiderar = TaxaOperacao.Outros.Value;
                    break;

                default:
                    break;
            }

            return percentualProporcionalTitulo * valorTaxaConsiderar.Value; //TODO: Math.Round
        }

        #endregion

        #region Constructors

        public NotaCorretagemEntity(DateTime data, decimal taxaCorretagem, decimal taxaLiquidacao, decimal taxaEmolumentos, decimal taxaOutros)
        {
            Data = data;
            TaxaOperacao = new TaxaOperacaoValueObject(taxaCorretagem, taxaLiquidacao, taxaEmolumentos, taxaOutros);
            NotaCorretagemDetalheCollection = new NotaCorretagemDetalheCollection();
        }

        public NotaCorretagemEntity(DateTime data, decimal taxaLiquidacao, decimal taxaEmolumentos) :
            this(data, default, taxaLiquidacao, taxaEmolumentos, default)
        {
        }

        #endregion
    }
}
