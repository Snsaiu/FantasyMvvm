namespace FantasyMvvm.FantasyPageRegister;

using FantasyMvvm.FantasyModels;

/// <summary>
/// 注册页面接口，应该为单例模式
/// </summary>
public interface IPageRegister
{
     void Register<P, PM>(string name);

    void Register<P>(string name);

    PageModel GetPageModelByName(string name);


}