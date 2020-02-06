using Microsoft.Extensions.DependencyInjection;
using Nordlys.Communication.Messages;
using Nordlys.Communication.Messages.Incoming.Handshake;
using Nordlys.Core.Console;
using Nordlys.Core.Console.Commands;
using Nordlys.DependencyInjection;

namespace Nordlys.Util
{
    public static class ServiceCollectionExtensions
    {
        public static void AddService<T>(this IServiceCollection serviceDescriptors) where T : IService, new()
        {
            new T().Register(serviceDescriptors);
        }

        public static void RegisterConsoleCommands(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<ICommand, ClearCommand>();
        }

        public static void RegisterMessageEvents(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<IMessageEvent, ReadReleaseMessageEvent>();
        }
    }
}
