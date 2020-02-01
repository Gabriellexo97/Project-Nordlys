using Microsoft.Extensions.DependencyInjection;
using Nordlys.DependencyInjection;

namespace Nordlys.Game.Habbos
{
    class HabboService : IService
    {
        public void Register(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<HabboController>();
            serviceDescriptors.AddSingleton<HabboDao>();
        }
    }
}
