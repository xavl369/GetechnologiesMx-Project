using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GetechnologiesMx.Application {
    public static class ApplicationServiceRegistration {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            
            services.AddScoped<IDirectoryService, DirectoryService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
