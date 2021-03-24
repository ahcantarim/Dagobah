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

        public double PrecoTotal => Math.Round(NotaCorretagemDetalheCollection.Sum(x => x.PrecoTotal), 2);

        public double CustoAquisicaoTotal => Math.Round(NotaCorretagemDetalheCollection.Sum(x => x.CustoAquisicao), 2);

        #endregion

        #region Behaviors

        public void AdicionarOperacao(TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, double precoLiquidacao)
        {
            //TODO: Adicionar validações (operação existente, título preenchido, quantidade válida, preço válido, etc).

            titulo = titulo.ToUpper();

            var operacao = NotaCorretagemDetalheCollection.ToList()
                                                          .Find(x => x.TipoOperacao == tipoOperacao && x.Titulo == titulo);

            if (operacao == null)
            {
                operacao = new NotaCorretagemDetalheEntity(this, tipoOperacao, titulo, quantidade, precoLiquidacao);
                NotaCorretagemDetalheCollection.Add(operacao); 
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
            NotaCorretagemDetalheCollection = new NotaCorretagemDetalheCollection();
        }

        public NotaCorretagemEntity(DateTime data, double taxaLiquidacao, double taxaEmolumentos) :
            this(data, default, taxaLiquidacao, taxaEmolumentos, default)
        {
        }

        #endregion
    }
}
