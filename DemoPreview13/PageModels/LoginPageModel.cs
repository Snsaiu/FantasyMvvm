using FantasyMvvm;
using FantasyMvvm.FantasyDialogService;﻿
using CommunityToolkit.Mvvm.Input;
using FantasyMvvm.FantasyNavigation;
using FantasyMvvm.FantasyRegionManager;


namespace DemoPreview13.PageModels
{
    public partial class LoginPageModel : FantasyPageModelBase
    {


        public LoginPageModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }



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

            this.dialogService.DisplayAlert("title", "message", "cancel");
        }

        protected virtual bool CanRegistExecute() { return true; }


        private INavigationService _regionManager = null;

        public LoginPageModel(INavigationService regionManager)
        {
            this._regionManager = regionManager;
        }


        [ICommand]
        public void Login()
        {
            this._regionManager.NavigationToAsync("HomePage", false);
        }
    }

}