using Moonlay.Manufactures.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.EventHandlers
{
    public class OnManufactureOroderPlacedHandler : IManufactureEventHandler<OnManufactureOroderPlaced>
    {
        public Task Handle(OnManufactureOroderPlaced notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
