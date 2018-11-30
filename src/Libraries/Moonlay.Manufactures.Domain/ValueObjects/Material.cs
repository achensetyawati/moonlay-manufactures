using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using System.Collections.Generic;

namespace Moonlay.Manufactures.Domain.ValueObjects
{
    public class Material : ValueObject
    {
        public Material(Product product)
        {
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }
    }
}