namespace FantasyMvvm;

using FantasyMvvm.FantasyModels;

public interface INavigationAware
{
    
    public void OnNavigatedTo(string source, INavigationParameter parameter);

    public void OnNavigatedFrom(string source,INavigationParameter parameter);

}