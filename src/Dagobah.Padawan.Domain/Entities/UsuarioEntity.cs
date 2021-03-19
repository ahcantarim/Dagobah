using Dagobah.Domain.Entities.Core;
using System;

namespace Dagobah.Padawan.Domain.Entities
{
    public class UsuarioEntity : Entity<int>
    {
        #region States

        //TODO: Avaliar se devem ser "private set" (apenas a própria classe pode controlar suas características).

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Confirmado { get; set; }

        public DateTime? UltimoAcessoEm { get; set; }

        #endregion
    }
}
