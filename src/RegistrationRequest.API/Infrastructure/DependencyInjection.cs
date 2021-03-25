using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationRequest.API.Domain.Repositories;
using RegistrationRequest.API.Infrastructure.Persistence;
using RegistrationRequest.API.Infrastructure.Persistence.Repositories;
using RegistrationRequest.API.Infrastructure.Services;

namespace RegistrationRequest.API.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:RegistrationFormConnection"]);
                options.EnableSensitiveDataLogging();
            });

            /// NOTE: Here we also use a scoped lifetime because these classes internally have to use the database context class.
            /// It makes sense to specify the same scope in this case.
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}