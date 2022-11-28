using CommunityToolkit.Maui;
using DemoPreview13.PageModels;
using DemoPreview13.Pages;
using FantasyMvvm;

namespace DemoPreview13
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                }).UseMauiCommunityToolkit();
            builder.UseFantasyApplication().UseGetProvider();

            builder.UseRegisterPage<LoginPage, LoginPageModel>();
            builder.UseRegisterPage<HomePage, HomePageModel>("HomePage");
            builder.UseRegisterDialog<SummaryDialog, SummaryDialogModel>("SummaryDialog");

            return builder.Build();
        }
    }
}