using System.Threading.Tasks;

namespace Nordlys.Core.Console.Commands
{
    class ClearCommand : ICommand
    {
        public string Command => "clear";
        
        public Task RunAsync(params object[] args)
        {
            System.Console.Clear();
            return Task.CompletedTask;
        }
    }
}
