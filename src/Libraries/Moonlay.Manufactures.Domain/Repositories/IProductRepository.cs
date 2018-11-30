using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using System;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductById(Guid identity);
    }
}