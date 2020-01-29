using Microsoft.Extensions.Logging;
using Nordlys.Core.Console.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nordlys.Core.Console
{
    public class ConsoleCommandHandler
    {
        private readonly Dictionary<string, ICommand> commands;
        private readonly ILogger<ConsoleCommandHandler> logger;

        public ConsoleCommandHandler(ILogger<ConsoleCommandHandler> logger)
        {
            this.logger = logger;

            commands = new Dictionary<string, ICommand>
            {
                { "clear", new ClearCommand() }
            };
        }

        public async Task TryHandleCommandAsync(string input)
        {
            int spacePosition = input.IndexOf(' ');
            string header = spacePosition >= 0 ? input.Substring(0, spacePosition) : input;

            if (commands.Any(command => command.Key == header))
            {
                await commands[header].RunAsync(input.Substring(spacePosition + 1).Split(' '));
            }
            else
            {
                logger.LogWarning("'{0}' is not recognized as an internal command", header);
            }
        }
    }
}
