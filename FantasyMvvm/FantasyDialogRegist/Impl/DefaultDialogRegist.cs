using System;
using System.Xml.Linq;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogRegist.Impl
{
	public class DefaultDialogRegist:IDialogRegist
    {
        private Dictionary<string, DialogModel> instance;

        private readonly IServiceCollection _serviceCollection;
		public DefaultDialogRegist(IServiceCollection serviceCollection)
        {
            this._serviceCollection = serviceCollection;
            this.instance = new Dictionary<string, DialogModel>();
        }

        public DialogModel GetDialogModelByName(string name)
        {
            return this.instance.GetValueOrDefault(name);
        }

        public void Regist<P, PM>(string name)
        {

            if(string.IsNullOrEmpty(name))
            {
                name = typeof(P).Name;
            }
            
            if (instance.ContainsKey(name))
            {
                throw new Exception($"{name}重复");
            }

            var pm = new DialogModel();
            pm.Popup = typeof(P);
            pm.PM = typeof(PM);
            instance[name] = pm;
            this._serviceCollection.AddTransient(typeof(P));
            this._serviceCollection.AddTransient(typeof(PM));
        }

        public void Regist<P>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(P).Name;
            }

            if (instance.ContainsKey(name))
            {
                throw new Exception($"{name}重复");
            }

            var pm = new DialogModel();
            pm.Popup = typeof(P);
            instance[name] = pm;
            this._serviceCollection.AddTransient(typeof(P));
       
        }
    }
}

