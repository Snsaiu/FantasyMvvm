﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyMvvm.FantasyModels;

namespace FantasyMvvm.FantasyDialogService
{
    public interface IDialogService
    {
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons);

        public Task DisplayAlert(string title, string message, string cancel);

        public Task ShowPopUpDialogAsync(string dialogName,INavigationParameter parameter=null,Action<CloseResultModel> closeEvent=null);


        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        public Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection);

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection);

        public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "");

    }
}
