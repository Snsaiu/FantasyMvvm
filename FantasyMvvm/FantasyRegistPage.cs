using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm
{
    using FantasyMvvm.FantasyPageRegist;

    public static class FantasyRegistPage
    {

        public static MauiAppBuilder UseRegistPage<P, PM>(this MauiAppBuilder builder,string name)
        {

            var regist = builder.Services.BuildServiceProvider().GetRequiredService<IPageRegist>();
            regist.Regist<P,PM>(name);

            return builder;
        }
    

     
    
    }
}
