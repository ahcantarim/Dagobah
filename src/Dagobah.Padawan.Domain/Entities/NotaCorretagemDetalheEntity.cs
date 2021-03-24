using Dagobah.Domain.Entities.Core;
using Dagobah.Padawan.Domain.Enumerations;
using Dagobah.Padawan.Domain.ValueObjects;
using System;
using System.Linq;

namespace Dagobah.Padawan.Domain.Entities
{
    public class NotaCorretagemDetalheEntity :
        BaseEntity<int>
    {
        #region States

        public int NotaCorretagemId { get; private set; }

        public NotaCorretagemEntity NotaCorretagem { get; private set; }

        public TipoOperacaoCorretagem TipoOperacao { get; private set; }

        public string Titulo { get; private set; }

        public int Quantidade { get; private set; }

        public double PrecoLiquidacao { get; private set; }

        public double PrecoTotal => Math.Round(Quantidade * PrecoLiquidacao, 2);

        public double CustoAquisicao
        {
            get
            {
                var custoAquisicao = PrecoTotal;

                switch (TipoOperacao)
                {
                    case TipoOperacaoCorretagem.Compra:
                        custoAquisicao += TaxaOperacaoProporcional.Total;
                        break;

                    case TipoOperacaoCorretagem.Venda:
                        custoAquisicao -= TaxaOperacaoProporcional.Total;
                        break;
                }

                return Math.Round(custoAquisicao, 2);
            }
        }

        public double PercentualProporcional
        {
            get
            {
                var precoTotalNotaCorretagem = NotaCorretagem.NotaCorretagemDetalheCollection?.Sum(x => x.PrecoTotal);

                if (precoTotalNotaCorretagem <= 0)
                    return 0;

                var resultado = PrecoTotal / precoTotalNotaCorretagem.Value;

                return Math.Round(resultado * 100, 1);
            }
        }

        public TaxaOperacaoValueObject TaxaOperacaoProporcional
        {
            get
            {
                var percentualConsiderar = PercentualProporcional / 100;

                var taxaCorretagem = Math.Round(NotaCorretagem.TaxaOperacao.Corretagem.Value * percentualConsiderar, 3);
                var taxaLiquidacao = Math.Round(NotaCorretagem.TaxaOperacao.Liquidacao.Value * percentualConsiderar, 3);
                var taxaEmolumentos = Math.Round(NotaCorretagem.TaxaOperacao.Emolumentos.Value * percentualConsiderar, 3);
                var taxaOutros = Math.Round(NotaCorretagem.TaxaOperacao.Outros.Value * percentualConsiderar, 3);

                return new TaxaOperacaoValueObject(taxaCorretagem, taxaLiquidacao, taxaEmolumentos, taxaOutros);
            }
        }

        #endregion

        #region Behaviors

        public void AtualizarQuantidade(TipoOperacaoCorretagem tipoOperacao, int quantidade)
        {
            switch (tipoOperacao)
            {
                case TipoOperacaoCorretagem.Compra:
                    Quantidade += quantidade;
                    break;

                case TipoOperacaoCorretagem.Venda:
                    Quantidade -= quantidade;
                    break;
            }
        }

        #endregion

        #region Constructors

        public NotaCorretagemDetalheEntity(NotaCorretagemEntity notaCorretagem, TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, double precoLiquidacao)
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
