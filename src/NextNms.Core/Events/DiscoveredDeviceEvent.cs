using System;
using MediatR;
using NextNms.Core.Entities;

namespace NextNms.Core.Events
{
    public class DiscoveredDeviceEvent : INotification
    {
        public DiscoveredDeviceEvent(Device device)
        {
            Device = device ?? throw new ArgumentNullException(nameof(device));
        }

        public Device Device { get; }
    }
}