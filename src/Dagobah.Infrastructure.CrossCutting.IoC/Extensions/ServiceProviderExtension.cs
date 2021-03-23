using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Dagobah.Infrastructure.CrossCutting.IoC.Extensions
{
    public static class ServiceProviderExtension
    {
        public static IEnumerable BatchRegister(this IServiceProvider serviceProvider, Assembly assembly, string @namespace)
        {
            var registrations =
               from type in assembly.GetExportedTypes()
               where type.Namespace == @namespace
               where type.GetInterfaces().Any()
               select new
               {
                   Service = type.GetInterfaces().Single(),
                   Implementation = type
               };

            return registrations;
        }

        public static IEnumerable BatchRegister<TService>(this IServiceProvider serviceProvider)
           where TService : class
        {
            var type = typeof(TService);
            return serviceProvider.BatchRegister(type.Assembly, type.Namespace);
        }
    }
}
