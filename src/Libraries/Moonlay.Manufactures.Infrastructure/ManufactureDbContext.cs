using Microsoft.EntityFrameworkCore;
using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Domain.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Infrastructure
{
    public partial class ManufactureDbContext : DbContext, IUnitOfWork
    {
        public ManufactureDbContext(DbContextOptions<ManufactureDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<ManufactureOrderReadModel> ManufactureOrders => Set<ManufactureOrderReadModel>();

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            base.SaveChangesAsync(cancellationToken);

            return Task.FromResult(true);
        }
    }
}