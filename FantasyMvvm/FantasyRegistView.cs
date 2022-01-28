using FantasyMvvm.FantasyViewRegist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm
{
    public static class FantasyRegistView
    {
        public static MauiAppBuilder UseRegistView<V, VM>(this MauiAppBuilder builder, string name)
        {

            var regist = builder.Services.BuildServiceProvider().GetRequiredService<IViewRegist>();
            regist.Regist<V, VM>(name);

            return builder;
        }

    }
}
