namespace Dagobah.Domain.Contracts.Services.Core
{
    public interface IServiceDelete<in TId>
        where TId : struct
    {
        void DeleteFisicallyById(TId id);

        void DeleteLogicallyById(TId id);
    }
}
