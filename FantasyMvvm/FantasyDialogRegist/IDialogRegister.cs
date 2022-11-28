using System;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogRegister
{
	public interface IDialogRegister
	{
        void Register<P, PM>(string name);
        void Register<P>(string name);

        DialogModel GetDialogModelByName(string name);
    }
}

