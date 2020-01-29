using Nordlys.Communication.Messages;
using Nordlys.Core.Console;
using Nordlys.DependencyInjection;
using Nordlys.Game.Habbos;
using Nordlys.Game.Sessions;
using Nordlys.Network.Game;
using System.Threading.Tasks;

namespace Nordlys
{
    public static class Nordlys
    {
        static async Task Main()
        {
            DependencyRegistrar dependencyRegistrar = new DependencyRegistrar();

            dependencyRegistrar.RegisterSingleton<MessageHandler>();
            dependencyRegistrar.RegisterSingleton<GameNetworkListener>();
            dependencyRegistrar.RegisterSingleton<ConsoleCommandHandler>();

            dependencyRegistrar.RegisterService<SessionService>();
            dependencyRegistrar.RegisterService<HabboService>();

            dependencyRegistrar.BuildServiceProvider();

            dependencyRegistrar.Resolve<MessageHandler>().RegisterEvents(dependencyRegistrar.ServiceProvider);

            GameNetworkListener listener = dependencyRegistrar.Resolve<GameNetworkListener>();

            await listener.StartAsync(30000);

            while (true)
            {
                string input = await System.Console.In.ReadLineAsync();

                if (input.Length > 0)
                {
                    await dependencyRegistrar.Resolve<ConsoleCommandHandler>().TryHandleCommandAsync(input);
                }
            }
        }
    }
}
