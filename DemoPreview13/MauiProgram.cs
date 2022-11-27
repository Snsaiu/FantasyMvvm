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

            builder.UseRegistPage<LoginPage, LoginPageModel>("LoginPage");
            builder.UseRegistPage<HomePage, HomePageModel>("HomePage");
            builder.UseRegistDialog<SummaryDialog, SummaryDialogModel>("SummaryDialog");

            return builder.Build();
        }
    }
}