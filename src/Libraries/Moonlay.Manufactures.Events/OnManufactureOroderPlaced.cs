using System;

namespace Moonlay.Manufactures.Events
{
    public class OnManufactureOroderPlaced : IManufactureEvent
    {
        public OnManufactureOroderPlaced(Guid orderId)
        {
            this.OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}