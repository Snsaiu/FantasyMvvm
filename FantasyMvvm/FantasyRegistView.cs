using FantasyMvvm.FantasyViewRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    public static class FantasyRegisterView
    {
        public static MauiAppBuilder UseRegisterView<V, VM>(this MauiAppBuilder builder, string name)where V :View where VM :FantasyViewModelBase
        {

            var register = builder.Services.BuildServiceProvider().GetRequiredService<IViewRegister>();
            register.Register<V, VM>(name);

            return builder;
        }

        public static MauiAppBuilder UseRegisterView<V>(this MauiAppBuilder builder, string name) where V : View
        {

            var register = builder.Services.BuildServiceProvider().GetRequiredService<IViewRegister>();
            register.Register<V>(name);

            return builder;
        }
    }
}
