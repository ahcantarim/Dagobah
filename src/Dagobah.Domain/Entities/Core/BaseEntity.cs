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
    public abstract class BaseEntity<T>

        where T : struct
    {
        #region States

        /// <summary>
        /// Código único para identificação do objeto.
        /// Definido como virtual para que seja possível sobrescrevê-lo e adicionar DataAnotations, se necessário.
        /// </summary>
        public virtual T Id { get; protected set; }

        public virtual DateTime CreatedAt { get; protected set; }

        public virtual DateTime? UpdatedAt { get; protected set; }

        public virtual DateTime? DeletedAt { get; protected set; }

        public bool IsActive => !DeletedAt.HasValue;

        #endregion

        #region Behaviors

        public void SetAsUpdated()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetAsActive()
        {
            DeletedAt = default;
            SetAsUpdated();
        }

        public void SetAsInactive()
        {
            DeletedAt = DateTime.Now;
            SetAsUpdated();
        }

        #endregion

        #region Constructors

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public BaseEntity(T id)
            : this()
        {
            Id = id;
        }

        #endregion
    }
}
