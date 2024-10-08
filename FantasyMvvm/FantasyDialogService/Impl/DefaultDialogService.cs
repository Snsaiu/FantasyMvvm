﻿using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

using FantasyMvvm.FantasyLocator;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogService.Impl
{
    public class DefaultDialogService : IDialogService
    {
        public IPopupService PopupService { get; }


        public DefaultDialogService(IPopupService popupService)
        {
            PopupService = popupService;
        }
        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            string res = await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
            return res;
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
        {
            string res = await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);

            return res;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);

        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            bool res = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            return res;
        }

        public async Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel, flowDirection);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            bool res = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
            return res;
        }

        public async Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
        {
            string res = await Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
            return res;
        }

        public async Task ShowPopUpDialogAsync(string dialogName, INavigationParameter parameter = null, Action<CloseResultModel> closeEvent = null)
        {
            if (string.IsNullOrEmpty(dialogName))
            {
                throw new ArgumentException($"dialogName 不能为空");
            }

            DialogModelLocatorBase locator = FantasyContainer.GetRequiredService<DialogModelLocatorBase>();

            DialogModelElement dm = locator.GetDialogModelElementByName(dialogName);

            if (dm == null)
                throw new NullReferenceException($"{dialogName}的Popup实例为空！请检查popup是否已经注册");
            if (dm.Dialog is Popup p)
            {
                if (dm.DialogModel is not null and FantasyDialogModelBase dialogModel)
                {

                    p.BindingContext = dialogModel;
                    dialogModel.OnParameter(parameter);
                    dialogModel.OnCloseEvent += (r) =>
                    {
                        closeEvent?.Invoke(r);
                        p.Close();
                    };

                }

                await Application.Current.MainPage.ShowPopupAsync(p);
            }
            else
            {
                throw new Exception("注册的类型不是popup类型");
            }

        }
    }
}
