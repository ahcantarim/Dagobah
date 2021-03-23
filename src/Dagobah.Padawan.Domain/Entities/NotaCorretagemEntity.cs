using Dagobah.Domain.Entities.Core;
using Dagobah.Padawan.Domain.Collections;
using Dagobah.Padawan.Domain.Enumerations;
using System;
using System.Linq;

namespace Dagobah.Padawan.Domain.Entities
{
    public class NotaCorretagemEntity :
        BaseEntity<Guid>
    {
        #region States

        public DateTime Data { get; private set; }

        public decimal? TaxaCorretagem { get; private set; }

        public decimal? TaxaLiquidacao { get; private set; }

        public decimal? TaxaEmolumentos { get; private set; }

        public decimal? TaxaOutros { get; private set; }

        public decimal TaxaTotal => TaxaCorretagem.Value + TaxaLiquidacao.Value + TaxaEmolumentos.Value + TaxaOutros.Value;

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

            return operacaoTitulo.PrecoTotal / operacaoNotaPrecoTotal;
        }

        public decimal CalcularTaxaCorretagemProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            return percentualProporcionalTitulo * TaxaCorretagem.Value;
        }

        public decimal CalcularTaxaLiquidacaoProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            return percentualProporcionalTitulo * TaxaLiquidacao.Value;
        }

        public decimal CalcularTaxaEmolumentosProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            return percentualProporcionalTitulo * TaxaEmolumentos.Value;
        }

        public decimal CalcularTaxaOutrosProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            return percentualProporcionalTitulo * TaxaOutros.Value;
        }

        public decimal CalcularTaxaTotalProporcional(TipoOperacaoCorretagem tipoOperacao, string titulo)
        {
            var percentualProporcionalTitulo = CalcularPercentualProporcional(tipoOperacao, titulo);

            return percentualProporcionalTitulo * TaxaTotal;
        }

        #endregion

        #region Constructors

        public NotaCorretagemEntity(DateTime data, decimal taxaCorretagem, decimal taxaLiquidacao, decimal taxaEmolumentos, decimal taxaOutros)
        {
            Data = data;
            TaxaCorretagem = taxaCorretagem;
            TaxaLiquidacao = taxaLiquidacao;
            TaxaEmolumentos = taxaEmolumentos;
            TaxaOutros = taxaOutros;

            NotaCorretagemDetalheCollection = new NotaCorretagemDetalheCollection();
        }

        public NotaCorretagemEntity(DateTime data, decimal taxaLiquidacao, decimal taxaEmolumentos) :
            this(data, default, taxaLiquidacao, taxaEmolumentos, default)
        {
        }

        #endregion
    }
}
