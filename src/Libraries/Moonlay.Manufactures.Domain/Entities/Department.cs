using Moonlay.Domain;
using System;

namespace Moonlay.Manufactures.Domain.Entities
{
    public class Department : Entity
    {
        public Department(Guid identity, string name)
        {
            Identity = identity;
            Name = name;
        }

        public string Name { get; }
    }
}
