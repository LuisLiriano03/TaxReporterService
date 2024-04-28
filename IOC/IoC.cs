using Microsoft.EntityFrameworkCore;
using TaxReporter.AutoMapper;
using TaxReporter.Contracts;
using TaxReporter.DBContext;
using TaxReporter.Repository;
using TaxReporter.Repository.Contract;
using TaxReporter.Services;

namespace TaxReporter.IOC
{
    public static class IoC
    {
        public static void DependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaxHubDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("myConnection"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

        }

    }

}
