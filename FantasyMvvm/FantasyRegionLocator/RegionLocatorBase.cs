using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyRegionLocator
{
    public abstract class RegionLocatorBase
    {
        public abstract ContentView GetContentViewByKey(string key);

        public abstract void Add(string key, ContentView contentView);

        public abstract void RemoveByKey(string key);



    }
}
