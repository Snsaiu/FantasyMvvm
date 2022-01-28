using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyRegionLocator.Impl
{
    public class DefaultRegionLocator : RegionLocatorBase
    {
        private Dictionary<string, ContentView> _regions;

        public DefaultRegionLocator()
        {
            this._regions= new Dictionary<string, ContentView>();
        }

        public override void Add(string key, ContentView contentView)
        {

            if (this._regions.ContainsKey(key))
            {
                return;
            }
            this._regions[key] = contentView;

        }

        public override ContentView GetContentViewByKey(string key)
        {
          return this._regions[key];
        }

        public override void RemoveByKey(string key)
        {

                this._regions.Remove(key);
        }
    }
}
