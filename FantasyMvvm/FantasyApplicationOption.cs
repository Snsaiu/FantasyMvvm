using FantasyMvvm.FantasyNavigation.Impl;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegister;

namespace FantasyMvvm
{
    public class FantasyApplicationOption
    {
        private readonly MauiAppBuilder mauiAppBuilder;

        public FantasyApplicationOption(MauiAppBuilder mauiAppBuilder)
        {
            this.mauiAppBuilder = mauiAppBuilder;

        }
        public void AddPageRegister(IPageRegister pageRegister)
        {
            if (checkRegister<IPageRegister>())
            {
                mauiAppBuilder.Services.AddSingleton<IPageRegister>();
            }
            else
            {
                throw new Exception($"IPageRegister 类型已经注册！");
            }
        }

        public void AddNavigation(FantasyNavigation.INavigationService navigationService)
        {
            if (checkRegister<FantasyNavigation.INavigationService>())
            {
                mauiAppBuilder.Services.AddSingleton<FantasyNavigation.INavigationService, DefaultNavigationService>();
            }
            else
            {
                throw new Exception($"INavigationService 类型已经注册！");
            }
        }


        public void AddKeepContainer(IPageKeepContainer container)
        {

            if (checkRegister<IPageKeepContainer>())
            {

                mauiAppBuilder.Services.AddSingleton<IPageKeepContainer>(container);
            }
            else
            {
                throw new Exception("PageKeeperContainer 类型已经注册");
            }

        }




        /// <summary>
        /// 检查该类型是否已经被注册
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <returns>如果已经注册返回false，否则返回true</returns>
        private bool checkRegister<T>()
        {
            ServiceProvider provider = mauiAppBuilder.Services.BuildServiceProvider();
            T obj = provider.GetRequiredService<T>();
            return obj == null;
        }


    }
}
