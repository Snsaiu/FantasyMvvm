namespace FantasyMvvm.FantasyPageRegist.Impl;

using FantasyMvvm.FantasyModels;

public class DefaultPageRegist:IPageRegist
{
    private readonly IServiceCollection serviceCollection;

    private  Dictionary<string, PageModel> instance;

    public DefaultPageRegist(IServiceCollection serviceCollection)
    {
        this.serviceCollection = serviceCollection;
        this.instance=new Dictionary<string, PageModel>();
    }
    public void Regist<P, PM>(string name)
    {
        if (instance.ContainsKey(name))
        {
            throw new Exception($"{name}重复!");
        }
        var pm = new PageModel();
        pm.Page = typeof(P);
        pm.PM = typeof(PM);
        instance[name] = pm;

        this.serviceCollection.AddTransient(typeof(P));
        this.serviceCollection.AddTransient(typeof(PM));
    }

    public PageModel GetPageModelByName(string name)
    {
        return this.instance.GetValueOrDefault(name);
    }
}