using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyModels.Impls
{
    public class NavigationParamter : INavigationParamter
    {

        private Dictionary<string,object> _params=null;

        public void Add(string key, object value)
        {
            foreach (var item in _params.Keys)
            {
                if (item == key)
                    throw new ArgumentException($"key值 {key}已经存在！但是{key}不能重复!");
                
            }
            _params[key] = value;
        }

        public object Get(string key)
        {
            
            if( _params.TryGetValue(key, out object value))
            {
                return value;
            }
            throw new NullReferenceException($"{key}值找不到对应的value");

        }

        public T Get<T>(string key)
        {
            if (_params.TryGetValue(key, out object value))
            {
                if (value is T x)
                {
                    return x;
                }
                else
                {
                    throw new Exception($"参数{key}的value 无法转换为{typeof(T)}");
                }
            }
            throw new NullReferenceException($"{key}值找不到对应的value");
        }
    }
}
