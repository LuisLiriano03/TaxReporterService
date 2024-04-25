using Microsoft.EntityFrameworkCore;
using TaxReporter.DAL.DBContext;

namespace TaxReporter.IOC
{
    public static class IoC
    {
        public static void DependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaxReporterDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("myConnection"));
            });

        }

    }

}
