using Nordlys.DependencyInjection;

namespace Nordlys.Game.Habbos
{
    class HabboService : IService
    {
        public void Register(DependencyRegistrar dependencyRegistrar)
        {
            dependencyRegistrar.RegisterSingleton<HabboController>();
            dependencyRegistrar.RegisterSingleton<HabboDao>();
        }
    }
}
