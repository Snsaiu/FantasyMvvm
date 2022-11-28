using System;
using CommunityToolkit.Maui.Views;
using FantasyMvvm.FantasyDialogRegister;

namespace FantasyMvvm
{
	public static class FantasyRegisterDialog
	{

        public static MauiAppBuilder UseRegisterDialog<D, DM>(this MauiAppBuilder builder, string name=null) where D :Popup where DM : FantasyDialogModelBase
        {

            var register = builder.Services.BuildServiceProvider().GetRequiredService<IDialogRegister>();
            register.Register<D, DM>(name);
            return builder;
        }

        public static MauiAppBuilder UseRegisterDialog<D>(this MauiAppBuilder builder,string name=null) where D:Popup
        {
            var register = builder.Services.BuildServiceProvider().GetRequiredService<IDialogRegister>();
            register.Register<D>(name);
            return builder;
        }

    }
}

