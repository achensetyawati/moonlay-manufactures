using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moonlay.Manufactures.Application;
using Moonlay.Manufactures.Domain.Repositories;
using Moonlay.Manufactures.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ManufactureDbContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), optSql => { });
            });

            services.AddTransient<IManufactureOrderService, ManufactureOrderService>();

            services.AddTransient<IManufactureOrderRepository, ManufactureOrderRepository>();
        }
    }
}
