using System;
using System.Net;

namespace NextNms.Core.Entities
{
    public class Device
    {
        public Device(IPAddress ipAddress, string deviceName)
        {
            IpAddress = ipAddress;
            DeviceName = deviceName;
        }

        public IPAddress IpAddress { get; }

        public string DeviceName { get; }

        public Type DiscoveredBy { get; set; }
    }
}