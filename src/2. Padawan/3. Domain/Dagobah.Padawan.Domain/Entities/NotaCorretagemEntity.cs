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

        public NotaCorretagemOperacaoCollection NotaCorretagemOperacaoCollection { get; set; }

        public double PrecoTotal => NotaCorretagemOperacaoCollection.Sum(x => x.PrecoTotal);

        public double CustoAquisicaoTotal => NotaCorretagemOperacaoCollection.Sum(x => x.CustoAquisicao);

        #endregion

        #region Behaviors

        public void AdicionarOperacao(TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, double precoLiquidacao)
        {
            //TODO: Adicionar validações (operação existente, título preenchido, quantidade válida, preço válido, etc).

            titulo = titulo.ToUpper();

            var operacao = NotaCorretagemOperacaoCollection.ToList()
                                                          .Find(x => x.TipoOperacao == tipoOperacao && x.Titulo == titulo);

            if (operacao == null)
            {
                operacao = new NotaCorretagemOperacaoEntity(this, tipoOperacao, titulo, quantidade, precoLiquidacao);
                NotaCorretagemOperacaoCollection.Add(operacao); 
            }
            else
            {
                operacao.AtualizarQuantidade(tipoOperacao, quantidade); //TODO: Atualizar CustoAquisicao também.
            }
        }

        //TODO: Métodos para retornar % e Taxa de um título na nota (pode ter várias operações).

        #endregion

        #region Constructors

        public NotaCorretagemEntity(DateTime data, double taxaCorretagem, double taxaLiquidacao, double taxaEmolumentos, double taxaOutros)
        {
            Data = data;
            TaxaOperacao = new TaxaOperacaoValueObject(taxaCorretagem, taxaLiquidacao, taxaEmolumentos, taxaOutros);
            NotaCorretagemOperacaoCollection = new NotaCorretagemOperacaoCollection();
        }

        public NotaCorretagemEntity(DateTime data, double taxaLiquidacao, double taxaEmolumentos) :
            this(data, default, taxaLiquidacao, taxaEmolumentos, default)
        {
        }

        #endregion
    }
}
