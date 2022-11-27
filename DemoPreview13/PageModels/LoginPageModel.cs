using FantasyMvvm;
using FantasyMvvm.FantasyDialogService;﻿
using CommunityToolkit.Mvvm.Input;
using FantasyMvvm.FantasyModels.Impls;
using FantasyMvvm.FantasyNavigation;
using FantasyMvvm.FantasyRegionManager;


namespace DemoPreview13.PageModels
{
    public partial class LoginPageModel : FantasyPageModelBase
    {

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

        public LoginPageModel(INavigationService regionManager,IDialogService dialogService)
        {
            this._regionManager = regionManager;
            this.dialogService = dialogService;
        }

        [ICommand]
        public async void ShowSummary()
        {
            var paramter = new NavigationParamter();
            paramter.Add("input","i am input paramter");
           await this.dialogService.ShowPopUpDialogAsync("SummaryDialog",paramter, (x) =>
           {
               this.dialogService.DisplayAlert("info", x.Data.ToString(), "ok", "cancel");

           });
        }


        [ICommand]
        public void Login()
        {
            this._regionManager.NavigationToAsync("HomePage", false);
        }
    }

}