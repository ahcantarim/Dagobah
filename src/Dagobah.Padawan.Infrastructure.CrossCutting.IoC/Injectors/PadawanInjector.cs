using Dagobah.Application.Services.Core;
using Dagobah.Domain.Contracts.ApplicationServices;
using Dagobah.Domain.Contracts.DomainServices;
using Dagobah.Domain.Contracts.Repositories;
using Dagobah.Domain.Contracts.UnitsOfWork;
using Dagobah.Domain.Contracts.UnitsOfWork.Core;
using Dagobah.Infrastructure.CrossCutting.IoC.Extensions;
using Dagobah.Padawan.Application.Contracts.Services;
using Dagobah.Padawan.Application.Services;
using Dagobah.Padawan.Domain.Contracts.Repositories;
using Dagobah.Padawan.Domain.Contracts.Services;
using Dagobah.Padawan.Domain.Services;
using Dagobah.Padawan.Infrastructure.Data.Contexts;
using Dagobah.Padawan.Infrastructure.Data.Repositories;
using Dagobah.Padawan.Infrastructure.Data.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Dagobah.Padawan.Infrastructure.CrossCutting.IoC.Injectors
{
    public static class PadawanInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //#region Application

            //// REM: Registrar as implementações de Application Services
            //services.AddScoped<INotaCorretagemApplicationService, NotaCorretagemApplicationService>();
            //services.AddScoped<INotaCorretagemOperacaoApplicationService, NotaCorretagemOperacaoApplicationService>();
            //services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

            //#endregion

            //#region Domain

            //// REM: Registrar as implementações de Domain Services
            //services.AddScoped<INotaCorretagemDomainService, NotaCorretagemDomainService>();
            //services.AddScoped<INotaCorretagemOperacaoDomainService, NotaCorretagemOperacaoDomainService>();
            //services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();

            //#endregion

            //#region Infrastructure

            //// REM: Registrar as implementações de Contexts
            //services.AddScoped<PadawanContext>();

            //// REM: Registrar as implementações de Units Of Work
            //services.AddScoped<IUnitOfWork, PadawanUnitOfWork>();

            //// REM: Registrar as implementações de Repositories
            //services.AddScoped<INotaCorretagemRepository, NotaCorretagemRepository>();
            //services.AddScoped<INotaCorretagemOperacaoRepository, NotaCorretagemOperacaoRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //#endregion




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
