using Microsoft.EntityFrameworkCore;
using Moonlay.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Infrastructure
{
    public partial class ManufactureDbContext : DbContext, IUnitOfWork
    {
        public ManufactureDbContext(DbContextOptions<ManufactureDbContext> options) : base(options)
        {

        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            base.SaveChangesAsync(cancellationToken);

            return Task.FromResult(true);
        }
    }
}
