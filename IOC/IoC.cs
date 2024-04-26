using Microsoft.EntityFrameworkCore;
using TaxReporter.DAL.DBContext;
using TaxReporter.DAL.Repository.Contract;

namespace TaxReporter.IOC
{
    public static class IoC
    {
        public static void DependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaxReporterDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("myConnection"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(IGenericRepository<>));

        }

    }

}
