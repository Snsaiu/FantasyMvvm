namespace FantasyMvvm.FantasyPageRegister.Impl;

using FantasyMvvm.FantasyModels;

public class DefaultPageRegister:IPageRegister
{
    private readonly IServiceCollection serviceCollection;

    private  Dictionary<string, PageModel> instance;

    public DefaultPageRegister(IServiceCollection serviceCollection)
    {
        this.serviceCollection = serviceCollection;
        this.instance=new Dictionary<string, PageModel>();
    }
    public void Register<P, PM>(string name)
    {

        if(string.IsNullOrEmpty(name))
        {
            name = typeof(P).Name;
        }

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

    public void Register<P>(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(P).Name;
        }

        if (instance.ContainsKey(name))
        {
            throw new Exception($"{name}重复!");
        }
        var pm = new PageModel();
        pm.Page = typeof(P);

        instance[name] = pm;

        this.serviceCollection.AddTransient(typeof(P));
    }
}