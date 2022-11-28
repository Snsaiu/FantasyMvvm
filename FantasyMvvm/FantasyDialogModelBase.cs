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
		/// when init it will be called.you can get parameter in here
		/// </summary>
		/// <param name="parameter"></param>
		public abstract void OnParameter(INavigationParameter parameter);
	}
}

