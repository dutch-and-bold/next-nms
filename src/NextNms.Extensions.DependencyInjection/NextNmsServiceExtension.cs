using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NextNms.Core;
using NextNms.HostedServices;
using NextNms.Libraries;

namespace NextNms.Extensions.DependencyInjection
{
    public static class NextNmsServiceExtension
    {
        public static IServiceCollection AddNextNms(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(NextNmsCoreAssemblyPointer).Assembly,
                typeof(NextNmsLibraryAssemblyPointer).Assembly);
            services.AddHostedService<DeviceDiscoveryHostedService>();

            return services;
        }
    }
}