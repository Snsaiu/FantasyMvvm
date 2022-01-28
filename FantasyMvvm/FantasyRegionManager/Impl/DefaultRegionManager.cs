using FantasyMvvm.FantasyLocator;
using FantasyMvvm.FantasyRegionLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyRegionManager.Impl
{
    public class DefaultRegionManager : IRegionManager
    {
        private readonly ViewModelLocatorBase viewModelLocatorBase;

        public DefaultRegionManager(ViewModelLocatorBase viewModelLocatorBase, RegionLocatorBase regionLocator)
        {
            this.viewModelLocatorBase = viewModelLocatorBase;
            RegionLocator = regionLocator;
        }

        public RegionLocatorBase RegionLocator { get; }

        public void SetRegionView(string regionName, string viewName)
        {
            if (string.IsNullOrWhiteSpace(regionName))
            {
                throw new ArgumentNullException($"regionName 不能为空");
            }

            if (string.IsNullOrWhiteSpace(viewName))
            {
                throw new ArgumentNullException($"viewName 不能为空");
            }

            //获得注册region

            var region=this.RegionLocator.GetContentViewByKey(regionName);
            if (region == null)
            {
                throw new NullReferenceException($"{region}为空！请检查是否注册！");
            }


            // 获得视图
            var vm = this.viewModelLocatorBase.GetViewModelElementByName(viewName);

            if (vm == null)
            {
                throw new NullReferenceException($"{viewName}的视图实例为空！请检查是否注册！");
            }
            var view = vm.View as ContentView;
            view.BindingContext = vm.ViewModel;
            region.Content = view;

        }
    }
}
