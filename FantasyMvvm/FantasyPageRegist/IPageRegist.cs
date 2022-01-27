namespace FantasyMvvm.FantasyPageRegist;

using FantasyMvvm.FantasyModels;

/// <summary>
/// 注册页面接口，应该为单例模式
/// </summary>
public interface IPageRegist
{
     void Regist<P, PM>(string name);

     PageModel GetPageModelByName(string name);


}