using Microsoft.Extensions.DependencyInjection;
using Nordlys.DependencyInjection;

namespace Nordlys.Game.Sessions
{
    public class SessionService : IService
    {
        public void Register(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<SessionController>();
            serviceDescriptors.AddSingleton<SessionFactory>();
        }
    }
}
