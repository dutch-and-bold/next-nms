using Lextm.SharpSnmpLib.Messaging;
using Microsoft.Extensions.DependencyInjection;
using NextNms.Libraries.Contracts;
using NextNms.Library.Snmp;

namespace NextNms.Extensions.DependencyInjection
{
    public static class SnmpServiceExtension
    {
        public static IServiceCollection AddSnmp(this IServiceCollection services)
        {
            services.AddSingleton<Discoverer>();

            services.Scan(
                o => o.FromAssemblyOf<NextNmsLibrarySnmpAssemblyPointer>()
                    .AddClasses(o => o.AssignableTo<IDiscoverDevices>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

            return services;
        }
    }
}