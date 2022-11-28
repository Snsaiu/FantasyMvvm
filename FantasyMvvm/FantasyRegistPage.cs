using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm
{
    using FantasyMvvm.FantasyPageRegister;

    public static class FantasyRegisterPage
    {

        public static MauiAppBuilder UseRegisterPage<P, PM>(this MauiAppBuilder builder,string name=null) where P :Page where PM :FantasyPageModelBase
        {

            var register = builder.Services.BuildServiceProvider().GetRequiredService<IPageRegister>();
            register.Register<P,PM>(name);

            return builder;
        }

        public static MauiAppBuilder UseRegisterPage<P>(this MauiAppBuilder builder, string name = null) where P : Page 
        {

            var register = builder.Services.BuildServiceProvider().GetRequiredService<IPageRegister>();
            register.Register<P>(name);

            return builder;
        }

    }
}
