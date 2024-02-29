using GetechnologiesMx.Persistence.Contracts;
using GetechnologiesMx.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GetechnologiesMx.Persistence {
    public static class PersistenceServiceRegistration {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<GetechnologiesMxDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("GetechnologiesMxApp"))
            );

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            return services;
        }
    }
}
