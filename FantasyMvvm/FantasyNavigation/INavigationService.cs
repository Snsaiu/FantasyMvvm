using FantasyMvvm.FantasyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyNavigation
{
    /// <summary>
    /// 页面导航
    /// </summary>
    public interface  INavigationService
    {
        Task NavigationToAsync(string pageName, bool hasBackButton = true, INavigationParameter parameter = null);

        Task NavigationToAsync(string pageName, INavigationParameter parameter = null);
    }
}
