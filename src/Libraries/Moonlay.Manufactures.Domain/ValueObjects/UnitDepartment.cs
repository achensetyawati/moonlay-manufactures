using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.Manufactures.Domain.ValueObjects
{
    public class UnitDepartment : ValueObject
    {
        public UnitDepartment(Guid departmentId, string name)
        {
            Identity = departmentId;
            Name = name;
        }

        public UnitDepartment(Department department)
        {
            this.Identity = department.Identity;
            this.Name = department.Name;
        }

        public Guid Identity { get; }
        public string Name { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
