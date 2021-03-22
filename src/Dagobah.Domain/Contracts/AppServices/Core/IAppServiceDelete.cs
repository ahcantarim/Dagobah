namespace Dagobah.Domain.Contracts.AppServices.Core
{
    public interface IAppServiceDelete<in TId>

        where TId : struct
    {
        void DeleteById(TId id);

        void SetAsActiveById(TId id);

        void SetAsInactiveById(TId id);
    }
}
