using Dagobah.Padawan.Infrastructure.CrossCutting.IoC.Injectors;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dagobah.Padawan.Presentation.AspNetCore.WebApplication.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            PadawanInjector.RegisterServices(services);
        }

        //public static void AddDependencyInjectionConfiguration(this SimpleInjector.Container container)
        //{
        //    if (container == null)
        //        throw new ArgumentNullException(nameof(container));

        //    //TODO: Registrar serviços do IoC.
        //    PadawanInjector.RegisterServices(container, SimpleInjector.Lifestyle.Scoped);
        //}
    }
}
