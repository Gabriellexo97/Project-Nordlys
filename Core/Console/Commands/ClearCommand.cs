using System.Threading.Tasks;

namespace Nordlys.Core.Console.Commands
{
    class ClearCommand : ICommand
    {
        public async Task RunAsync(params object[] args)
        {
            System.Console.Clear();
        }
    }
}
