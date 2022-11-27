using System;
using CommunityToolkit.Maui.Views;
using FantasyMvvm.FantasyDialogRegist;

namespace FantasyMvvm
{
	public static class FantasyRegistDialog
	{

        public static MauiAppBuilder UseRegistDialog<D, DM>(this MauiAppBuilder builder, string name) where D :Popup where DM : FantasyDialogModelBase
        {

            var regist = builder.Services.BuildServiceProvider().GetRequiredService<IDialogRegist>();
            regist.Regist<D, DM>(name);
            return builder;
        }


    }
}

