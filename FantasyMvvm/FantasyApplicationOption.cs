using FantasyMvvm.FantasyNavigation.Impl;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    public class FantasyApplicationOption
    {
        private readonly MauiAppBuilder mauiAppBuilder;

        public FantasyApplicationOption(MauiAppBuilder mauiAppBuilder)
        {
            this.mauiAppBuilder = mauiAppBuilder;

        }
      public  void AddPageRegister(IPageRegister pageRegister)
        {
            if (this.checkRegister<IPageRegister>())
            {
                this.mauiAppBuilder.Services.AddSingleton<IPageRegister>();
            }
            else
            {
                throw new Exception($"IPageRegister 类型已经注册！");
            }
        }

        public void AddNavigation(FantasyNavigation.INavigationService navigationService)
        {
            if (this.checkRegister<FantasyNavigation.INavigationService>())
            {
                this.mauiAppBuilder.Services.AddTransient<FantasyNavigation.INavigationService,DefaultNavigationService>();
            }
            else
            {
                throw new Exception($"INavigationService 类型已经注册！");
            }
        }


        public void AddKeepContainer(IPageKeepContainer container)
        {

            if (this.checkRegister<IPageKeepContainer> ())
            {

                this.mauiAppBuilder.Services.AddSingleton<IPageKeepContainer>(container);
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
           var provider=  this.mauiAppBuilder.Services.BuildServiceProvider();
           var obj=  provider.GetRequiredService<T>();
            if (obj==null)
            {
                return true;
            }
            return false;
        }
       

    }
}
