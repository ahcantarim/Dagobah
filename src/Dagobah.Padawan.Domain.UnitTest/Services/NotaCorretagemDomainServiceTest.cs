using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dagobah.Padawan.Domain.UnitTest.Services
{
    /// <summary>
    /// Arrange-Act-Assert (AAA)
    /// 
    /// Arrange: Preparação dos objetos necessários para os testes.
    /// Act:     Execução da funcionalidade que será testada.
    /// Assert:  Garantia do resultado da funcionalidade.
    /// </summary>
    [TestClass]
    public class NotaCorretagemDomainServiceTest
    {
        private Mock<INotaCorretagemRepository> _notaCorretagemRepository;

        private INotaCorretagemDomainService _domainService;

        [TestInitialize]
        public void Initialize()
        {
            _notaCorretagemRepository = new Mock<INotaCorretagemRepository>();

            _domainService = new NotaCorretagemDomainService(_notaCorretagemRepository.Object);
        }

        [TestMethod]
        public void GerarNotaCorretagem()
        {
            #region Arrange

            var notaCorretagem = new Entities.NotaCorretagemEntity(new DateTime(2020, 3, 12), 0.53, 0.06);

            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "B3SA", 10, 33.85);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "ITSA", 100, 9.12);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "PSSA", 10, 47.40);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "ENBR", 13, 16.45);

            #endregion

            #region Act

            //_domainService.Add(notaCorretagem);

            var somaTaxasProporcionais = notaCorretagem.NotaCorretagemOperacaoCollection.Sum(x => x.TaxaOperacaoProporcional.Total);
            somaTaxasProporcionais = Math.Round(somaTaxasProporcionais, 2);

            #endregion

            #region Assert

            Assert.AreEqual(Math.Round(somaTaxasProporcionais, 2), Math.Round(notaCorretagem.TaxaOperacao.Total, 2));

            #endregion
        }

        [TestMethod]
        public void GerarNotasCorretagem2019()
        {
            #region Arrange

            var custosTotais = new Dictionary<Entities.NotaCorretagemEntity, double>();
            var notasCorretagem2019 = new List<Entities.NotaCorretagemEntity>();
            Entities.NotaCorretagemEntity notaCorretagem = null;

            notaCorretagem = new Entities.NotaCorretagemEntity(new DateTime(2019, 4, 16), 2.29, 0.34);
            custosTotais.Add(notaCorretagem, 8349.72);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "ALZR", 26, 95.99);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "GGRC", 45, 130.03);
            notasCorretagem2019.Add(notaCorretagem);

            notaCorretagem = new Entities.NotaCorretagemEntity(new DateTime(2019, 4, 30), 0.44, 0.06);
            custosTotais.Add(notaCorretagem, 1631.58);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "B3SA", 8, 34.32);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "EGIE", 9, 44.10);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "FLRY", 17, 20.77);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "MDIA", 8, 41.56);
            notaCorretagem.AdicionarOperacao(Enumerations.TipoOperacaoCorretagem.Compra, "WEGE", 15, 18.27);
            notasCorretagem2019.Add(notaCorretagem);

            #endregion

            #region Act

            foreach (var notaCorretagemAtual in notasCorretagem2019)
            {
                var somaTaxasProporcionais = notaCorretagemAtual.NotaCorretagemOperacaoCollection.Sum(x => x.TaxaOperacaoProporcional.Total);

                var custoTotalNotaAtual = custosTotais.First(x => x.Key == notaCorretagemAtual);

                #region Assert

                Assert.AreEqual(Math.Round(somaTaxasProporcionais, 2), Math.Round(notaCorretagemAtual.TaxaOperacao.Total, 2), 0.1);
                Assert.AreEqual(Math.Round(notaCorretagemAtual.CustoAquisicaoTotal, 2), Math.Round(custoTotalNotaAtual.Value, 2), 0.1);

                # endregion
            }

            #endregion
        }
    }
}
