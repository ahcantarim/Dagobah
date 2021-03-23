namespace Dagobah.Domain.Contracts.ApplicationServices.Core
{
    public interface IApplicationServiceDelete<in TId>

        where TId : struct
    {
        void DeleteById(TId id);

        void SetAsActiveById(TId id);

        void SetAsInactiveById(TId id);
    }
}
