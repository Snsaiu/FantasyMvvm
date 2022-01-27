namespace FantasyMvvm.FantasyLocator.Impl;

using FantasyMvvm.FantasyModels;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegist;

public class DefaultPageModelLocator: PageModelLocatorBase
{
    private readonly IServiceProvider provider;


    protected override PageModelElement Parse(PageModel pageModel)
    {
        try
        {
            var pageType = this.provider.GetRequiredService(pageModel.Page);
            var pageModelType = this.provider.GetRequiredService(pageModel.PM);

            PageModelElement element = new PageModelElement() { Page = pageType, PageModel = pageModelType };
            return element;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public DefaultPageModelLocator(IPageRegist pageRegist,IServiceProvider provider,IPageKeepContainer pageKeepContainer)
        : base(pageRegist,pageKeepContainer)
    {
        this.provider = provider;
    }
}