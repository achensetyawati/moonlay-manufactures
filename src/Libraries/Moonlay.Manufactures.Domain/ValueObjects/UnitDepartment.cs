using Moonlay.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.Manufactures.Domain.ValueObjects
{
    public class UnitDepartment : ValueObject
    {
        public UnitDepartment(Guid departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }

        public Guid DepartmentId { get; }
        public string Name { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
