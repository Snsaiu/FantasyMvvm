using FantasyMvvm.FantasyLocator;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyNavigation.Impl
{
    public class DefaultNavigationService : INavigationService
    {
        private readonly PageModelLocatorBase _pageModelLocator;

        public DefaultNavigationService(PageModelLocatorBase pageModelLocatorBase)
        {
            _pageModelLocator = pageModelLocatorBase;
        }

        public async Task NavigationToAsync(string pageName, bool hasBackButton = true, INavigationParameter parameter = null)
        {

            PageModelElement pm = getPageModelElementByName(pageName);

            SetPageAndPageModelEvent(parameter, pm);
            Page page = (pm.Page as Page);
            NavigationPage.SetHasBackButton(page, hasBackButton);
            if (hasBackButton)
            {
                await (Application.Current.MainPage as NavigationPage).PushAsync(page, true);
            }
            else
            {

                page.Parent = null;
                Application.Current.MainPage = new NavigationPage(page);

                List<Page> pages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
                foreach (Page pg in pages)
                {
                    if (page.GetType() != pg.GetType())
                    {
                        Application.Current.MainPage.Navigation.RemovePage(pg);

                    }
                }
            }
        }



        public async Task NavigationToAsync(string pageName, INavigationParameter parameter = null)
        {
            PageModelElement pm = getPageModelElementByName(pageName);

            SetPageAndPageModelEvent(parameter, pm);
            Page page = (pm.Page as Page);

            await (Application.Current.MainPage as NavigationPage).PushAsync(page, true);
        }




        private void SetPageAndPageModelEvent(INavigationParameter parameter, PageModelElement pm)
        {
            if (pm.Page is Page page)
            {
                if (page.BindingContext is not null)
                    return;

                page.BindingContext = pm.PageModel;
                if (pm.PageModel is INavigationAware navigationAware)
                {
                    page.NavigatedTo += (s, e) =>
                    {
                        string source = s?.GetType().Name ?? string.Empty;
                        navigationAware.OnNavigatedTo(source, parameter);
                    };

                    page.NavigatedFrom += (s, e) =>
                    {
                        string source = s?.GetType().Name ?? string.Empty;
                        navigationAware.OnNavigatedFrom(source, parameter);
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

            PageModelElement pm = _pageModelLocator.GetPageModelElementByName(pageName);

            return pm ?? throw new NullReferenceException($"{pageName}的视图实例为空！请检查是否注册！");
        }

    }
}
