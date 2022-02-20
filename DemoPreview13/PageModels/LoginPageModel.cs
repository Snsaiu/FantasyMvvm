using FantasyMvvm;
using FantasyMvvm.FantasyDialogService;
using Microsoft.Toolkit.Mvvm.Input;

namespace DemoPreview13.PageModels
{
    public class LoginPageModel:FantasyPageModelBase
    {

        public LoginPageModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        #region RegistCommand

        RelayCommand _RegistCommand = null;
        private readonly IDialogService dialogService;

        public RelayCommand RegistCommand
        {
            get
            {
                if (_RegistCommand == null) _RegistCommand = new RelayCommand(RegistExecute, CanRegistExecute);
                return _RegistCommand;
            }
        }

        protected virtual void RegistExecute()
        {
            // logic when the command is executed.
            this.dialogService.DisplayAlert("title", "message", "cancel");
        }

        protected virtual bool CanRegistExecute() { return true; }

        #endregion RegistCommand
    }
}
