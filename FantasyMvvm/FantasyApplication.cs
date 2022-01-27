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

    public static class FantasyApplication
    {
        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IPageRegist>(new DefaultPageRegist(builder.Services));
            builder.Services.AddTransient<PageModelLocatorBase, DefaultPageModelLocator>();
            builder.Services.AddSingleton<IPageKeepContainer>(new DefaultPageKeepContainer());
            builder.Services.AddTransient<FantasyNavigation.INavigationService, DefaultNavigationService>();
            return builder;
        }

        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder,Action<FantasyApplicationOption> option)
        {
            option(new FantasyApplicationOption(builder));

            return builder;
        }


    }
}
