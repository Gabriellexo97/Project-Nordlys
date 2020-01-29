using Nordlys.DependencyInjection;

namespace Nordlys.Game.Sessions
{
    public class SessionService : IService
    {
        public void Register(DependencyRegistrar dependencyRegistrar)
        {
            dependencyRegistrar.RegisterSingleton<SessionController>();
            dependencyRegistrar.RegisterSingleton<SessionFactory>();
        }
    }
}
