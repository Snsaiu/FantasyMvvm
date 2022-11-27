using System;
using FantasyMvvm.FantasyDialogRegist;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyLocator
{
	public abstract class DialogModelLocatorBase
	{
		private readonly IDialogRegist _dialogRegist;
		
		public DialogModelLocatorBase(IDialogRegist dialogRegist)
		{
			this._dialogRegist = dialogRegist;
		}

		public DialogModelElement GetDialogModelElementByName(string name)
		{
			var v = this._dialogRegist.GetDialogModelByName(name);
			if (v != null)
			{
				DialogModelElement element = this.Parse(v);
				return element;
			}

			throw new NullReferenceException($"{name} 未发现可注册的Popup，请检查是否已经注册！");
		}

		protected abstract DialogModelElement Parse(DialogModel dialogModel);
	}
}

