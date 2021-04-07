namespace Dagobah.Domain.Contracts.Repositories.Core
{
    public interface IRepositoryDelete<in TId>

        where TId : struct
    {
        void DeleteById(TId id);

        void SetAsActiveById(TId id);

        void SetAsInactiveById(TId id);
    }
}
