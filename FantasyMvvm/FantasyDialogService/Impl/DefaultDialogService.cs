using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyMvvm.FantasyDialogService.Impl
{
    public class DefaultDialogService : IDialogService
    {
        public  async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
           var res= await   Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
            return res;
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
        {
            var res = await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);

            return res;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
             await Application.Current.MainPage.DisplayAlert(title, message, cancel);
            
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var res = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            return res;
        }

        public async Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel, flowDirection);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            var res = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
            return res;
        }

        public async Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
        {
            var res = await Application.Current.MainPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
            return res;
        }
    }
}
