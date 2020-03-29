using System.Net;
using System.Threading.Tasks;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using MediatR;
using NextNms.Core.Entities;
using NextNms.Core.Events;
using NextNms.Libraries.Contracts;

namespace NextNms.Library.Snmp.V1
{
    public class Devices : IDiscoverDevices
    {
        private readonly Discoverer _discoverer;

        private readonly IMediator _mediator;

        public Devices(Discoverer discoverer, IMediator mediator)
        {
            _discoverer = discoverer;
            _mediator = mediator;
        }

        public async Task Start()
        {
            _discoverer.AgentFound += DiscovererAgentFound;
            await _discoverer.DiscoverAsync(
                VersionCode.V1,
                new IPEndPoint(IPAddress.Broadcast, 161),
                new OctetString("public"),
                6000);
        }

        private void DiscovererAgentFound(object sender, AgentFoundEventArgs e)
        {
            var device = new Device(
                e.Agent.Address,
                e.Variable == null ? "N/A (V3)" : e.Variable.Data.ToString())
            {
                DiscoveredBy = GetType()
            };

            _mediator.Publish(new DiscoveredDeviceEvent(device));
        }
    }
}