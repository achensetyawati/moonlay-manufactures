using MediatR;

namespace Moonlay.Manufactures.Events
{
    public interface IManufactureEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IManufactureEvent
    {
    }
}