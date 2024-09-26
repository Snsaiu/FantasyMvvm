namespace FantasyMvvm
{
    using CommunityToolkit.Maui;

    using FantasyMvvm.FantasyDialogRegister;
    using FantasyMvvm.FantasyDialogRegister.Impl;
    using FantasyMvvm.FantasyDialogService;
    using FantasyMvvm.FantasyDialogService.Impl;
    using FantasyMvvm.FantasyLocator;
    using FantasyMvvm.FantasyLocator.Impl;
    using FantasyMvvm.FantasyNavigation.Impl;
    using FantasyMvvm.FantasyPageKeepContainer;
    using FantasyMvvm.FantasyPageKeepContainer.Impl;
    using FantasyMvvm.FantasyPageRegister;
    using FantasyMvvm.FantasyPageRegister.Impl;
    using FantasyMvvm.FantasyRegionManager;
    using FantasyMvvm.FantasyRegionManager.Impl;
    using FantasyMvvm.FantasyViewRegister;
    using FantasyMvvm.FantasyViewRegister.Impl;

    public static class FantasyApplication
    {
        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder)
        {
            //builder.UseMauiCommunityToolkit();

            builder.Services.AddSingleton<FantasyRegionLocator.RegionLocatorBase>(new FantasyRegionLocator.Impl.DefaultRegionLocator());
            builder.Services.AddSingleton<IPageRegister>(new DefaultPageRegister(builder.Services));
            builder.Services.AddSingleton<IViewRegister>(new DefaultViewRegister(builder.Services));
            builder.Services.AddSingleton<IDialogRegister>(new DefaultDialogRegister(builder.Services));

            builder.Services.AddSingleton<PageModelLocatorBase, DefaultPageModelLocator>();
            builder.Services.AddSingleton<ViewModelLocatorBase, DefaultViewModelLocator>();
            builder.Services.AddSingleton<DialogModelLocatorBase, DefaultDialogModelLocator>();


            builder.Services.AddSingleton<IRegionManager, DefaultRegionManager>();

            builder.Services.AddSingleton<IPageKeepContainer>(new DefaultPageKeepContainer());
            builder.Services.AddSingleton<FantasyNavigation.INavigationService, DefaultNavigationService>();
            builder.Services.AddSingleton<IDialogService, DefaultDialogService>();



            return builder;
        }

        public static MauiAppBuilder UseFantasyApplication(this MauiAppBuilder builder, Action<FantasyApplicationOption> option)
        {
            FantasyApplicationOption _option = new FantasyApplicationOption(builder);

            option?.Invoke(_option);

            return builder;
        }


    }
}
