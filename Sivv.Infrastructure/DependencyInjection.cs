using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sivv.Domain.Interfaces;
using Sivv.Infrastructure.Data;
using Sivv.Infrastructure.Repositories;

namespace Sivv.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            // postgre connection
            services.AddDbContext<ApplicationDbContext>(options =>
     options.UseNpgsql(
         configuration.GetConnectionString("DefaultConnection"),
         b => b.MigrationsAssembly("Sivv.Infrastructure"))); 

            // repositories
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            return services;
        }
    }
}
