
using CommunityToolkit.Mvvm.Input;
using FantasyMvvm;
using FantasyMvvm.FantasyNavigation;
using FantasyMvvm.FantasyRegionManager;

namespace DemoPreview13.PageModels
{
    public partial class LoginPageModel:FantasyPageModelBase
    {

        private INavigationService _regionManager = null;

        public LoginPageModel(INavigationService regionManager)
        {
            this._regionManager = regionManager;
        }


        [ICommand]
        public void Login()
        {
            this._regionManager.NavigationToAsync("HomePage",false);
        }


       
    }
}
