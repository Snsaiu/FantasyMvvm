using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    public static class FantasyContainer
    {

        private static ServiceProvider _serviceProvider;

        private static IServiceCollection serviceCollection;


        public static MauiAppBuilder UseRegisterServices(this MauiAppBuilder builder, Action<IServiceCollection> action)
        {
            action(builder.Services);
            return builder;
        }

        public static MauiAppBuilder UseGetProvider(this MauiAppBuilder builder)
        {

            serviceCollection = builder.Services;
            _serviceProvider = builder.Services.BuildServiceProvider();
            return builder;
        }

        public static T GetRequiredService<T>()
        {
            
            var service= serviceCollection.BuildServiceProvider().GetRequiredService<T>();
            
            if (service==null)
            {
                throw new NullReferenceException($"未找到{typeof(T)}的实例");
            }
            return service;
        }
        public static object GetRequiredService(Type type)
        {
            var service = _serviceProvider.GetRequiredService(type);
            if (service == null)
            {
                throw new NullReferenceException($"未找到{type}的实例");
              
            }
            return service;
        }


    }
}
