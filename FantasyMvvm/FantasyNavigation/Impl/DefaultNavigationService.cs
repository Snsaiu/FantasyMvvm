using FantasyMvvm.FantasyLocator;
using FantasyMvvm.FantasyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyNavigation.Impl
{
    public class DefaultNavigationService : INavigationService
    {
        private PageModelLocatorBase pageModelLocator = null;

        public DefaultNavigationService(PageModelLocatorBase pageModelLocatorBase)
        {
            this.pageModelLocator = pageModelLocatorBase;
        }

        public async Task NavigationToAsync(string pageName, bool hasBackButton = true, INavigationParamter paramter = null)
        {

            PageModelElement pm = getPageModelElementByName(pageName);

            setPageAndPageModelEvent(paramter, pm);
            var page = (pm.Page as Page);

            if (hasBackButton)
            {
                await (Application.Current.MainPage as NavigationPage).PushAsync(page, true);

            }
            else
            {


              await  Application.Current.MainPage.Navigation.PushAsync(page);
                var pages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
                foreach (var pg in pages)
                {
                    if (page.GetType() != pg.GetType())
                    {
                        Application.Current.MainPage.Navigation.RemovePage(pg);

                    }
                }





            }



        }



        public async Task NavigationToAsync(string pageName, INavigationParamter paramter = null)
        {
            PageModelElement pm = getPageModelElementByName(pageName);

            setPageAndPageModelEvent(paramter, pm);
            var page = (pm.Page as Page);
            await (Application.Current.MainPage as NavigationPage).PushAsync(page, true);
        }


        private void setPageAndPageModelEvent(INavigationParamter paramter, PageModelElement pm)
        {
            if (pm.Page is Page page)
            {
                page.BindingContext = pm.PageModel;
                if (pm.PageModel is INavigationAware navigationAware)
                {

                    page.NavigatedFrom += (s, e) =>
                    {
                        navigationAware.OnNavigatedFrom(Application.Current.MainPage.Title, paramter);
                    };

                    page.NavigatedTo += (s, e) =>
                    {
                        navigationAware.OnNavigatedTo(Application.Current.MainPage.Title, paramter);
                    };
                }



            }

            else
            {
                throw new NullReferenceException($"{pm.Page}不是ContentPage类型");
            }
        }

        private PageModelElement getPageModelElementByName(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException($"pageName 不能为空");
            }

            var pm = this.pageModelLocator.GetPageModelElementByName(pageName);

            if (pm == null)
            {
                throw new NullReferenceException($"{pageName}的视图实例为空！请检查是否注册！");
            }

            return pm;
        }

    }
}
