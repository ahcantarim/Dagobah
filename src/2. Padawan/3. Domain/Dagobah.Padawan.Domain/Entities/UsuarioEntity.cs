using Dagobah.Domain.Entities.Core;
using System;

namespace Dagobah.Padawan.Domain.Entities
{
    public class UsuarioEntity : 
        BaseEntity<int>
    {
        #region States

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public bool Confirmado { get; private set; }

        public DateTime? UltimoAcessoEm { get; private set; }

        #endregion
    }
}
