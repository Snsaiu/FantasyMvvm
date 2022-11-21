

using CommunityToolkit.Mvvm.ComponentModel;

namespace FantasyMvvm;

public class FantasyViewModelBase:ObservableRecipient
{
    public FantasyViewModelBase()
    {
        this.IsActive = true;
    }
}