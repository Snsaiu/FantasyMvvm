using FantasyMvvm;
using FantasyMvvm.FantasyNavigation;
using FantasyMvvm.FantasyRegionManager;
using Microsoft.Toolkit.Mvvm.Input;

namespace Demo.PageModels;

public class MainPageModel:FantasyPageModelBase
{
    private readonly IRegionManager regionManager;
    private readonly INavigationService navigationService;

    public MainPageModel(IRegionManager regionManager,INavigationService navigationService)
    {
        this.regionManager = regionManager;
        this.navigationService = navigationService;
        //this.regionManager.SetRegionView("hello", "TitleView");
        //this.regionManager.SetRegionView("hello1", "TitleView");
        //this.regionManager.SetRegionView("hello2", "TitleView");
    }

    private RelayCommand nextCommand;
    public RelayCommand NextCommand =>
        nextCommand ?? (nextCommand = new RelayCommand(ExecuteNextCommand));

    void ExecuteNextCommand()
    {
        this.navigationService.NavigationToAsync("SecondPage",true,null);
    }
}