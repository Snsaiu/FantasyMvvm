using System;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogRegist
{
	public interface IDialogRegist
	{
        void Regist<P, PM>(string name);

        DialogModel GetDialogModelByName(string name);
    }
}

