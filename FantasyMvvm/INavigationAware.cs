namespace FantasyMvvm;

using FantasyMvvm.FantasyModels;

public interface INavigationAware
{
    
    public void OnNavigatedTo(string source, INavigationParamter paramter);

    public void OnNavigatedFrom(string source,INavigationParamter paramter);

}