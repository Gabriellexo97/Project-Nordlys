using System.Threading.Tasks;

namespace Nordlys.Core.Console
{
    public interface ICommand
    {
        Task RunAsync(params object[] args);
    }
}
