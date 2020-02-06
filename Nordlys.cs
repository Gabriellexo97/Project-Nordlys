using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nordlys.Communication.Messages;
using Nordlys.Core.Console;
using Nordlys.DependencyInjection;
using Nordlys.Game.Habbos;
using Nordlys.Game.Sessions;
using Nordlys.Network.Game;
using Nordlys.Util;
using System;
using System.Threading.Tasks;

namespace Nordlys
{
    public static class Nordlys
    {
        static async Task Main()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddLogging(builder => builder.AddConsole());
            serviceDescriptors.AddSingleton<MessageHandler>();
            serviceDescriptors.AddSingleton<GameNetworkListener>();
            serviceDescriptors.AddSingleton<ConsoleCommandHandler>();

            serviceDescriptors.AddService<SessionService>();
            serviceDescriptors.AddService<HabboService>();

            serviceDescriptors.RegisterConsoleCommands();

            ServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();

            await serviceProvider.GetRequiredService<HabboDbContext>().Database.MigrateAsync();

            //serviceProvider.GetService<MessageHandler>().RegisterEvents();

            GameNetworkListener listener = serviceProvider.GetService<GameNetworkListener>();

            await listener.StartAsync(30000);

            while (true)
            {
                string input = await System.Console.In.ReadLineAsync();

                if (input.Length > 0)
                {
                    await serviceProvider.GetService<ConsoleCommandHandler>().TryHandleCommandAsync(input);
                }
            }
        }
    }
}
