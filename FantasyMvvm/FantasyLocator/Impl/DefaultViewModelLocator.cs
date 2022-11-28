namespace FantasyMvvm.FantasyLocator.Impl;

using FantasyMvvm.FantasyModels;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegister;
using FantasyMvvm.FantasyViewRegister;

public class DefaultViewModelLocator: ViewModelLocatorBase
{
    private readonly IServiceProvider provider;


    protected override ViewModelElement Parse(ViewModel viewModel)
    {
        try
        {
            var viewType = this.provider.GetRequiredService(viewModel.View);

            if(viewModel.VM!=null)
            {
                var viewModelType = this.provider.GetRequiredService(viewModel.VM);

                ViewModelElement element = new ViewModelElement() { View = viewType, ViewModel = viewModelType };
                return element;

            }
            else
            {
              
                ViewModelElement element = new ViewModelElement() { View = viewType};
                return element;
            }


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public DefaultViewModelLocator(IViewRegister viewRegister,IServiceProvider provider)
        : base(viewRegister)
    {
        this.provider = provider;
    }
}