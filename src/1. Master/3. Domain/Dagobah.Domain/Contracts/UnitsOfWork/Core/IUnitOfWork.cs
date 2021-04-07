using System;

namespace Dagobah.Domain.Contracts.UnitsOfWork.Core
{
    /// <summary>
    /// Pattern UnitOfWork. (Unidade de Trabalho)
    /// Responsáveis pelas ações comuns.
    /// Foi feito um core, pois o sistema pode trabalhar com mais
    ///  de uma conexão. Neste caso, cada conexão deve ter a sua
    ///  unidade de trabalho.
    /// Implementamos o IDisposable para forçarmos a limpeza da memória.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Método responsável por iniciar uma transação.
        /// </summary>
        void Begin();

        /// <summary>
        /// Método responsável por finalizar uma transação.
        /// </summary>
        void Commit();
    }
}
