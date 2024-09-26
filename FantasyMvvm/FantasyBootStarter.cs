using FantasyMvvm.FantasyLocator;

namespace FantasyMvvm
{
    public abstract class FantasyBootStarter : Microsoft.Maui.Controls.Application
    {

        protected abstract string CreateShell();
        private PageModelLocatorBase pageModelLocator = null;

        /// <summary>
        /// 自定义控件处理
        /// </summary>
        protected virtual void ControlHandler()
        {

        }

        private void createMainPage()
        {
            //this.On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>().SetImageDirectory("Assets");

            ControlHandler(); ;
            pageModelLocator = FantasyContainer.GetRequiredService<PageModelLocatorBase>();

            string pageName = CreateShell();
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException($"pageName 不能为空");
            }


            PageModelElement pm = pageModelLocator.GetPageModelElementByName(pageName);


            if (pm == null)
            {
                throw new NullReferenceException($"{pageName}的视图实例为空！请检查是否注册！");
            }
            if (pm.Page is Microsoft.Maui.Controls.Page page)
            {

                MainPage = new NavigationPage(page);

                page.BindingContext = pm.PageModel;
                //if (pm.PageModel is INavigationAware navigationAware)
                //{

                //    page.NavigatedFrom += (s, e) =>
                //    {
                //        navigationAware.OnNavigatedFrom(Microsoft.Maui.Controls.Application.Current.MainPage.Title, null);
                //    };

                //    page.NavigatedTo += (s, e) =>
                //    {
                //        navigationAware.OnNavigatedTo(Microsoft.Maui.Controls.Application.Current.MainPage.Title, null);
                //    };
                //}


            }

        }

        public FantasyBootStarter()
        {
            createMainPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            if (MainPage == null)
            {
                createMainPage();
            }
            return base.CreateWindow(activationState);
        }
    }
}
