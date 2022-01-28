using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace FantasyMvvm;

public class FantasyViewModelBase:ObservableRecipient
{
    public FantasyViewModelBase()
    {
        this.IsActive = true;
    }
}