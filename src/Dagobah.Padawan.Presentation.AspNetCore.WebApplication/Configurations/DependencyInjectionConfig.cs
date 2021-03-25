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

            //TODO: Registrar serviços do IoC.
            //PadawanInjector.RegisterServices(services);
        }
    }
}
