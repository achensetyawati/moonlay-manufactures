using Moonlay.Domain;
using Moonlay.Manufactures.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Moonlay.Manufactures.Domain.Entities
{
    public class ManufactureFlow : Entity
    {
        public ManufactureFlow(Guid identity, Goods product, IList<ManufactureOrderActivityType> orderActivityTypes)
        {
            this.Identity = identity;
            this.Goods = product;

            this.OrderActivityTypes = orderActivityTypes;
        }

        public Goods Goods { get; }
        public IList<ManufactureOrderActivityType> OrderActivityTypes { get; }
    }
}