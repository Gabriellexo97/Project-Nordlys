using Microsoft.Extensions.DependencyInjection;

namespace Nordlys.DependencyInjection
{
    public interface IService
    {
        void Register(IServiceCollection serviceDescriptors);
    }
}
