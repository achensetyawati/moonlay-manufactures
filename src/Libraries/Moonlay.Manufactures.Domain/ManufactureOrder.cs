using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Domain.ValueObjects;
using System;

namespace Moonlay.Manufactures.Domain
{
    public class ManufactureOrder : Entity, IAggregateRoot
    {
        public ManufactureOrder(Guid identity, string code, UnitDepartment unit, ManufactureFlow flow, Goods goods)
        {
            this.Identity = identity;
            this.Code = code;
            this.Unit = unit;
            this.Flow = flow;
            this.Goods = goods;
        }

        public string Code { get; }
        public UnitDepartment Unit { get; }
        public ManufactureFlow Flow { get; }
        public Goods Goods { get; }
    }
}