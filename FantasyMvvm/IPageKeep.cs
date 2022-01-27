using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    /// <summary>
    /// 是否保持页面保持
    /// </summary>`
    public interface IPageKeep 
    {
        /// <summary>
        /// true保持页面，false 不保持页面
        /// </summary>
        public bool Keep { get; set; }
    }
}
