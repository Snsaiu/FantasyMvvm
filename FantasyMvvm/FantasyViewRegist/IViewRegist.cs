using FantasyMvvm.FantasyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyViewRegister
{
    public interface IViewRegister
    {
        void Register<V, VM>(string name);

        void Register<V>(string name);

        ViewModel GetViewModelByName(string name);
    }
}
