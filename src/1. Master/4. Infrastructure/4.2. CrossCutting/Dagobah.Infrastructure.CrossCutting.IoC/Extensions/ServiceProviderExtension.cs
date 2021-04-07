using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dagobah.Infrastructure.CrossCutting.IoC.Extensions
{
    //public static class ServiceCollectionExtensions
    //{
    //    public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
    //        ServiceLifetime lifetime = ServiceLifetime.Transient)
    //    {
    //        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
    //        foreach (var type in typesFromAssemblies)
    //            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
    //    }
    //}
    //
    // Utilização:
    // services.RegisterAllTypes<IMinhaInterface>(new[] { typeof(Startup).Assembly });

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


        public static dynamic BatchRegister(Assembly assembly, string @namespace)
        {
            var typesFromAssemblies = new[] { assembly }.SelectMany(a => a.GetExportedTypes().Where(et => et.Namespace == @namespace && et.GetInterfaces().Any()));
            
            return typesFromAssemblies.Select(x => new TypesInAssembly(x.GetInterfaces().LastOrDefault(), x));

            //foreach (var type in typesFromAssemblies)
            //    services.Add(new ServiceDescriptor(typeof(T), type, lifetime));

            ////var registrations =
            ////   from type in assembly.GetExportedTypes()
            ////   where type.Namespace == @namespace
            ////   where type.GetInterfaces().Any()
            ////   //select new TypesInAssembly(type.GetInterfaces().Single(), type);
            ////   select new
            ////   {
            ////       Service = type.GetInterfaces().Single(),
            ////       Implementation = type
            ////   };

            ////return registrations;
        }

        public static dynamic BatchRegister<TService>()
           where TService : class
        {
            var type = typeof(TService);
            return BatchRegister(type.Assembly, type.Namespace);
        }
    }

    public class TypesInAssembly
    {
        public Type Service { get; private set; }

        public Type Implementation { get; private set; }

        public TypesInAssembly(Type service, Type implementation)
        {
            Service = service;
            Implementation = implementation;
        }
    }
}
