using CommunityToolkit.Mvvm.ComponentModel;
using FantasyMvvm;
using FantasyMvvm.FantasyModels;
using Microsoft.Toolkit.Mvvm.Input;

namespace DemoPreview13.PageModels;

public partial class SummaryDialogModel : FantasyDialogModelBase
{
    public override event OnCloseDelegate OnCloseEvent;

    [ObservableProperty]
    private string input = "";
    public override void OnParameter(INavigationParameter parameter)
    {
       this.Input= parameter.Get<string>("input");
    }

    [ICommand]
   public void Close()
    {
        this.OnCloseEvent(new CloseResultModel { Success = true, Data = "close ok" });

    }

}