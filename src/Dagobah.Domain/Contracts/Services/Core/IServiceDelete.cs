namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceDelete<in TId>

        where TId : struct
    {
        void DeleteById(TId id);

        void SetAsActiveById(TId id);

        void SetAsInactiveById(TId id);
    }
}
