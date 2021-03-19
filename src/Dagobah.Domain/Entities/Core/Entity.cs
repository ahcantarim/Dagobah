using System;

namespace Dagobah.Domain.Entities.Core
{
    /// <summary>
    /// Classe base para as entidades do domínio.
    /// Para transformar uma classe em uma entidade, basta herdá-la.
    /// O tipo da propriedade Id foi limitada para que seja permitidos apenas structs (int, string, DateTime, Guid, etc).
    /// A classe foi criada como abstrata para que seja possível apenas herdá-la.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T>
        where T : struct
    {
        #region States

        /// <summary>
        /// Código único para identificação do objeto.
        /// Definido como virtual para que seja possível sobrescrevê-lo e adicionar DataAnotations, se necessário.
        /// </summary>
        public virtual T Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

        public DateTime? DeletedAt { get; protected set; }

        public bool IsActive => !DeletedAt.HasValue;

        #endregion

        #region Behaviors

        public void SetUpdated()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetActive(bool active)
        {
            if (active)
                DeletedAt = default; 
            else
                DeletedAt = DateTime.Now;
        }

        #endregion

        #region Constructors

        public Entity()
        {
            // Ao instanciar um novo objeto, a data de criação é definida automaticamente.
            CreatedAt = DateTime.Now;
        }

        #endregion
    }
}
