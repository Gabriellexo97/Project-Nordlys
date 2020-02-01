using System.Threading.Tasks;

namespace Nordlys.Core.Console.Commands
{
    class ClearCommand : ICommand
    {
        public string Command => "clear";
        
        public Task RunAsync(params object[] args)
        {
            return Task.Run(System.Console.Clear);
        }
    }
}
