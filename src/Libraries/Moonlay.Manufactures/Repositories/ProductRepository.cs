using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Infrastructure;
using System;
using System.Linq;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ManufactureDbContext _context;

        public ProductRepository(ManufactureDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Product GetProductById(Guid identity)
        {
            return _context.Products.FirstOrDefault(o => o.Identity == identity);
        }
    }
}