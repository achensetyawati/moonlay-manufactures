using Moonlay.Domain;
using System;

namespace Moonlay.Manufactures.Domain.Entities
{
    public class Product : Entity, IProduct
    {
        public Product(Guid identity, string name)
        {
            this.Identity = identity;
            this.Name = name;
        }

        public string Name { get; }
    }
}