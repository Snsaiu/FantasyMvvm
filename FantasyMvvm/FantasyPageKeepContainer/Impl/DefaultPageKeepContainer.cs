using FantasyMvvm.FantasyLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyPageKeepContainer.Impl
{
    public class DefaultPageKeepContainer : IPageKeepContainer
    {

        private Dictionary<string, PageModelElement> _dic;
        public DefaultPageKeepContainer()
        {
            this._dic = new Dictionary<string, PageModelElement>();
        }


        public void AddPage(string key, PageModelElement element)
        {
            
            if (this._dic.ContainsKey(key))
            {
                throw new Exception($"{key}已经存在！");
            }
            this._dic[key] = element;

        }

        public bool Exist(string key)
        {
            return this._dic.ContainsKey(key);
        }

        public PageModelElement GetPage(string key)
        {
               return this._dic.GetValueOrDefault(key);
        }

        public void RemovePageByKey(string key)
        {
           this._dic.Remove(key);
        }
    }
}
