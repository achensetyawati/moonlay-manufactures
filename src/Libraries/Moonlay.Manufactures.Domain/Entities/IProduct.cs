using System;

namespace Moonlay.Manufactures.Domain.Entities
{
    public interface IProduct
    {
        Guid Identity { get; }
        string Name { get; }
    }
}