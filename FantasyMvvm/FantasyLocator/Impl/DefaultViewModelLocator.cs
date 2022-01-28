namespace FantasyMvvm.FantasyLocator.Impl;

using FantasyMvvm.FantasyModels;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegist;
using FantasyMvvm.FantasyViewRegist;

public class DefaultViewModelLocator: ViewModelLocatorBase
{
    private readonly IServiceProvider provider;


    protected override ViewModelElement Parse(ViewModel viewModel)
    {
        try
        {
            var viewType = this.provider.GetRequiredService(viewModel.View);
            var viewModelType = this.provider.GetRequiredService(viewModel.VM);

            ViewModelElement element = new ViewModelElement() { View = viewType, ViewModel = viewModelType };
            return element;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public DefaultViewModelLocator(IViewRegist viewRegist,IServiceProvider provider)
        : base(viewRegist)
    {
        this.provider = provider;
    }
}