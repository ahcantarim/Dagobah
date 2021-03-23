using Dagobah.Domain.Entities.Core;
using Dagobah.Padawan.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Dagobah.Padawan.Domain.Entities
{
    public class NotaCorretagemEntity :
        BaseEntity<Guid>
    {
        #region States

        public DateTime Data { get; private set; }

        public decimal TaxaLiquidacao { get; private set; }

        public decimal TaxaEmolumentos { get; private set; }

        public decimal TotalTaxas => TaxaLiquidacao + TaxaEmolumentos;

        public IList<NotaCorretagemDetalheEntity> NotaCorretagemDetalheEntities { get; set; }

        #endregion

        #region Behaviors

        public void AdicionarOperacao(TipoOperacaoCorretagem tipoOperacao, string titulo, int quantidade, decimal precoLiquidacao)
        {
            NotaCorretagemDetalheEntities.Add(new NotaCorretagemDetalheEntity(tipoOperacao, titulo, quantidade, precoLiquidacao));
        }

        #endregion

        #region Constructors

        public NotaCorretagemEntity()
        {
            NotaCorretagemDetalheEntities = new List<NotaCorretagemDetalheEntity>();
        }

        public NotaCorretagemEntity(DateTime data, decimal taxaLiquidacao, decimal taxaEmolumentos) :
            this()
        {
            Data = data;
            TaxaLiquidacao = taxaLiquidacao;
            TaxaEmolumentos = taxaEmolumentos;
        }

        #endregion
    }
}
