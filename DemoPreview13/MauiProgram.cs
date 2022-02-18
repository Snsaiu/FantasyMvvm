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
                });
            builder.UseFantasyApplication().UseGetProvider();

            builder.UseRegistPage<LoginPage, LoginPageModel>("LoginPage");

            return builder.Build();
        }
    }
}