using Nordlys.Game.Sessions;
using System.Threading.Tasks;

namespace Nordlys.Communication.Messages
{
    public interface IMessageEvent
    {
        short Header { get; }
        Task RunAsync(Session session, ClientMessage message);
    }
}
