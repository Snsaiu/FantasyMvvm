using System;
using CommunityToolkit.Mvvm.ComponentModel;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm
{

	public delegate void OnCloseDelegate(CloseResultModel resultModel);

	public abstract class FantasyDialogModelBase:ObservableObject
	{

		public FantasyDialogModelBase()
		{

		}

		public abstract event OnCloseDelegate OnCloseEvent;

		/// <summary>
		/// when init it will be called.you can get paramter in here
		/// </summary>
		/// <param name="paramter"></param>
		public abstract void OnParamter(INavigationParamter paramter);
	}
}

