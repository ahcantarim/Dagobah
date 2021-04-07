using System.Collections.Generic;
using System.Linq;

namespace Dagobah.Domain.ValueObjects.Core
{
    /// <summary>
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class BaseValueObject
    {
        protected static bool EqualOperator(BaseValueObject left, BaseValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(BaseValueObject left, BaseValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (BaseValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Ao implementar este método na classe derivada, utilize o "yield return PROPRIEDADE;" para retornar todas as propriedades uma a uma.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
