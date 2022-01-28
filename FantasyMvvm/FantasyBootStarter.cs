using FantasyMvvm.FantasyLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    public abstract class FantasyBootStarter : Application
    {

        protected abstract string CreateShell();
        private PageModelLocatorBase pageModelLocator = null;


        public FantasyBootStarter()
        {
            this.pageModelLocator = FantasyContainer.GetRequiredService<PageModelLocatorBase>();

            string pageName = this.CreateShell();
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException($"pageName 不能为空");
            }


            var pm = this.pageModelLocator.GetPageModelElementByName(pageName);


            if (pm == null)
            {
                throw new NullReferenceException($"{pageName}的视图实例为空！请检查是否注册！");
            }
            if (pm.Page is Page page)
            {

                this.MainPage = new NavigationPage(page);
             
                page.BindingContext = pm.PageModel;
                if (pm.PageModel is INavigationAware navigationAware)
                {

                    page.NavigatedFrom += (s, e) =>
                    {
                        navigationAware.OnNavigatedFrom(Application.Current.MainPage.Title, null);
                    };

                    page.NavigatedTo += (s, e) =>
                    {
                        navigationAware.OnNavigatedTo(Application.Current.MainPage.Title, null);
                    };
                }


            }

        }
    }
}
