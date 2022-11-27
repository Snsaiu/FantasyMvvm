using FantasyMvvm.FantasyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyViewRegist
{
    public interface IViewRegist
    {
        void Regist<V, VM>(string name);

        void Regist<V>(string name);

        ViewModel GetViewModelByName(string name);
    }
}
