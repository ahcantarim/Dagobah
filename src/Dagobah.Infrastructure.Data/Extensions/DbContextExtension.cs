using System.Data.Entity;

namespace Dagobah.Infrastructure.Data.Extensions
{
    public static class DbContextExtension
    {
        public static void Update<TEntity>(this DbContext context, TEntity entity)
            where TEntity : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
