using System.Threading.Tasks;

namespace Nordlys.Core.Console
{
    public interface ICommand
    {
        string Command { get; }
        Task RunAsync(params object[] args);
    }
}
