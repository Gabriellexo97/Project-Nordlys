using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace Nordlys.DependencyInjection
{
    public class DependencyRegistrar
    {
        private readonly IServiceCollection serviceDescriptors;

        public ServiceProvider ServiceProvider 
        {
            get;
            private set;
        }

        public DependencyRegistrar()
        {
            serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug));
        }

        public void RegisterSingleton<TService>() where TService : class
        {
            serviceDescriptors.AddSingleton<TService>();
        }

        public void RegisterTransient<TService>() where TService : class
        {
            serviceDescriptors.AddTransient<TService>();
        }

        public void RegisterSingleton<TService, TImplementation>() 
            where TService : class
            where TImplementation : class, TService
        {
            serviceDescriptors.AddSingleton<TService, TImplementation>();
        }

        public void RegisterService<TService>()
            where TService : IService
        {
            (typeof(TService).GetConstructor(Type.EmptyTypes).Invoke(null) as IService).Register(this);
        }

        public void RegisterTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            serviceDescriptors.AddTransient<TService, TImplementation>();
        }

        //private void AddClasses()
        //{
        //    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        //    {
        //        if (type.GetCustomAttributes(typeof(SingletonAttribute), true).Length > 0)
        //        {
        //            serviceDescriptors.AddSingleton(type);
        //        }
        //        else if (type.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
        //        {
        //            serviceDescriptors.AddTransient(type);
        //        }
        //    }
        //}

        public T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public void BuildServiceProvider()
        {
            ServiceProvider = serviceDescriptors.BuildServiceProvider();
        }
    }
}
