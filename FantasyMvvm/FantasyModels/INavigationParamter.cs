using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyModels
{
    public interface INavigationParamter
    {
       void Add(string key, object value);
        object Get(string key);

        T Get<T>(string key);
    }
}
