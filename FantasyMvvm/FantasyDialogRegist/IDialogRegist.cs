using System;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogRegist
{
	public interface IDialogRegist
	{
        void Regist<P, PM>(string name);
        void Regist<P>(string name);

        DialogModel GetDialogModelByName(string name);
    }
}

