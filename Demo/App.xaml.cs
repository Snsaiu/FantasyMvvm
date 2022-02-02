using FantasyMvvm;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
namespace Demo
{
    public partial class App : FantasyBootStarter
    {
    

        protected override string CreateShell()
        {
            return "MainPage";

        
        }
    }
}