using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Moonlay.Manufactures.Domain.ValueObjects
{
    public class Goods : ValueObject, IProduct
    {
        public Goods(Guid productId, string name)
        {
            this.Identity = productId;
            this.Name = name;
        }

        public Goods(Product product)
        {
            this.Identity = product.Identity;
            this.Name = product.Name;
        }

        public Guid Identity { get; }
        public string Name { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}