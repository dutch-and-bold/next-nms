using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NextNms.Core.Events;

namespace NextNms.Libraries.EventHandlers
{
    public class DiscoverDeviceEventHandler : INotificationHandler<DiscoveredDeviceEvent>
    {
        public Task Handle(DiscoveredDeviceEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Device discovered [{notification.Device.IpAddress}] [{notification.Device.DeviceName}]");

            return Task.CompletedTask;
        }
    }
}