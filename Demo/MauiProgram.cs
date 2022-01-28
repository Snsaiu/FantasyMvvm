using Demo.PageModels;
using Demo.Pages;
using Demo.ViewModels;
using Demo.Views;
using FantasyMvvm;

namespace Demo
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
            builder.UseRegistPage<MainPage,MainPageModel>("MainPage");
            builder.UseRegistPage<SecondPage, SecondPageModel>("SecondPage");
            builder.UseRegistView<TitleView, TitleViewModel>("TitleView");


            return builder.Build();
        }
    }
}