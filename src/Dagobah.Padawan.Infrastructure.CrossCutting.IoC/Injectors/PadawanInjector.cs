using Dagobah.Application.Services.Core;
using Dagobah.Domain.Contracts.ApplicationServices;
using Dagobah.Domain.Contracts.DomainServices;
using Dagobah.Domain.Contracts.Repositories;
using Dagobah.Domain.Contracts.UnitsOfWork;
using Dagobah.Domain.Contracts.UnitsOfWork.Core;
using Dagobah.Domain.Services.Core;
using Dagobah.Infrastructure.CrossCutting.IoC.Extensions;
using Dagobah.Infrastructure.Data.Contexts.Core;
using Dagobah.Infrastructure.Data.Repositories.Core;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Application.Services;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Services;
using Dagobah.Padawan.Infrastructure.Data.Contexts;
using Dagobah.Padawan.Infrastructure.Data.Repositories;
using Dagobah.Padawan.Infrastructure.Data.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Dagobah.Padawan.Infrastructure.CrossCutting.IoC.Injectors
{
    //public static class ContainerExtension
    //{
    //    ////Esta extensão permite que que seja registrado um lote através de um assembly e namespace.
    //    ////Com isso, precisamos apontar apenas o caminho do da classe concreta e o assembly em que ela está.
    //    //public static void BatchRegister(this SimpleInjector.Container container, Assembly assembly, string nameSpace, SimpleInjector.Lifestyle lifestyle)
    //    //{
    //    //    //Funcionalidade retirada do próprio site do SimpleInjector.
    //    //    //Apenas foi adaptada para trabalhar com mais facilidade na nossa ferramenta.
    //    //    //https://simpleinjector.readthedocs.org/en/latest/advanced.html?highlight=automatic%20register#batch-registration

    //    //    //Consulta todas as classes e interfaces para registrar no container:
    //    //    //var registrations =
    //    //    //    from type in assembly.GetExportedTypes()
    //    //    //    where type.Namespace == nameSpace
    //    //    //    where type.GetInterfaces().Any()
    //    //    //    select new { Service = type.GetInterfaces().Single(), Implementation = type };

    //    //    //var registrations =
    //    //    //    from type in assembly.GetExportedTypes()
    //    //    //    where type.Namespace == nameSpace
    //    //    //    from service in type.GetInterfaces()
    //    //    //    select new { service, implementation = type };

    //    //    //foreach (var reg in registrations)
    //    //    //{
    //    //    //    container.Register(reg.service, reg.implementation, Lifestyle.Transient);
    //    //    //    return;
    //    //    //}


    //    //    var registrations =
    //    //        assembly.GetExportedTypes().Where(x => x.Namespace == nameSpace).Where(x => x.GetInterfaces().Any()).Select(x => new
    //    //        {
    //    //            Service = x.GetInterfaces().Where(y => y.Name == $"I{x.Name}").Single(),
    //    //            Implementation = x
    //    //        });

    //    //    //Registrar no container todas as classes encontradas:
    //    //    foreach (var reg in registrations)
    //    //        container.Register(reg.Service, reg.Implementation, lifestyle);
    //    //}

    //    ////Esta extensão automatiza a funcionalidade RegisterBatch, pois
    //    //// basta passar um tipo base que automaticamente vai buscar os outros dentro do mesmo assembly e mesmo namespace.
    //    //public static void BatchRegister<TService>(this SimpleInjector.Container container, SimpleInjector.Lifestyle lifestyle)
    //    //    where TService : class
    //    //{
    //    //    var type = typeof(TService);
    //    //    container.BatchRegister(type.Assembly, type.Namespace, lifestyle);
    //    //}
    //}

    //public static class PadawanInjectorExtensions
    //{
    //    public static void BatchRegister<TService>(this IServiceCollection services)
    //            where TService : class
    //    {
    //        var type = typeof(TService);
    //        services.BatchRegister(type.Assembly, type.Namespace);
    //    }

    //    public static void BatchRegister(this IServiceCollection services, Assembly assembly, string nameSpace)
    //    {
    //        var registrations =
    //            assembly.GetExportedTypes().Where(x => x.Namespace == nameSpace).Where(x => x.GetInterfaces().Any()).Select(x =>
    //            new TypesInAssembly(x.GetInterfaces().Where(y => y.Name == $"I{x.Name}").Single(), x);
    //        //{
    //        //    Service = x.GetInterfaces().Where(y => y.Name == $"I{x.Name}").Single(),
    //        //    Implementation = x
    //        //});

    //        foreach (var registration in registrations)
    //            services.AddScoped < registration.Service.GetType(), registration.Implementation.Get > ();
    //    }
    //}

    public static class PadawanInjector
    {
        //public static void RegisterServices(SimpleInjector.Container container, SimpleInjector.Lifestyle lifestyle)
        //{
        //    //container.Register(typeof(DbContext));
        //    container.Register(typeof(BaseContext));
        //    container.Register(typeof(PadawanContext));

        //    container.Register(typeof(IUnitOfWork), typeof(PadawanUnitOfWork));

        //    container.BatchRegister<UsuarioRepository>(lifestyle);
        //    container.BatchRegister<UsuarioDomainService>(lifestyle);
        //    container.BatchRegister<UsuarioApplicationService>(lifestyle);
        //}

        public static void RegisterServices(IServiceCollection services)
        {
            #region Application

            // REM: Registrar as implementações de Application Services
            services.AddScoped<INotaCorretagemApplicationService, NotaCorretagemApplicationService>();
            services.AddScoped<INotaCorretagemOperacaoApplicationService, NotaCorretagemOperacaoApplicationService>();
            services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

            #endregion

            #region Domain

            // REM: Registrar as implementações de Domain Services
            services.AddScoped<INotaCorretagemDomainService, NotaCorretagemDomainService>();
            services.AddScoped<INotaCorretagemOperacaoDomainService, NotaCorretagemOperacaoDomainService>();
            services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();

            #endregion

            #region Infrastructure

            // REM: Registrar as implementações de Contexts
            //services.AddScoped<DbContext>();
            services.AddScoped<BaseContext>();
            services.AddScoped<PadawanContext>();

            // REM: Registrar as implementações de Units Of Work
            services.AddScoped<IUnitOfWork, PadawanUnitOfWork>();

            // REM: Registrar as implementações de Repositories
            services.AddScoped<INotaCorretagemRepository, NotaCorretagemRepository>();
            services.AddScoped<INotaCorretagemOperacaoRepository, NotaCorretagemOperacaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion




            //// Application Service
            //foreach (TypesInAssembly currentType in ServiceProviderExtension.BatchRegister<UsuarioApplicationService>())
            //    services.Add(new ServiceDescriptor(currentType.Service.GetType(), currentType.Implementation.GetType(), ServiceLifetime.Transient));

            //// Domain Service
            //foreach (TypesInAssembly currentType in ServiceProviderExtension.BatchRegister<UsuarioDomainService>())
            //    services.Add(new ServiceDescriptor(currentType.Service.GetType(), currentType.Implementation.GetType(), ServiceLifetime.Transient));

            //// Repositories
            //foreach (TypesInAssembly currentType in ServiceProviderExtension.BatchRegister<UsuarioRepository>())
            //    services.Add(new ServiceDescriptor(currentType.Service.GetType(), currentType.Implementation.GetType(), ServiceLifetime.Transient));

            //System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(item => item.GetInterfaces()
            //    .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseApplicationService<,>)) && !item.IsAbstract && !item.IsInterface)
            //    .ToList()
            //    .ForEach(assignedTypes =>
            //    {
            //        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseApplicationService<,>));
            //        services.AddTransient(serviceType, assignedTypes);
            //    });

            //System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(item => item.GetInterfaces()
            //    .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseDomainService<,>)) && !item.IsAbstract && !item.IsInterface)
            //    .ToList()
            //    .ForEach(assignedTypes =>
            //    {
            //        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseDomainService<,>));
            //        services.AddTransient(serviceType, assignedTypes);
            //    });

            //System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(item => item.GetInterfaces()
            //    .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<,>)) && !item.IsAbstract && !item.IsInterface)
            //    .ToList()
            //    .ForEach(assignedTypes =>
            //    {
            //        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<,>));
            //        services.AddTransient(serviceType, assignedTypes);
            //    });

            //services.AddScoped<PadawanContext>();
            //services.AddScoped<IBaseUnitOfWork, PadawanUnitOfWork>();
            //services.AddScoped<IUnitOfWork, PadawanUnitOfWork>();
        }
    }
}
