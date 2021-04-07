namespace Dagobah.Domain.Contracts.DomainServices.Core
{
    public interface IDomainServiceDelete<in TId>

        where TId : struct
    {
        void DeleteById(TId id);

        void SetAsActiveById(TId id);

        void SetAsInactiveById(TId id);
    }
}
