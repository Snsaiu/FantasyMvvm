namespace FantasyMvvm.FantasyLocator;

using FantasyMvvm.FantasyModels;
using FantasyMvvm.FantasyPageKeepContainer;
using FantasyMvvm.FantasyPageRegister;

public abstract class PageModelLocatorBase
{
    private readonly IPageRegister pageRegister;
    private readonly IPageKeepContainer pageKeepContainer;

    public PageModelLocatorBase(IPageRegister pageRegister,IPageKeepContainer pageKeepContainer)
    {
        this.pageRegister = pageRegister;
        this.pageKeepContainer = pageKeepContainer;
    }


    public PageModelElement GetPageModelElementByName(string name)
    {

        if (this.pageKeepContainer.Exist(name))
        {
         var p=   this.pageKeepContainer.GetPage(name);
            if (p==null)
            {
                throw new NullReferenceException($"{name}存在，但是找不到视图");
            }
            if (p.PageModel is IPageKeep pageKeep)
            {

                if (pageKeep.Keep)
                {
                    return p;
                }
                else
                {
                   
                    var pg = this.pageRegister.GetPageModelByName(name);
                    if (pg!= null)
                    {

                        PageModelElement element = this.Parse(pg);

                        return element;
                    }

                    throw new NullReferenceException($"{name}未发现可注册的视图，请检查是否已经注册!");
                }
            }
            else
            {
                throw new Exception($"{name}确实已经保持，但是它没有实现IPageKeep接口！");
            }
        }
        else
        {
            var p = this.pageRegister.GetPageModelByName(name);
            if (p != null)
            {
                PageModelElement element = this.Parse(p);
                if (element.PageModel is IPageKeep pagekeep)
                {
                    this.pageKeepContainer.AddPage(name, element);
                }
                return element;
            }

            throw new NullReferenceException($"{name}未发现可注册的视图，请检查是否已经注册!");
        }

  

    }

    protected abstract PageModelElement Parse(PageModel pageModel);
}