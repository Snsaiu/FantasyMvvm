using FantasyMvvm.FantasyLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyPageKeepContainer
{
    /// <summary>
    /// 页面保持容器
    /// </summary>
    public interface IPageKeepContainer
    {

        /// <summary>
        /// 添加页面保持的页面方法
        /// </summary>
        /// <param name="key">key，需要保持不重复</param>
        /// <param name="element">添加的value</param>
        void AddPage(string key,PageModelElement element);
        /// <summary>
        /// 通过key获得value
        /// </summary>
        /// <param name="key">查找的key</param>
        /// <returns></returns>
        PageModelElement GetPage(string key);

        /// <summary>
        /// 根据key只移除元素
        /// </summary>
        /// <param name="key">需要被移除的元素</param>
        void RemovePageByKey(string key);

        /// <summary>
        /// 根据key检查是否存在该元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns>存在返回true，否则返回false</returns>
        bool Exist(string key);
    }
}
