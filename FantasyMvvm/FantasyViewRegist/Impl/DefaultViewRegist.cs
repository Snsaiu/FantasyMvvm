using FantasyMvvm.FantasyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyViewRegist.Impl
{
    public class DefaultViewRegist : IViewRegist
    {
        private readonly IServiceCollection serviceCollection;

        private Dictionary<string, ViewModel> instance;

        public DefaultViewRegist(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
            this.instance = new Dictionary<string, ViewModel>();
        }

        public ViewModel GetViewModelByName(string name)
        {
            return this.instance.GetValueOrDefault(name);
        }

        public void Regist<V, VM>(string name)
        {
            if (instance.ContainsKey(name))
            {
                throw new Exception($"{name}重复!");
            }
            var pm = new ViewModel();
            pm.View = typeof(V);
            pm.VM = typeof(VM);
            instance[name] = pm;

            this.serviceCollection.AddTransient(typeof(V));
            this.serviceCollection.AddTransient(typeof(VM));
        }
    }
}
