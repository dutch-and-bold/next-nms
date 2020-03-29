using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NextNms.Libraries.Contracts;

namespace NextNms.HostedServices
{
    public class DeviceDiscoveryHostedService : IHostedService
    {
        private readonly IEnumerable<IDiscoverDevices> _discoverers;

        public DeviceDiscoveryHostedService(IEnumerable<IDiscoverDevices> discoverers)
        {
            _discoverers = discoverers;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var tasks = _discoverers.Select(o => o.Start());
            await Task.WhenAll(tasks);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}