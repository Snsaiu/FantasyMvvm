﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FantasyMvvm
{
    using FantasyMvvm.FantasyDialogService;
    using FantasyMvvm.FantasyDialogService.Impl;
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
    using CommunityToolkit.Maui;
    using FantasyMvvm.FantasyDialogRegist;
    using FantasyMvvm.FantasyDialogRegist.Impl;

    public static class FantasyApplication
    {
        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder)
        {
            //builder.UseMauiCommunityToolkit();

           builder.Services.AddSingleton<FantasyRegionLocator.RegionLocatorBase>(new FantasyRegionLocator.Impl.DefaultRegionLocator());
            builder.Services.AddSingleton<IPageRegist>(new DefaultPageRegist(builder.Services));
            builder.Services.AddSingleton<IViewRegist>(new DefaultViewRegist(builder.Services));
            builder.Services.AddSingleton<IDialogRegist>(new DefaultDialogRegist(builder.Services));

            builder.Services.AddTransient<PageModelLocatorBase, DefaultPageModelLocator>();
            builder.Services.AddTransient<ViewModelLocatorBase, DefaultViewModelLocator>();
            builder.Services.AddTransient<DialogModelLocatorBase, DefaultDialogModelLocator>();


            builder.Services.AddTransient<IRegionManager, DefaultRegionManager>();

            builder.Services.AddSingleton<IPageKeepContainer>(new DefaultPageKeepContainer());
            builder.Services.AddTransient<FantasyNavigation.INavigationService, DefaultNavigationService>();
            builder.Services.AddTransient<IDialogService, DefaultDialogService>();



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
