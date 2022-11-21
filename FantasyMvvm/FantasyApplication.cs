using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FantasyMvvm
{
    using FantasyMvvm.FantasyLocator;
    using FantasyMvvm.FantasyLocator.Impl;
    using FantasyMvvm.FantasyNavigation.Impl;
    using FantasyMvvm.FantasyPageKeepContainer;
    using FantasyMvvm.FantasyPageKeepContainer.Impl;
    using FantasyMvvm.FantasyPageRegist;
    using FantasyMvvm.FantasyPageRegist.Impl;
    using FantasyMvvm.FantasyRegionManager;
    using FantasyMvvm.FantasyRegionManager.Impl;
    using FantasyMvvm.FantasyViewRegist;
    using FantasyMvvm.FantasyViewRegist.Impl;

    public static class FantasyApplication
    {
        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder)
        {
           builder.Services.AddSingleton<FantasyRegionLocator.RegionLocatorBase>(new FantasyRegionLocator.Impl.DefaultRegionLocator());
            builder.Services.AddSingleton<IPageRegist>(new DefaultPageRegist(builder.Services));
            builder.Services.AddSingleton<IViewRegist>(new DefaultViewRegist(builder.Services));
            
            builder.Services.AddTransient<PageModelLocatorBase, DefaultPageModelLocator>();
            builder.Services.AddTransient<ViewModelLocatorBase, DefaultViewModelLocator>();


            builder.Services.AddTransient<IRegionManager, DefaultRegionManager>();

            builder.Services.AddSingleton<IPageKeepContainer>(new DefaultPageKeepContainer());
            builder.Services.AddTransient<FantasyNavigation.INavigationService, DefaultNavigationService>();

            return builder;
        }

        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder,Action<FantasyApplicationOption> option)
        {
            FantasyApplicationOption _option = new FantasyApplicationOption(builder);

            option?.Invoke(_option);

            return builder;
        }


    }
}
